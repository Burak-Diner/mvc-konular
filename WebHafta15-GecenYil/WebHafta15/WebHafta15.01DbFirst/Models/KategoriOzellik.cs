using System;
using System.Collections.Generic;

namespace WebHafta15._01DbFirst.Models;

public partial class KategoriOzellik
{
    public int KategoriOzellikId { get; set; }

    public int OzellikId { get; set; }

    public int KategoriId { get; set; }

    public virtual Kategori Kategori { get; set; } = null!;

    public virtual Ozellik Ozellik { get; set; } = null!;
}
