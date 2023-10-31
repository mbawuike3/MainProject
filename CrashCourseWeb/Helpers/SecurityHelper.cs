using System.Security.Cryptography;

namespace CrashCourseWeb.Helpers;

public static class SecurityHelper
{
    static string key = "yZCr0pi8PUFK0mSJ";
    public static string Encrypt(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentNullException("password cannot be null or empty");
        }
        var plainTextBytes = GetBytes(input);
        using(var aes = Aes.Create())
        {
            aes.Key = GetBytes(key);
            aes.IV = GetBytes(key);
            using(var memoryStream = new MemoryStream())
            {
                using(var cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    return Convert.ToBase64String(memoryStream.ToArray());
                }
            }
        }

    }
    public static string Decrypt(this string input)
    {
        string plainText;
        var cipherTextBytes = Convert.FromBase64String(input);
        using(var aes = Aes.Create())
        {
            aes.Key = GetBytes(key);
            aes.IV = GetBytes(key);
            using( var memoryStream = new MemoryStream(cipherTextBytes))
            {
                using(var cryptostream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    using(StreamReader streamReader = new StreamReader(cryptostream))
                    {
                        plainText = streamReader.ReadToEnd();
                    }
                }
            }
        }
        return plainText;
    }
    private static byte[] GetBytes(string input)
    {
        return System.Text.Encoding.UTF8.GetBytes(input);
    }
}
