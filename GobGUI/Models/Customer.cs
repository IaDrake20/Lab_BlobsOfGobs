using System;
using System.Collections.Generic;

namespace API_BlobsOfGobs.Models;

public partial class Customer
{
    public string CustomerId { get; set; } = null!;

    public string? Fname { get; set; }

    public string? Lname { get; set; }
}
