using InventoryOrderManagement.Core.Enums;

namespace InventoryOrderManagement.Core.Models;

public class Order
{
    public int OrderId { get; set; }

    public List<OrderLineItem> Items { get; set; } = new();

    public OrderStatus Status { get; set; } = OrderStatus.Pending;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}