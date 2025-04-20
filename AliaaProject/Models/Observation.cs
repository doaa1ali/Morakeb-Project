using System;
using System.Collections.Generic;

namespace AliaaProject.Models;

public partial class Observation
{
    public int Id { get; set; }

    public string EmployeeId { get; set; } = null!;

    public DateTime DateOfObservation { get; set; }

    public string? TimeOfDay { get; set; }

    public int CommitteeId { get; set; }

    public virtual Committee Committee { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;
}
