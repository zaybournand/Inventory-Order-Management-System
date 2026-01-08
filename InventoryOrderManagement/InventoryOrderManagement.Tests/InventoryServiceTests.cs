using Xunit;
using InventoryOrderManagement.Application.Services;
using InventoryOrderManagement.Infrastructure.Repositories;

namespace InventoryOrderManagement.Tests;

public class InventoryServiceTests
{
    [Fact]
    public void AddItem_ShouldIncreaseQuantity()
    {
        // 1. Set up 
        var repo = new InMemoryInventoryRepository();
        var service = new InventoryService(repo);

        // 2. Test Adding new item
        service.AddItem("Hammer", "Hammer", 10);

        // 3. Verify Results
        var item = repo.GetItem("Hammer");
        Assert.NotNull(item);
        Assert.Equal(10, item.QuantityAvailable);
    }

    [Fact]
    public void AddItem_ShouldNotOverwriteExistingItem()
    {
        // 1. Set up 
        var repo = new InMemoryInventoryRepository();
        var service = new InventoryService(repo);

        // Test Adding new item
        service.AddItem("Drill", "Drill", 5);

        // 2. Test Adding new item again
        service.AddItem("Drill", "Drill", 50);

        // 3. Verify result (quantity should remain 5)
        var item = repo.GetItem("Drill");
        Assert.Equal(5, item.QuantityAvailable);
    }
}