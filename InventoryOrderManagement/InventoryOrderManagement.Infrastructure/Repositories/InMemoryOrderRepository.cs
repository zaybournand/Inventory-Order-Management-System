using InventoryOrderManagement.Core.Interfaces;
using InventoryOrderManagement.Core.Models;

namespace InventoryOrderManagement.Infrastructure.Repositories;

public class InMemoryOrderRepository : IOrderRepository
{
    private readonly List<Order> _orders = new();
    private int _currentId = 100;

    public int GetNextId() => ++_currentId;

    public void AddOrder(Order order) => _orders.Add(order);

    public Order? GetOrder(int id) => _orders.FirstOrDefault(o => o.OrderId == id);

    public void UpdateOrder(Order order)
    {
        var existing = GetOrder(order.OrderId);
        if (existing != null)
        {
            existing.Status = order.Status;
        }
    }

    public IEnumerable<Order> GetAll() => _orders;
}