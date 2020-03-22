using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PerfumeStore_BrandNCountry.Common
{
    [Serializable]
    public class UserLogin
    {
        public int userId { get; set; }
        public string username { get; set; }
    }
}