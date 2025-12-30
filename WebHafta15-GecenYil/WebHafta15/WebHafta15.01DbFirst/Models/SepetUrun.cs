using System;
using System.Collections.Generic;

namespace WebHafta15._01DbFirst.Models;

public partial class SepetUrun
{
    public int SepetUrunId { get; set; }

    public int SepetKullaniciId { get; set; }

    public int SaticiUrunId { get; set; }

    public int UrunAdedi { get; set; }

    public bool HediyeMi { get; set; }

    public virtual SaticiUrun SaticiUrun { get; set; } = null!;

    public virtual Kullanici SepetKullanici { get; set; } = null!;
}
