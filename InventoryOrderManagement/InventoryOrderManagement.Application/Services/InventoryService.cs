using InventoryOrderManagement.Core.Interfaces;
using InventoryOrderManagement.Core.Models;

namespace InventoryOrderManagement.Application.Services;

public class InventoryService
{
    private readonly IInventoryRepository _repo;

    public InventoryService(IInventoryRepository repo)
    {
        _repo = repo;
    }

    public void AddItem(string itemId, string name, int quantity)
    {
        if (_repo.GetItem(itemId) != null)
        {
            Console.WriteLine($"Error: Item {itemId} already exists.");
            return;
        }
        var item = new InventoryItem(itemId, name, quantity);
        _repo.AddItem(item);
        Console.WriteLine($"Item {name} added.");
    }

    public void PrintInventory()
    {
        foreach (var item in _repo.GetAll())
        {
            Console.WriteLine($"{item.Name} ({item.ItemId}): {item.QuantityAvailable}");
        }
    }
}