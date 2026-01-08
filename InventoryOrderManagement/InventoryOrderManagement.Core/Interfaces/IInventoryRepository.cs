namespace InventoryOrderManagement.Core.Interfaces;

using InventoryOrderManagement.Core.Models;

public interface IInventoryRepository
{
    InventoryItem? GetItem(string itemId);
    void UpdateItem(InventoryItem item);
    void AddItem(InventoryItem item);
    IEnumerable<InventoryItem> GetAll();
}