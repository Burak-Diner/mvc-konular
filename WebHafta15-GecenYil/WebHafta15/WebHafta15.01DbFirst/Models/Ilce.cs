using System;
using System.Collections.Generic;

namespace WebHafta15._01DbFirst.Models;

public partial class Ilce
{
    public int IlceId { get; set; }

    public string IlceAdi { get; set; } = null!;

    public int SehirId { get; set; }

    public virtual ICollection<Mahalle> Mahalles { get; set; } = new List<Mahalle>();

    public virtual Sehir Sehir { get; set; } = null!;
}
