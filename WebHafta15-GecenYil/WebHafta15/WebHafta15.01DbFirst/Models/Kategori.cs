using System;
using System.Collections.Generic;

namespace WebHafta15._01DbFirst.Models;

public partial class Kategori
{
    public int KategoriId { get; set; }

    public string KategoriAdi { get; set; } = null!;

    public int? UstKategoriId { get; set; }

    public virtual ICollection<Kategori> InverseUstKategori { get; set; } = new List<Kategori>();

    public virtual ICollection<KategoriOzellik> KategoriOzelliks { get; set; } = new List<KategoriOzellik>();

    public virtual ICollection<Urun> Uruns { get; set; } = new List<Urun>();

    public virtual Kategori? UstKategori { get; set; }
}
