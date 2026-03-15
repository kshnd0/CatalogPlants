using System;
using System.Collections.Generic;

namespace CatalogPlants.Models;

public partial class PlantParameter
{
    public int PlantParametersId { get; set; }

    public string? Age { get; set; }

    public DateTime? PlantingDate { get; set; }

    public string? Size { get; set; }

    public int? PlantId { get; set; }

    public virtual Plant? Plant { get; set; }
}
