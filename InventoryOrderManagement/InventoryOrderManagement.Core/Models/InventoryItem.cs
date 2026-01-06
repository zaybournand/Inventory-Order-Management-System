namespace InventoryOrderManagement.Core.Models;

public class InventoryItem
{
    public string ItemId { get; set; }
    public string Name { get; set; }
    public int QuantityAvailable { get; private set; }

    public InventoryItem(string itemId, string name, int quantity)
    {
        ItemId = itemId;
        Name = name;
        QuantityAvailable = quantity;
    }

    public void AdjustQuantity(int amount)
    {
        if (QuantityAvailable + amount < 0)
            throw new InvalidOperationException($"Insufficient stock for item {Name}");

        QuantityAvailable += amount;
    }
}