namespace InventoryOrderManagement.Core.Interfaces;

using InventoryOrderManagement.Core.Models;

public interface IOrderRepository
{
    int GetNextId();
    void AddOrder(Order order);
    Order? GetOrder(int id);
    void UpdateOrder(Order order);
    IEnumerable<Order> GetAll();
}