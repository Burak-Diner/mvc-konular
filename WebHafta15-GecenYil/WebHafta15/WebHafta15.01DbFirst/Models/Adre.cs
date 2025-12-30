using System;
using System.Collections.Generic;

namespace WebHafta15._01DbFirst.Models;

public partial class Adre
{
    public int AdresId { get; set; }

    public int KullaniciId { get; set; }

    public string AdSoyad { get; set; } = null!;

    public string Cep { get; set; } = null!;

    public string AdresSatir1 { get; set; } = null!;

    public string? AdresSatir2 { get; set; }

    public int MahId { get; set; }

    public virtual Kullanici Kullanici { get; set; } = null!;

    public virtual Mahalle Mah { get; set; } = null!;

    public virtual ICollection<Sipari> Siparis { get; set; } = new List<Sipari>();
}
