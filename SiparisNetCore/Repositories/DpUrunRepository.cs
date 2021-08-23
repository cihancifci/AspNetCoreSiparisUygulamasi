using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using SiparisNetCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiparisNetCore.Repositories
{
    public class DpUrunRepository
    {
        public List<Urun> GetirHepsi()
        {
            using var connection = new SqlConnection("server = DESKTOP-RDITVOK\\CIHAN; database=Siparis; integrated security=true;");

            return connection.GetAll<Urun>().ToList();
        }
    }
}
