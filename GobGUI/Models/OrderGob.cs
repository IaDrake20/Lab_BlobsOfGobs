using System;
using System.Collections.Generic;

namespace API_BlobsOfGobs.Models;

public partial class OrderGob
{
    public string OrderGobId { get; set; } = null!;

    public string FlavorId { get; set; } = null!;

    public string OrderId { get; set; } = null!;

    public int Quantity { get; set; }

    public virtual GobFlavor Flavor { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
