namespace InventoryOrderManagement.Core.Models;

using InventoryOrderManagement.Core.Models;

public interface InventoryuRepository
{
    InventoryItem? GetItem(string itemID);
    void UpdateItem(InventoryItem item);
    void AddItem(InventoryItem item);
    IEnumerable<InventoryItem> GetAll();
}
