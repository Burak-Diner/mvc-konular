using System.ComponentModel.DataAnnotations;

namespace WebHafta09.Web.Models
{
    //[MetadataType(typeof(KullaniciMetadata))]
    public class Kullanici
    {
        public int KullaniciId { get; set; }

        //[Required(ErrorMessage ="Kullanıcı adı boş bırakılamaz!")]
        //[Length(minimumLength:3, maximumLength:15, ErrorMessage ="Karakter boyutu 3-15 arasında olmalı!")]
        public string KullaniciAdi { get; set; }

        //[Required(ErrorMessage = "Kullanıcı soyadı boş bırakılamaz!")]
        public string KullaniciSoyadi { get; set; }

        //[Required(ErrorMessage = "Email boş bırakılamaz!")]
        //[EmailAddress(ErrorMessage ="Geçerli bir email adresi giriniz!")]
        public string KullaniciEmail { get; set; }

        public Kullanici() { }
        public Kullanici(int id, string adi, string soyadi, string email)
        {
            this.KullaniciId = id;
            this.KullaniciAdi = adi;
            this.KullaniciSoyadi = soyadi;
            this.KullaniciEmail = email;
        }
    }
}
