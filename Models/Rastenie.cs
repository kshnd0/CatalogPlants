using System;
using System.Collections.Generic;

namespace CatalogPlants.Models;

public partial class Rastenie
{
    public int RastenieId { get; set; }

    public string Name { get; set; } = null!;

    public string? NameLatin { get; set; }

    public int? SemeistvoId { get; set; }

    public int? ZhiznennayaFormaId { get; set; }

    public int? TrebovaniyaId { get; set; }

    public virtual ICollection<IstoriiBoleznej> IstoriiBoleznejs { get; set; } = new List<IstoriiBoleznej>();

    public virtual ICollection<ParametryRasteniya> ParametryRasteniyas { get; set; } = new List<ParametryRasteniya>();

    public virtual Semeistvo? Semeistvo { get; set; }

    public virtual TrebovaniyaKUhodu? Trebovaniya { get; set; }

    public virtual ICollection<Uhod> Uhods { get; set; } = new List<Uhod>();

    public virtual ZhiznennayaForma? ZhiznennayaForma { get; set; }
}
