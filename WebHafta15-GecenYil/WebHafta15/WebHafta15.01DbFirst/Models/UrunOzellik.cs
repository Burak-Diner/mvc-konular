using System;
using System.Collections.Generic;

namespace WebHafta15._01DbFirst.Models;

public partial class UrunOzellik
{
    public int UrunOzellikId { get; set; }

    public int OzellikId { get; set; }

    public int UrunId { get; set; }

    public string OzellikIcerik { get; set; } = null!;

    public virtual Ozellik Ozellik { get; set; } = null!;

    public virtual Urun Urun { get; set; } = null!;
}
