using System.ComponentModel.DataAnnotations;

namespace Ornek.Web.Models
{
    public class UrunViewModel
    {
        [Display(Name = "Ürün Id")]
        public int UrunId { get; set; }

        [Required]
        [StringLength(100)]
        public string UrunAdi { get; set; } = string.Empty;

        [Display(Name = "Ürün Açıklaması")]
        public string? Aciklama { get; set; }

        [Display(Name = "Fiyat (₺)")]
        [Range(0, double.MaxValue)]
        public double UrunFiyat { get; set; }
    }
}
