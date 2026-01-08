using InventoryOrderManagement.Core.Enums;
using InventoryOrderManagement.Core.Interfaces;
using InventoryOrderManagement.Core.Models;

namespace InventoryOrderManagement.Application.Services;

public class OrderService
{
    private readonly IOrderRepository _orderRepo;
    private readonly IInventoryRepository _inventoryRepo;

    public OrderService(IOrderRepository orderRepo, IInventoryRepository inventoryRepo)
    {
        _orderRepo = orderRepo;
        _inventoryRepo = inventoryRepo;
    }

    public void CreateOrder(List<(string ItemId, int Qty)> items)
    {
        var order = new Order
        {
            OrderId = _orderRepo.GetNextId(),
            Items = items.Select(x => new OrderLineItem { ItemId = x.ItemId, Quantity = x.Qty }).ToList()
        };

        _orderRepo.AddOrder(order);
        Console.WriteLine($"Order created (ID: {order.OrderId}, Status: Pending)");
    }

    public void ProcessOrder(int orderId)
    {
        var order = _orderRepo.GetOrder(orderId);
        if (order == null)
        {
            Console.WriteLine("Order not found.");
            return;
        }

        if (order.Status != OrderStatus.Pending)
        {
            Console.WriteLine($"Order {orderId} is already {order.Status}.");
            return;
        }

        foreach (var lineItem in order.Items)
        {
            var inventoryItem = _inventoryRepo.GetItem(lineItem.ItemId);

            if (inventoryItem == null || inventoryItem.QuantityAvailable < lineItem.Quantity)
            {
                order.Status = OrderStatus.Rejected;
                _orderRepo.UpdateOrder(order);
                Console.WriteLine($"Order {orderId} Rejected: Insufficient stock for {lineItem.ItemId}");
                return;
            }
        }

        foreach (var lineItem in order.Items)
        {
            var inventoryItem = _inventoryRepo.GetItem(lineItem.ItemId);
            inventoryItem.AdjustQuantity(-lineItem.Quantity);
            _inventoryRepo.UpdateItem(inventoryItem);
        }

        order.Status = OrderStatus.Fulfilled;
        _orderRepo.UpdateOrder(order);
        Console.WriteLine($"Order {orderId} Fulfilled");
    }
}