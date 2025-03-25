namespace ReStore.API.Entities;

public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public long Price { get; set; } //It could be decimal, but the payment provider uses long. And that just means we'll need to divide everything by 100 to get the decimal value.
    public required string PictureUrl { get; set; }  
    public required string Type { get; set; } 
    public required string Brand { get; set; } 
    public int QuantityInStock { get; set; } 
}
