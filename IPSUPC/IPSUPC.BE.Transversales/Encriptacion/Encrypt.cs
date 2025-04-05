using System.Security.Cryptography;
using System.Text;

namespace IPSUPC.BE.Transversales;

public class Encrypt
{
    public static string EncriptarContrasena(string input)
    {
        MD5 mdHash = MD5.Create();

        byte[] data = mdHash.ComputeHash(Encoding.UTF8.GetBytes(input));
        StringBuilder sBuilder = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }
        return sBuilder.ToString();
    }

}