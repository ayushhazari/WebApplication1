using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public string? CardNumber { get; set; }

    public DateTime CardExpiry { get; set; }

    public string? CardOwner { get; set; }
}
