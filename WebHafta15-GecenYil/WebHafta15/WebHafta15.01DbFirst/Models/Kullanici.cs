using System;
using System.Collections.Generic;

namespace WebHafta15._01DbFirst.Models;

public partial class Kullanici
{
    public int KullaniciId { get; set; }

    public string AdSoyad { get; set; } = null!;

    public string Sifre { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public string MailKodu { get; set; } = null!;

    public bool MailOnay { get; set; }

    public virtual ICollection<Adre> Adres { get; set; } = new List<Adre>();

    public virtual ICollection<SepetUrun> SepetUruns { get; set; } = new List<SepetUrun>();

    public virtual ICollection<Sipari> Siparis { get; set; } = new List<Sipari>();

    public virtual ICollection<Yorum> Yorums { get; set; } = new List<Yorum>();
}
