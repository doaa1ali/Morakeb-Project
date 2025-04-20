using System;
using System.Collections.Generic;

namespace AliaaProject.Models;

public partial class Employee
{
    public string NationalId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int UniversityId { get; set; }

    public int CollegeId { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public int GovernorateId { get; set; }

    public int QualificationLevelId { get; set; }

    public int QualificationId { get; set; }

    public DateTime? HireDate { get; set; }

    public int JobGroupId { get; set; }

    public int QualitativeGroupId { get; set; }

    public int GradeId { get; set; }

    public string? JobStyle { get; set; }

    public string Cadre { get; set; } = null!;

    public string? Specialization { get; set; }

    public int MonitoringCount { get; set; }

    public string LastMonitoringPeriod { get; set; } = null!;

    public bool IsActive { get; set; }

    public int MaritalStatusId { get; set; }

    public bool IsObserving { get; set; }

    public virtual College College { get; set; } = null!;

    public virtual Governorate Governorate { get; set; } = null!;

    public virtual Grade Grade { get; set; } = null!;

    public virtual JobGroup JobGroup { get; set; } = null!;

    public virtual MaritalStatus MaritalStatus { get; set; } = null!;

    public virtual ICollection<Observation> Observations { get; set; } = new List<Observation>();

    public virtual Qualification Qualification { get; set; } = null!;

    public virtual QualificationLevel QualificationLevel { get; set; } = null!;

    public virtual QualitativeGroup QualitativeGroup { get; set; } = null!;

    public virtual University University { get; set; } = null!;
}
