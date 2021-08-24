using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiparisNetCore.Models
{
    public class UrunEkleModel
    {
        [Required(ErrorMessage ="Ad alanı boş girilemez!")]
        public string ad { get; set; }
        [Range(1, (double)decimal.MaxValue, ErrorMessage = "Fiyat 0 dan yüksek olmalıdır!")]
        public decimal fiyat { get; set; }
        public IFormFile resim { get; set; }
    }
}
