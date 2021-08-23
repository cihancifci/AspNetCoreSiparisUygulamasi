using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiparisNetCore.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity:class,new()
    {
        void Ekle(TEntity entity);
        void Guncelle(TEntity entity);
        void Sil(TEntity entity);
        public List<TEntity> GetirHepsi();
        public TEntity IdIleGetir(int id);

    }
}
