using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    public class BrandDAO
    {
        PerfumeStoreDbContext db = null;
        public BrandDAO()
        {
            db = new PerfumeStoreDbContext();
        }

        public int Insert(brand newBrand)
        {
            db.brands.Add(newBrand);
            db.SaveChanges();
            return newBrand.brand_id;
        }

        public void Update(brand entity)
        {
            
        }

    }
}
