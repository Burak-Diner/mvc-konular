using System;
using System.Collections.Generic;

namespace WebHafta15._01DbFirst.Models;

public partial class Ozellik
{
    public int OzellikId { get; set; }

    public string OzellikAdi { get; set; } = null!;

    public virtual ICollection<KategoriOzellik> KategoriOzelliks { get; set; } = new List<KategoriOzellik>();

    public virtual ICollection<UrunOzellik> UrunOzelliks { get; set; } = new List<UrunOzellik>();
}
