using System;
using System.Collections.Generic;

namespace MyApi.Models;

public partial class Employee
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Employer> Employers { get; set; } = new List<Employer>();
}
