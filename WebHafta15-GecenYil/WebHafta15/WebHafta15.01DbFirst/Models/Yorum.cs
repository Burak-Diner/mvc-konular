using System;
using System.Collections.Generic;

namespace WebHafta15._01DbFirst.Models;

public partial class Yorum
{
    public int YorumId { get; set; }

    public int SaticiUrunId { get; set; }

    public int KullaniciId { get; set; }

    public byte Puan { get; set; }

    public string YorumMetin { get; set; } = null!;

    public DateTime Tarih { get; set; }

    public virtual Kullanici Kullanici { get; set; } = null!;

    public virtual SaticiUrun SaticiUrun { get; set; } = null!;
}
