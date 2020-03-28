using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace PerfumeStore_BrandNCountry.Common
{
    public  class CommonUtils
    {
       

        /// <summary>
        /// Create a select list of product statuses
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SelectListItem> getProductStatusList()
        {
            List<SelectListItem> statusList = new List<SelectListItem>();
            statusList.Add(new SelectListItem
            {
                Text = "Locked",
                Value = "0",

            });
            statusList.Add(new SelectListItem
            {
                Text = "In stock",
                Value = "1",

            });
            statusList.Add(new SelectListItem
            {
                Text = "Out of stock",
                Value = "2",

            });

            return statusList.AsEnumerable();
        }
        /// <summary>
        /// Get product status from database and get status text
        /// </summary>        
        /// <param name="productStatus"></param>
        /// <returns></returns>
        public string getProductStatusTextFromProductStatusList(int? productStatus)
        {
            string statusText = null;
            IEnumerable<SelectListItem> productStatusList = getProductStatusList();
            foreach (var item in productStatusList)
            {
               
                if (int.Parse(item.Value) == productStatus)
                {
                    statusText = item.Text;
                    break;
                }
                
            }
            return statusText;
        }

       
    }
}