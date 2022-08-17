namespace SampleProject.Models;
public class InventoryModel
{
    public int InventoryId { get; set; }
    public string InventoryName { get; set; }

    public List<StockModel> Stocks { get; set; } = new List<StockModel>();
}
