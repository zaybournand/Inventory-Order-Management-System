using InventoryOrderManagement.Application.Services;
using InventoryOrderManagement.Infrastructure.Repositories;

var inventoryRepo = new InMemoryInventoryRepository();
var orderRepo = new InMemoryOrderRepository();

var inventoryService = new InventoryService(inventoryRepo);
var orderService = new OrderService(orderRepo, inventoryRepo);

Console.WriteLine("=== Inventory Order Management System ===");
Console.WriteLine("Commands: add-item, view-inventory, create-order, process-order, exit");

while (true)
{
    Console.Write("\n> ");
    var input = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(input)) continue;

    var parts = input.Split(' ');
    var command = parts[0].ToLower();

    try
    {
        switch (command)
        {
            case "add-item":
                if (parts.Length < 3) throw new ArgumentException("Usage: add-item [Name] [Qty]");
                string name = parts[1];
                int qty = int.Parse(parts[2]);
                inventoryService.AddItem(name, name, qty);
                break;

            case "view-inventory":
                inventoryService.PrintInventory();
                break;

            case "create-order":
                var items = new List<(string, int)>();
                for (int i = 1; i < parts.Length; i++)
                {
                    var split = parts[i].Split(':');
                    items.Add((split[0], int.Parse(split[1])));
                }
                orderService.CreateOrder(items);
                break;

            case "process-order":
                if (parts.Length < 2) throw new ArgumentException("Usage: process-order [ID]");
                orderService.ProcessOrder(int.Parse(parts[1]));
                break;

            case "exit":
                return;

            default:
                Console.WriteLine("Unknown command.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}