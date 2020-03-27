using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PerfumeStore_BrandNCountry.Common
{
    public  class CommonUtils
    {
        /// <summary>
        /// Get Status ID for products
        /// </summary>
        /// <param name="statusName"></param>
        /// <returns></returns>
        public  int getProductStatusIdFromText(string statusName)
        {
            int statusId = -1;
            switch (statusName.ToLower())
            {
                case "locked":
                    statusId = 0;
                    break;
                case "in stock":
                    statusId = 1;
                    break;
                case "out of stock":
                    statusId = 2;
                    break;
                default:
                    break;
            }
            return statusId;
        }


        public int getStatusIdFromText(string statusName)
        {
            int statusId = -1;
            switch (statusName.ToLower())
            {
                case "locked":
                    statusId = 0;
                    break;
                case "active":
                    statusId = 1;
                    break;
                case "out of stock":
                    statusId = 2;
                    break;
                default:
                    break;
            }
            return statusId;
        }
    }
}