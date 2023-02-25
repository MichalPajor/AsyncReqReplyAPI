namespace AsyncReqReplyAPI.Models;

public class Product
{
    public string Name { get; set; } = null!;
    public string Owner { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal Value { get; set; }
}