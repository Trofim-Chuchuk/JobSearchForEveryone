using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Resunet.BL; 

public class Encrypt:IEncrypt {

    public string HashPassword(string password, string salt){
        return Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password,
            Encoding.ASCII.GetBytes(salt),
            KeyDerivationPrf.HMACSHA512,
            5000,
            64));
    }
}