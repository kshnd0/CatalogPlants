using System;
using System.Collections.Generic;

namespace CatalogPlants.Models;

public partial class Uhod
{
    public int UhodId { get; set; }

    public DateTime? DataIVremya { get; set; }

    public string Opisanie { get; set; } = null!;

    public int RastenieId { get; set; }

    public virtual Rastenie Rastenie { get; set; } = null!;
}
