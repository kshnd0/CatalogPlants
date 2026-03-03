using System;
using System.Collections.Generic;

namespace PlantsCatalog.Models;

public partial class Patogen
{
    public int PatogenId { get; set; }

    public string Name { get; set; } = null!;

    public string? Opisanie { get; set; }

    public virtual ICollection<IstoriiBoleznej> IstoriiBoleznejs { get; set; } = new List<IstoriiBoleznej>();
}
