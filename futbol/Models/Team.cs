using System;
using System.Collections.Generic;

namespace futbol.Models;

public partial class Team
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int UserId { get; set; }

    public int LeagueId { get; set; }

    public virtual League League { get; set; } = null!;

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();

    public virtual User User { get; set; } = null!;
}
