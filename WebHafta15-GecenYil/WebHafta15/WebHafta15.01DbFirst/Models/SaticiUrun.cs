using System;
using System.Collections.Generic;

namespace WebHafta15._01DbFirst.Models;

public partial class SaticiUrun
{
    public int SaticiUrunId { get; set; }

    public int SaticiId { get; set; }

    public int UrunId { get; set; }

    public int StokAdedi { get; set; }

    public decimal Fiyat { get; set; }

    public virtual Satici Satici { get; set; } = null!;

    public virtual ICollection<SepetUrun> SepetUruns { get; set; } = new List<SepetUrun>();

    public virtual ICollection<SiparisUrun> SiparisUruns { get; set; } = new List<SiparisUrun>();

    public virtual Urun Urun { get; set; } = null!;

    public virtual ICollection<Yorum> Yorums { get; set; } = new List<Yorum>();
}
