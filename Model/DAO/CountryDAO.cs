using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class CountryDAO
    {
        PerfumeStoreDbContext db = null;
        public CountryDAO()
        {
            db = new PerfumeStoreDbContext();
        }

        public int Insert(country country)
        {
            db.countries.Add(country);
            db.SaveChanges();
            return country.country_id;
        }

        public IEnumerable<country> ListAll()
        {
            return db.countries.ToList();
        }
    }
}
