using System;
using System.Collections.Generic;

namespace Web1Hafta14.WebDbFirst.Models;

public partial class TbDepartman
{
    public int DepartmanId { get; set; }

    public string DepartmanAdi { get; set; } = null!;

    public virtual ICollection<TbKisi> TbKisis { get; set; } = new List<TbKisi>();
}
