using System;
using System.Collections.Generic;

namespace API_BlobsOfGobs.Models;

public partial class Order
{
    public string OrderId { get; set; } = null!;

    public string CustomerId { get; set; } = null!;

    public bool IsPaid { get; set; }

    public virtual ICollection<OrderGob> OrderGobs { get; set; } = new List<OrderGob>();
}
