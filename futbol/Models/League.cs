using System;
using System.Collections.Generic;

namespace futbol.Models;

public partial class League
{
    public int Id { get; set; }

    public int Name { get; set; }

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
