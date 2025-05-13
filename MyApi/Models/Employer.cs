using System;
using System.Collections.Generic;

namespace MyApi.Models;

public partial class Employer
{
    public int TableId { get; set; }

    public string EmpName { get; set; } = null!;

    public long? Id { get; set; }

    public virtual Employee? IdNavigation { get; set; }
}
