using System;
using System.Collections.Generic;

namespace Presentation.Data.Models;

public partial class RaceResult
{
    public int ResultId { get; set; }

    public int? RaceId { get; set; }

    public int? DriverId { get; set; }

    public int? Position { get; set; }

    public decimal? Points { get; set; }

    public int? Laps { get; set; }

    public TimeOnly? Time { get; set; }

    public virtual Driver? Driver { get; set; }

    public virtual Race? Race { get; set; }
}
