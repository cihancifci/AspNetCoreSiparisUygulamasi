using SiparisNetCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiparisNetCore.Interfaces
{
    public interface IUrunRepository : IGenericRepository<Urun>
    {
        List<Category> GetirCategory(int urunId);
    }
}
