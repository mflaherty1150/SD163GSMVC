using System;
using System.Collections.Generic;

namespace GSNet6.Data;

public partial class Transaction
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int CustomerId { get; set; }

    public int Quantity { get; set; }

    public DateTime DateOfPurchase { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
