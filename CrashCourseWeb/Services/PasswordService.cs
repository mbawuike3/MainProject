using System.Security.Cryptography;
using System.Text;

namespace CrashCourseWeb.Services
{
    public interface IPasswordService
    {
        string Encoder(string password);
    }

    public class PasswordService : IPasswordService
    {
        public string Encoder(string password)
        {
            var buffer = Encoding.UTF8.GetBytes(password);
            var sha256 = new SHA256Managed();
            var hash = sha256.ComputeHash(buffer);
            var encodedHash = Convert.ToBase64String(hash);
            return encodedHash;
        }
    }
}
