using System;
using System.Collections.Generic;

namespace WebHafta15._01DbFirst.Models;

public partial class Urun
{
    public int UrunId { get; set; }

    public string UrunAdi { get; set; } = null!;

    public int KatId { get; set; }

    public virtual Kategori Kat { get; set; } = null!;

    public virtual ICollection<SaticiUrun> SaticiUruns { get; set; } = new List<SaticiUrun>();

    public virtual ICollection<UrunOzellik> UrunOzelliks { get; set; } = new List<UrunOzellik>();
}
