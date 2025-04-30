using System;

namespace ReStore.API.Entities;

public class Basket
{
    public int Id { get; set; }
    public int BasketId { get; set; } //We will store this value as a cookie in the user's browser, this way we persist it on the client side effectively.
    public List<BasketItem> Items {get;set; } = [];

    public void AddItem(Product product, int quantity)
    {
        if(product == null) ArgumentNullException.ThrowIfNull(product);

        if(quantity <= 0) throw new ArgumentException("Quantity should be greater than zero", nameof(quantity));
        
        var existingItem = FindItem(product.Id);

        if(existingItem == null)
        {
            Items.Add(new BasketItem
            {
                    Product = product,
                    Quantity = quantity

            });
        }
        else
        {
            existingItem.Quantity += quantity;

        }
    }

    public void RemoveItem(int productId, int quantity)
    {
        if(quantity <= 0) throw new ArgumentException("Quantity should be greater than zero", nameof(quantity));

        var Item = FindItem(productId);
        if(Item == null) return;

        Item.Quantity -= quantity;       
    }

    private BasketItem? FindItem(int productId)
    {
        return Items.FirstOrDefault(item => item.ProductId == productId);
    }
}
