using System;
using System.Collections.Generic;

namespace CatalogPlants.Models;

public partial class LifeForm
{
    public int LifeFormId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Plant> Plants { get; set; } = new List<Plant>();
}
