using Model.EF;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Web;

namespace Model.DAO
{
    public class ProductNProductImgDAO
    {
        PerfumeStoreDbContext db = null;
        public product Product { get; set; }
        public productImg productImg { get; set; }       
        public HttpPostedFileBase imgFile { get; set; }

        public ProductNProductImgDAO()
        {
            db = new PerfumeStoreDbContext();
        }

        public bool checkIsImage(string fileName)
        {
            var r = new Regex(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$");
            return r.IsMatch(fileName);
        }

      


    }
}
