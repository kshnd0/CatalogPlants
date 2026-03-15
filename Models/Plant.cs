using System;
using System.Collections.Generic;

namespace CatalogPlants.Models;

public partial class Plant
{
    public int PlantId { get; set; }

    public string Name { get; set; } = null!;

    public string? LatinName { get; set; }

    public int? LifeFormId { get; set; }

    public int? CareRequirementsId { get; set; }

    public virtual ICollection<CareLog> CareLogs { get; set; } = new List<CareLog>();

    public virtual CareRequirement? CareRequirements { get; set; }

    public virtual ICollection<DiseaseHistory> DiseaseHistories { get; set; } = new List<DiseaseHistory>();

    public virtual LifeForm? LifeForm { get; set; }

    public virtual ICollection<PlantParameter> PlantParameters { get; set; } = new List<PlantParameter>();
}
