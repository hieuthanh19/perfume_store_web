using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ProductDAO
    {
        PerfumeStoreDbContext db = null;
        public ProductDAO()
        {
            db = new PerfumeStoreDbContext();
        }
        public product GetProduct(int id)
        {
            return db.products.Find(id);
        }
    }
}
