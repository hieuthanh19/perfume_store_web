using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;


namespace Model.DAO
{
    class ValidateImageAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            var file = value as HttpPostedFileBase;
            if (file == null)
            {
                return false;
            }
            try
            {
                
                using (var img = Image.FromStream(file.InputStream))
                {
                    return img.RawFormat.Equals(ImageFormat.Png);
                }
            }
            catch { }
            return false;
        }
    }
}
