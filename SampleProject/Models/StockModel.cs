namespace SampleProject.Models;
public class StockModel
{
    public Guid StockId { get; set; }
    public string Product { get; set; }
    public double Quantity { get; set; } = 0;
}
