using System;
using System.Collections.Generic;

namespace Web1Hafta14.WebDbFirst.Models;

public partial class TbKisi
{
    public int KisiId { get; set; }

    public string Adi { get; set; } = null!;

    public string Soyadi { get; set; } = null!;

    public int DepartmanId { get; set; }

    public virtual TbDepartman Departman { get; set; } = null!;
}
