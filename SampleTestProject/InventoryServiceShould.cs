using SampleProject.Models;
using SampleProject.Services;

namespace SampleTestProject;

public class InventoryServiceShould
{
    public InventoryService inventoryService;
    [SetUp]
    public void SetUp()
    {
        inventoryService = new InventoryService();
    }

    [Test]
    public void HaveStockAddMethod()
    {
        Assert.IsNotNull(
            typeof(InventoryService).GetMethod("AddStock")
        );
    }

    [Test]
    public void HaveStockMethodThatExpectsInventoryAndStockModel()
    {

        var inventory = new InventoryModel();
        var newStock = new StockModel();
        newStock.Product = String.Empty;
        Assert.DoesNotThrow(() =>
        inventoryService.AddStock(inventory, newStock)
            );
    }

    [Test]
    public void HaveStockMethodThatThrowsExceptionWhenNullValueIsProvided()
    {

        Assert.Throws<ArgumentNullException>(() =>
        inventoryService.AddStock(null, null)
            );

        Assert.Throws<ArgumentNullException>(() =>
        inventoryService.AddStock(new InventoryModel(), null)
            );

        Assert.Throws<ArgumentNullException>(() =>
        inventoryService.AddStock(null, new StockModel())
            );
    }

    [Test]
    public void HaveAddStockMethodThatAddsStockToInventory()
    {
        InventoryModel inventory = new InventoryModel();
        // Arrange
        var stock = new StockModel();
        stock.StockId = Guid.NewGuid();
        stock.Product = "iPhone";
        stock.Quantity = 1;

        // Act
        inventoryService.AddStock(inventory, stock);

        // Assert

        Assert.AreEqual(stock, inventory.Stocks[0]);
    }

    [Test]
    public void HaveAddStockMethodThatThrowsExceptionWhenProductIsNull()
    {
        InventoryModel inventory = new InventoryModel();
        // Arrange
        var stock = new StockModel();
        stock.StockId = Guid.NewGuid();
        stock.Product = null;
        stock.Quantity = 0;

        Assert.Throws<InvalidOperationException>(() =>
            inventoryService.AddStock(inventory, stock)
            );
    }

    [Test]
    public void HaveAddStockMethodThatDoesNotAllowDuplicateProducts()
    {
        var inventory = new InventoryModel();

        var stock1 = new StockModel();
        stock1.Product = "iPhone";

        var stock2 = new StockModel();
        stock2.Product = "iPhone";

        Assert.Throws<InvalidOperationException>(() =>
        {
            inventoryService.AddStock(inventory, stock1);
            inventoryService.AddStock(inventory, stock2);
        });
    }


    [Test]
    public void HaveGetAllStockMethod()
    {
        Assert.IsNotNull(
            typeof(InventoryService).GetMethod("GetAllStock")
        );
    }

    [Test]
    public void HaveGetAllStockMethodThatShouldNotReturnNullWhenStockIsAvailable()
    {
        var inventory = new InventoryModel();
        var stock = new StockModel();
        stock.StockId = Guid.NewGuid();
        stock.Product = "iPhone";
        stock.Quantity = 2;

        inventoryService.AddStock(inventory, stock);

        Assert.IsNotNull(
            inventoryService.GetAllStock(inventory)
            );

        var actualStocks = inventoryService.GetAllStock(inventory);

        var expectedStocks = inventory.Stocks;
        Assert.AreEqual(actualStocks, expectedStocks);


    }

    [Test]
    [TestCase(2, 3, 5)]
    [TestCase(-1, 3, 2)]
    [TestCase(1, 3, 4)]
    [TestCase(1, 0, 1)]
    [TestCase(-1, 0, -1)]
    public void HaveAddMethodThatReturnSumOfTwoNumbers(int a, int b, int expectedOutput)
    {
        var output = inventoryService.Add(a, b);

        Assert.AreEqual(expectedOutput, output);
    }
}
