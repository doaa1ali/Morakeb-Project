using System;
using System.Collections.Generic;

namespace AliaaProject.Models;

public partial class College
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Committee> Committees { get; set; } = new List<Committee>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
