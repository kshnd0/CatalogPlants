using System;
using System.Collections.Generic;

namespace PlantsCatalog.Models;

public partial class Semeistvo
{
    public int SemeistvoId { get; set; }

    public string Name { get; set; } = null!;

    public string? NameLatin { get; set; }

    public virtual ICollection<Rastenie> Rastenies { get; set; } = new List<Rastenie>();
}
