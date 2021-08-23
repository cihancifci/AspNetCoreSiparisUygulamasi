using SiparisNetCore.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiparisNetCore.Repositories
{
    public class GenericRepository<Tentity> where Tentity:class,new()
    {
        public void Ekle(Tentity entity)
        {
            using var context = new SiparisContext();
            context.Set<Tentity>().Add(entity);
            context.SaveChanges();
        }

        public void Guncelle(Tentity entity)
        {
            using var context = new SiparisContext();
            context.Set<Tentity>().Update(entity);
            context.SaveChanges();
        }

        public void Sil(Tentity entity)
        {
            using var context = new SiparisContext();
            context.Set<Tentity>().Remove(entity);
            context.SaveChanges();
        }

        public List<Tentity> GetirHepsi()
        {
            using var context = new SiparisContext();
            return context.Set<Tentity>().ToList();
        }

        public Tentity IdIleGetir(int id)
        {
            using var context = new SiparisContext();
            return context.Set<Tentity>().Find(id);
        }
    }
}
