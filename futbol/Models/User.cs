using System;
using System.Collections.Generic;

namespace futbol.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
