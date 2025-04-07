using System;
using System.Collections.Generic;

namespace Presentation.Data.Models;

public partial class Driver
{
    public int DriverId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? Nationality { get; set; }

    public int? TeamId { get; set; }

    public virtual ICollection<RaceResult> RaceResults { get; set; } = new List<RaceResult>();

    public virtual Team? Team { get; set; }
}
