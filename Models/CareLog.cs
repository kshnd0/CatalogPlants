using System;
using System.Collections.Generic;

namespace CatalogPlants.Models;

public partial class CareLog
{
    public int CareLogId { get; set; }

    public DateTime? DateTime { get; set; }

    public string? Description { get; set; }

    public int? PlantId { get; set; }

    public virtual Plant? Plant { get; set; }
}
