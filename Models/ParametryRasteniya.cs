using System;
using System.Collections.Generic;

namespace PlantsCatalog.Models;

public partial class ParametryRasteniya
{
    public int ParametryId { get; set; }

    public int? Vozrast { get; set; }

    public DateOnly? DataPosadki { get; set; }

    public string? Razmery { get; set; }

    public int RastenieId { get; set; }

    public virtual Rastenie Rastenie { get; set; } = null!;
}
