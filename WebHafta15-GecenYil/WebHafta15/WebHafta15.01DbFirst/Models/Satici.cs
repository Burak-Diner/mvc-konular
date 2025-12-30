using System;
using System.Collections.Generic;

namespace WebHafta15._01DbFirst.Models;

public partial class Satici
{
    public int SaticiId { get; set; }

    public string SaticiAdi { get; set; } = null!;

    public string SaticiAdres { get; set; } = null!;

    public int SaticiMahId { get; set; }

    public virtual Mahalle SaticiMah { get; set; } = null!;

    public virtual ICollection<SaticiUrun> SaticiUruns { get; set; } = new List<SaticiUrun>();
}
