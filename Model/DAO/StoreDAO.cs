using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using X.PagedList;


namespace Model.DAO
{
    public class StoreDAO
    {

        public IPagedList<product> sortedProductList { get; set; }
        public brand Brand { get; set; }
        public category Category { get; set; }
        PerfumeStoreDbContext db = null;
        public int? pageNum { get; set; } = 1;
        public string search { get; set; } = "";
        public int? sort { get; set; } = 0;
        public int? categoryId { get; set; } = 0;
        public int? brandId { get; set; } = 0;
        public int? volumeStart { get; set; } = 1;
        public int? volumeEnd { get; set; } = 1000;
        public int? pageSize { get; set; } = 12;

        public StoreDAO()
        {
            db = new PerfumeStoreDbContext();
        }

        public StoreDAO(int? pageNum, string search, int? sort, int? categoryId, int? brandId, int? volumeStart, int? volumeEnd, int? productsPerPage)
        {
            this.db = new PerfumeStoreDbContext();
            if (pageNum != null)
                this.pageNum = pageNum;
            if (search != null)
                this.search = search;
            if (sort != null)
                this.sort = sort;
            if (categoryId != null)
                this.categoryId = categoryId;
            if (brandId != null)
                this.brandId = brandId;
            if (volumeStart != null)
                this.volumeStart = volumeStart;
            if (volumeEnd != null)
                this.volumeEnd = volumeEnd;
            if (productsPerPage != null)
                this.pageSize = (int)productsPerPage;
            this.sortedProductList = getSortedProductList();
        }

        /// <summary>
        /// Get product list from parameters
        /// </summary>
        /// <returns></returns>
        public X.PagedList.IPagedList<product> getSortedProductList()
        {
            //get all products
            var productList = db.products.Where(p => p.product_status == 1).Include(p => p.brand).Include(p => p.category).Include(p => p.productImgs);
            if (!search.Equals(""))
            {
                productList = productList.Where(p => p.product_name.Contains(search));
            }
            if (categoryId != 0)
            {
                productList = productList.Where(p => p.category_id == categoryId);
            }
            if (brandId != 0)
            {
                productList = productList.Where(p => p.brand_id == brandId);
            }

            //get base on volume
            productList = productList.Where(p => p.product_volume >= volumeStart && p.product_volume <= volumeEnd);
            //get sort order
            switch (sort)
            {
                case 1:
                    productList = productList.OrderBy(p => p.product_currentPrice);
                    break;
                case 2:
                    productList = productList.OrderByDescending(p => p.product_currentPrice);
                    break;
                default:
                    productList = productList.OrderBy(p => p.product_id);
                    break;
            }

            return productList.ToPagedList((int)pageNum, (int)pageSize);

        }


    }
}
