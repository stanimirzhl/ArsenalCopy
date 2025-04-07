using System;
using System.Collections.Generic;

namespace Presentation.Data.Models;

public partial class Team
{
    public int TeamId { get; set; }

    public string? TeamName { get; set; }

    public string? Country { get; set; }

    public int? FoundationYear { get; set; }

    public virtual ICollection<Driver> Drivers { get; set; } = new List<Driver>();
}
