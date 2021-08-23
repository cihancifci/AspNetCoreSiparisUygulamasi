using SiparisNetCore.Contexts;
using SiparisNetCore.Entities;
using SiparisNetCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiparisNetCore.Repositories
{
    public class UrunRepository : GenericRepository<Urun>,IUrunRepository
    {
        public List<Category> GetirCategory(int urunId)
        {
            using var context = new SiparisContext();
            return context.Urunler.Join(context.UrunCategories, urun => urun.Id, urunCategory => urunCategory.urunId, (u, uc) => new 
            { 
                urun = u,
                urunCategory = uc
            }).Join(context.Categories, iki=> iki.urunCategory.categoryId,category=>category.Id,(uc,c)=>new 
            {
                urun = uc.urun,
                category=c,
                urunCategory=uc.urunCategory
            }).Where(I=>I.urun.Id == urunId).Select(I=>new Category 
            { 
                Ad=I.category.Ad,
                Id=I.category.Id
            }).ToList();
        }
    }
}
