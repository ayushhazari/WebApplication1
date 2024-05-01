using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Employee
{
    public int EmpId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? CompanyName { get; set; }

    public string? Contact { get; set; }

    public string? Password { get; set; }

   public virtual ICollection<Policy> Policies { get; set; } = new List<Policy>();
}
