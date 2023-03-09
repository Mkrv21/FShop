using System;
using System.Collections.Generic;

namespace FShop;

public partial class Product
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public long Quantity { get; set; }

    public long Price { get; set; }

    public string? Description { get; set; }

    public byte[]? Image { get; set; }

    public virtual ICollection<ProductsInOrder> ProductsInOrders { get; } = new List<ProductsInOrder>();
}
