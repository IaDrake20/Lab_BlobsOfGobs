using System;
using System.Collections.Generic;

namespace API_BlobsOfGobs.Models;

public partial class GobFlavor
{
    public string FlavorId { get; set; } = null!;

    public string FlavorName { get; set; } = null!;

    public virtual ICollection<OrderGob> OrderGobs { get; set; } = new List<OrderGob>();
}
