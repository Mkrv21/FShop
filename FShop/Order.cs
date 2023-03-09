using System;
using System.Collections.Generic;

namespace FShop;

public partial class Order
{
    public long Id { get; set; }

    public long IdUser { get; set; }

    public string Name { get; set; } = null!;

    public long Fullprice { get; set; }

    public string Date { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string? Comment { get; set; }

    public string Phone { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;

    public virtual ICollection<ProductsInOrder> ProductsInOrders { get; } = new List<ProductsInOrder>();
}
