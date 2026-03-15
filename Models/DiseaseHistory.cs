using System;
using System.Collections.Generic;

namespace CatalogPlants.Models;

public partial class DiseaseHistory
{
    public int DiseaseHistoryId { get; set; }

    public int? PlantId { get; set; }

    public int? PathogenId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Description { get; set; }

    public virtual Pathogen? Pathogen { get; set; }

    public virtual Plant? Plant { get; set; }
}
