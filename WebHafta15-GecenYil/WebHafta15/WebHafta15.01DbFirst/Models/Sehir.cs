using System;
using System.Collections.Generic;

namespace WebHafta15._01DbFirst.Models;

public partial class Sehir
{
    public int SehirId { get; set; }

    public string SehirAdi { get; set; } = null!;

    public virtual ICollection<Ilce> Ilces { get; set; } = new List<Ilce>();
}
