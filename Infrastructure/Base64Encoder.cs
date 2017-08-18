
using System;
using System.Text;

namespace coreauthtest.Infrastructure
{
    public class Base64Encoder{
        public static string Encode(byte[] encodedBytes ){
            return Convert.ToBase64String(encodedBytes);
        }

        public static byte[] Decode(string src){
            return Convert.FromBase64String(Convert.ToBase64String(Encoding.Unicode.GetBytes(src)));
        }
    }
}