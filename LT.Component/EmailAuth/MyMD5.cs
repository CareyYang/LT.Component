using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace LT.Component.EmailAuth
{
    /// <summary>
    /// Summary description for MyMD5.
    /// </summary>
    public class MyMD5
    {
        public static string GetMD5Hash(String input)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            //the GetBytes method returns byte array equavalent of a string
            byte[] res = md5.ComputeHash(Encoding.Default.GetBytes(input), 0, input.Length);
            char[] temp = new char[res.Length];
            //copy to a char array which can be passed to a String constructor
            System.Array.Copy(res, temp, res.Length);
            //return the result as a string
            return new String(temp);
        }

        public static string GetMD5HashHex(String input)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            //the GetBytes method returns byte array equavalent of a string
            byte[] res = md5.ComputeHash(Encoding.Default.GetBytes(input), 0, input.Length);

            String returnThis = res.Aggregate("", (current, t) => current + System.Uri.HexEscape((char)t));

            returnThis = returnThis.Replace("%", "");
            returnThis = returnThis.ToLower();

            return returnThis;
        }
    }
}
