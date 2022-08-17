
using BenchmarkDotNet.Attributes;
using SampleProject.Models;

namespace SampleProject.Services;

[MemoryDiagnoser]
public class BenchmarkService
{
    public InventoryService InventoryService = new InventoryService();

    [Benchmark]
    public void OldAddMethod()
    {
        var inventory = new InventoryModel();
        var stock = new StockModel();
        stock.StockId = Guid.NewGuid();
        stock.Quantity = 1;
        stock.Product = "iPhone";

        InventoryService.AddStock_Old(inventory, stock);
    }

    [Benchmark]
    public void NewAddMethod()
    {
        var inventory = new InventoryModel();
        var stock = new StockModel();
        stock.StockId = Guid.NewGuid();
        stock.Quantity = 1;
        stock.Product = "iPhone";

        InventoryService.AddStock(inventory, stock);
    }
}
