using System;
using System.Collections.Generic;

namespace PlantsCatalog.Models;

public partial class IstoriiBoleznej
{
    public int IstoriyaId { get; set; }

    public int RastenieId { get; set; }

    public int PatogenId { get; set; }

    public DateOnly DataNachala { get; set; }

    public DateOnly? DataOkonchaniya { get; set; }

    public string? Opisanie { get; set; }

    public virtual Patogen Patogen { get; set; } = null!;

    public virtual Rastenie Rastenie { get; set; } = null!;
}
