using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiparisNetCore.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Ad { get; set; }
        [MaxLength(100)]
        public List<UrunCategory> UrunCategories { get; set; }
    }
}
