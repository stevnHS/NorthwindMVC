using System;
using System.Collections.Generic;

namespace NorthwindMVC.Models;

public partial class ProductStatus
{
    public int StatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
