using System;
using System.Collections.Generic;

namespace WebHafta15._01DbFirst.Models;

public partial class Sipari
{
    public int SiparisId { get; set; }

    public int AdresId { get; set; }

    public int KullaniciId { get; set; }

    public bool OdemeOnayi { get; set; }

    public DateTime SiparisTarihi { get; set; }

    public virtual Adre Adres { get; set; } = null!;

    public virtual Kullanici Kullanici { get; set; } = null!;

    public virtual ICollection<SiparisUrun> SiparisUruns { get; set; } = new List<SiparisUrun>();
}
