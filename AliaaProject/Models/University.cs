using System;
using System.Collections.Generic;

namespace AliaaProject.Models;

public partial class University
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
