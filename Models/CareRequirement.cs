using System;
using System.Collections.Generic;

namespace CatalogPlants.Models;

public partial class CareRequirement
{
    public int CareRequirementsId { get; set; }

    public string? Lighting { get; set; }

    public string? WateringSummer { get; set; }

    public string? WateringWinter { get; set; }

    public string? TemperatureSummer { get; set; }

    public string? TemperatureWinter { get; set; }

    public virtual ICollection<Plant> Plants { get; set; } = new List<Plant>();
}
