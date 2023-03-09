using System;
using System.Collections.Generic;

namespace FShop;

public partial class User
{
    public long Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Fullname { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
