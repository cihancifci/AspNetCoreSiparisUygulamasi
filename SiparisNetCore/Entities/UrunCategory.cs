using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiparisNetCore.Entities
{
    public class UrunCategory
    {
        public int Id { get; set; }
        public int urunId { get; set; }
        public int categoryId { get; set; }
        public Urun urun { get; set; }
        public Category category { get; set; }
    }
}
