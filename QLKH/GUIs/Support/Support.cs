using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace GUIs.Support
{
    public class Support
    {
        public static string InTrang(int total, int sotrang, int size)
        {
            int tongsotrang = (int)(total / size);
            if (tongsotrang * size < total)
            {
                tongsotrang++;
            }
            var html = "";
            for (int i = 1; i <= tongsotrang; i++)
            {
                if (sotrang == i)
                {
                    html += "<a href='javascript:void(0)'>" + i + "</a>";
                }
                else
                {
                    html += "<a href='javascript:void(0)' onclick='goto(" + i + ")'>" + i + "</a>";
                }
            }

            return html;
        }
        public static string HashSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();

                foreach (byte b in hashBytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}