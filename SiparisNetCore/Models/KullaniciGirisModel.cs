using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiparisNetCore.Models
{
    public class KullaniciGirisModel
    {
        [Required(ErrorMessage ="Kullanıcı adı boş girilemez!")]
        public string kullaniciAd { get; set; }
        [Required(ErrorMessage = "Şifre boş girilemez!")]
        public string sifre { get; set; }
        public bool beniHatirla { get; set; }
    }
}
