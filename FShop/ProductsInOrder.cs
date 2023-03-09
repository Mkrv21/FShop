using System;
using System.Collections.Generic;

namespace FShop;

public partial class ProductsInOrder
{
    public long Id { get; set; }

    public long IdOrder { get; set; }

    public long IdProduct { get; set; }

    public virtual Order IdOrderNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
