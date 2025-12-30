using System;
using System.Collections.Generic;

namespace WebHafta15._01DbFirst.Models;

public partial class Mahalle
{
    public int MahalleId { get; set; }

    public string MahalleAdi { get; set; } = null!;

    public string MahallePostaKodu { get; set; } = null!;

    public int IlceId { get; set; }

    public virtual ICollection<Adre> Adres { get; set; } = new List<Adre>();

    public virtual Ilce Ilce { get; set; } = null!;

    public virtual ICollection<Satici> Saticis { get; set; } = new List<Satici>();
}
