using SampleProject.Models;

namespace SampleProject.Services;

public class InventoryService
{
    public void AddStock_Old(InventoryModel inventory, StockModel stock)
    {
        if (inventory is null)
            throw new ArgumentNullException(nameof(inventory));

        if (stock is null)
            throw new ArgumentNullException(nameof(stock));

        if (stock.Product is null)
            throw new InvalidOperationException(nameof(stock.Product));

        inventory.Stocks.Add(stock);
        return;
    }
    public void AddStock(InventoryModel inventory, StockModel stock)
    {
        if (inventory is null)
            throw new ArgumentNullException(nameof(inventory));

        if (stock is null)
            throw new ArgumentNullException(nameof(stock));

        if (stock.Product is null)
            throw new InvalidOperationException(nameof(stock.Product));

        CheckIfProductIsDuplicate(inventory, stock);

        inventory.Stocks.Add(stock);
        return;
    }

    private static void CheckIfProductIsDuplicate(InventoryModel inventory, StockModel stock)
    {
        if (inventory.Stocks.Any(a => a.Product == stock.Product || a.StockId == stock.StockId))
        {
            throw new InvalidOperationException(nameof(stock.Product));
        }
    }

    public List<StockModel> GetAllStock(InventoryModel inventory)
    {
        return inventory.Stocks;
    }

    public int Add(int a, int b)
    {
        return a + b;
    }
}