using System;
using System.Collections.Generic;

namespace PlantsCatalog.Models;

public partial class TrebovaniyaKUhodu
{
    public int TrebovaniyaId { get; set; }

    public string? Osveshchenie { get; set; }

    public string? PolivLetom { get; set; }

    public string? PolivZimoy { get; set; }

    public string? TemperaturaLetom { get; set; }

    public string? TemperaturaZimoy { get; set; }

    public virtual ICollection<Rastenie> Rastenies { get; set; } = new List<Rastenie>();
}
