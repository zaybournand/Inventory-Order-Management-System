using Xunit;
using InventoryOrderManagement.Application.Services;
using InventoryOrderManagement.Infrastructure.Repositories;
using InventoryOrderManagement.Core.Enums;

namespace InventoryOrderManagement.Tests;

public class OrderServiceTests
{
    [Fact]
    public void ProcessOrder_ShouldFulfill_WhenStockIsSufficient()
    {
        // 1. Set up
        var inventoryRepo = new InMemoryInventoryRepository();
        var orderRepo = new InMemoryOrderRepository();
        var service = new OrderService(orderRepo, inventoryRepo);

        // Add 10 Bolts to stock
        inventoryRepo.AddItem(new InventoryOrderManagement.Core.Models.InventoryItem("Bolt", "Bolt", 10));

        // Create order for 5 Bolts
        var items = new List<(string, int)> { ("Bolt", 5) };
        service.CreateOrder(items);
        var orderId = orderRepo.GetAll().First().OrderId;

        // 2. Test
        service.ProcessOrder(orderId);

        // 3. Verify Results
        var order = orderRepo.GetOrder(orderId);
        var inventoryItem = inventoryRepo.GetItem("Bolt");

        Assert.Equal(OrderStatus.Fulfilled, order.Status);
        Assert.Equal(5, inventoryItem.QuantityAvailable); // 10 - 5 = 5
    }

    [Fact]
    public void ProcessOrder_ShouldReject_WhenStockIsInsufficient()
    {
        // 1. Set up
        var inventoryRepo = new InMemoryInventoryRepository();
        var orderRepo = new InMemoryOrderRepository();
        var service = new OrderService(orderRepo, inventoryRepo);

        // Add only 2 Sensors to stock
        inventoryRepo.AddItem(new InventoryOrderManagement.Core.Models.InventoryItem("Sensor", "Sensor", 2));

        // Try to order 10 Sensors (should be Rejected!)
        var items = new List<(string, int)> { ("Sensor", 10) };
        service.CreateOrder(items);
        var orderId = orderRepo.GetAll().First().OrderId;

        // 2. Test
        service.ProcessOrder(orderId);

        // 3. Verify Results
        var order = orderRepo.GetOrder(orderId);
        var inventoryItem = inventoryRepo.GetItem("Sensor");

        Assert.Equal(OrderStatus.Rejected, order.Status); // Should be Rejected
        Assert.Equal(2, inventoryItem.QuantityAvailable); // Stock should not change
    }
}