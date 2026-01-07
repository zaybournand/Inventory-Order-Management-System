namespace InventoryOrderManagement.Core.Interface;

using InventoryOrderManagement.Core.Models;

public interface OrderRepository
{
    int GetNextId();
    void AddOrder(OrderedDictionary order);
    OrderedDictionary? GetOrder(int id);
    void UpdateOrder(OrderedDictionary order);
    IEnumerable<Order> GetAll();
}