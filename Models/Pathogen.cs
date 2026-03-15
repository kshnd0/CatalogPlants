using System;
using System.Collections.Generic;

namespace CatalogPlants.Models;

public partial class Pathogen
{
    public int PathogenId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<DiseaseHistory> DiseaseHistories { get; set; } = new List<DiseaseHistory>();
}
