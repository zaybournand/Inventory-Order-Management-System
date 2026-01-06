using InventoryOrderManagement.Core.Enums; // Don't forget this for OrderStatus!

namespace InventoryOrderManagement.Core.Models;

public class Order
{
    public int OrderId { get; set; }

    public List<OrderLineItem> Items { get; set; } = new();

    public OrderStatus Status { get; set; } = OrderStatus.Pending;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}