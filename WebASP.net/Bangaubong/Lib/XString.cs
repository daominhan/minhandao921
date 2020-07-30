namespace Bangaubong
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Web;

    public class XString
    {
        /// <summary>
        /// Mã hóa sang chuỗi dạng base 64
        /// </summary>
        /// <param name="s">Chuỗi cần mã hóa</param>
        /// <returns>Chuỗi đã mã hóa</returns>
        public String ToBase64( String s)
        {
            if (s != null)
            {
                var bytes = Encoding.UTF8.GetBytes(s);
                return Convert.ToBase64String(bytes);
            }
            return s;
        }

        /// <summary>
        /// Giải mã chuỗi mã hóa base 64
        /// </summary>
        /// <param name="s">Chuỗi đã mã hóa base 64</param>
        /// <returns>Chuỗi đã được giải mã</returns>
        public String FromBase64(String s)
        {
            if (s != null)
            {
                var bytes = Convert.FromBase64String(s);
                return Encoding.UTF8.GetString(bytes);
            }
            return s;
        }

        /// <summary>
        /// Mã hóa MD5
        /// </summary>
        /// <param name="s">Chuỗi cần mã hóa</param>
        /// <returns>Chuỗi base 64 chứa MD5</returns>
        public String ToMD5( String s)
        {
            var bytes = Encoding.UTF8.GetBytes(s);
            var hash = MD5.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        /// <summary>
        /// Chuyển đổi sang tiếng Việt không dấu
        /// </summary>
        /// <param name="s">Chuỗi cần chuyển đổi</param>
        /// <returns>Chuỗi tiếng Việt không dấu</returns>
        public String ToAscii(String s)
        {
            String[][] symbols = {
                                 new String[] { "[áàảãạăắằẳẵặâấầẩẫậ]", "a" },
                                 new String[] { "[đ]", "d" },
                                 new String[] { "[éèẻẽẹêếềểễệ]", "e" },
                                 new String[] { "[íìỉĩị]", "i" },
                                 new String[] { "[óòỏõọôốồổỗộơớờởỡợ]", "o" },
                                 new String[] { "[úùủũụưứừửữự]", "u" },
                                 new String[] { "[ýỳỷỹỵ]", "y" },
                                 new String[] { "[\\s'\";,]", "-" }
                             };
            s = s.ToLower();
            foreach (var ss in symbols)
            {
                s = Regex.Replace(s, ss[0], ss[1]);
            }
            return s;
        }
    }
}