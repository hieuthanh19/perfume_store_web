using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    public class UserDAO
    {
        PerfumeStoreDbContext db = null;
        public UserDAO()
        {
            db = new PerfumeStoreDbContext();
        }
        public int Insert (user newUser)
        {
            db.users.Add(newUser);
            db.SaveChanges();
            return newUser.user_id;
        }
        /// <summary>
        /// Get MD5 hash
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public string EncodeMD5(string original)
        {
            var md5 = new MD5CryptoServiceProvider();
            var originalBytes = Encoding.Default.GetBytes(original);
            var encodedBytes = md5.ComputeHash(originalBytes);

            return BitConverter.ToString(encodedBytes);
        }
        /// <summary>
        /// Check log in info and return result
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login (string username, string password)
        {
            //MD5 encode
            var md5 = new MD5CryptoServiceProvider();
            var originalBytes = Encoding.Default.GetBytes(password);
            var encodedBytes = md5.ComputeHash(originalBytes);

            string encodedPassword = BitConverter.ToString(encodedBytes);
            var result = db.users.Count((x) => x.user_username == username && x.user_password == encodedPassword);
            if (result > 0)
                return true;
            else
                return false;

        }

        /// <summary>
        /// Get User by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public user GetByUsername(string username)
        {
            return db.users.SingleOrDefault(x => x.user_username == username);
        }
    }
}
