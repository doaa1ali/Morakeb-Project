using System;
using System.Collections.Generic;

namespace AliaaProject.Models;

public partial class Committee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public DateTime DateOfCommittee { get; set; }

    public string Period { get; set; } = null!;

    public int CollegeId { get; set; }

    public int RequiredObservers { get; set; }

    public string UserName { get; set; } = null!;

    public virtual College College { get; set; } = null!;

    public virtual ICollection<Observation> Observations { get; set; } = new List<Observation>();

    public virtual AspNetUser User { get; set; } = null!;
}
