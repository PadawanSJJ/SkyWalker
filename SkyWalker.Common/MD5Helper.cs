using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SkyWalker.Common
{
    public static class MD5Helper
    {
        public static string MD5Encrypt32(string pwd)
        {
            var md5 = MD5.Create();
            var bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(pwd));
            var strings = bytes.Select(s => s.ToString("X"));
            return string.Join(string.Empty, strings);
        }
    }
}
