using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Policy
{
    public int PolicyId { get; set; }

    public string? PolicyName { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int? EmpId { get; set; }

    public string? InsurenceCompany { get; set; }

    public virtual Employee? Emp { get; set; }
}
