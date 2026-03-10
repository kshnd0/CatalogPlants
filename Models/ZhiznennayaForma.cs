using System;
using System.Collections.Generic;

namespace CatalogPlants.Models;

public partial class ZhiznennayaForma
{
    public int ZhiznennayaFormaId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Rastenie> Rastenies { get; set; } = new List<Rastenie>();
}
