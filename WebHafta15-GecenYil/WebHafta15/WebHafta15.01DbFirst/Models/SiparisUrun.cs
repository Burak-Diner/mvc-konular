using System;
using System.Collections.Generic;

namespace WebHafta15._01DbFirst.Models;

public partial class SiparisUrun
{
    public int SiparisUrunId { get; set; }

    public int SiparisId { get; set; }

    public int SatUrunId { get; set; }

    public int Adet { get; set; }

    public bool HediyeMi { get; set; }

    public virtual SaticiUrun SatUrun { get; set; } = null!;

    public virtual Sipari Siparis { get; set; } = null!;
}
