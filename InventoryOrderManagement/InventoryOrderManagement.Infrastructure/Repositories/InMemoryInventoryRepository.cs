using InventoryOrderManagement.Core.Interfaces;
using InventoryOrderManagement.Core.Models;

namespace InventoryOrderManagement.Infrastructure.Repositories;

public class InMemoryInventoryRepository : IInventoryRepository
{
    private readonly Dictionary<string, InventoryItem> store = new();

    public InventoryItem? GetItem(string itemId) =>
        store.ContainsKey(itemId) ? store[itemId] : null;

    public void AddItem(InventoryItem item) => store[item.ItemId] = item;

    public void UpdateItem(InventoryItem item) => store[item.ItemId] = item;

    public IEnumerable<InventoryItem> GetAll() => store.Values;
}