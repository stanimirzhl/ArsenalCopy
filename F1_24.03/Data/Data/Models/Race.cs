using System;
using System.Collections.Generic;

namespace Presentation.Data.Models;

public partial class Race
{
    public int RaceId { get; set; }

    public string? RaceName { get; set; }

    public string? Location { get; set; }

    public DateOnly? RaceDate { get; set; }

    public int? SeasonYear { get; set; }

    public virtual ICollection<RaceResult> RaceResults { get; set; } = new List<RaceResult>();
}
