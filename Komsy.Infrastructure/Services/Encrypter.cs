using System.Security.Cryptography;
using Komsy.Application.Services;

namespace Komsy.Infrastructure.Services;

public class Encrypter : IEncrypter {

  private static readonly int SaltSize = 40;
  private static readonly int DeriveBytesIterationsCount = 10000;

  public string GetHash(string value, string salt) {

    if (string.IsNullOrWhiteSpace(value)) {
      throw new ArgumentException("Can not generate hash from an empty value.", nameof(value));
    }

    if (string.IsNullOrEmpty(salt)) {
      throw new ArgumentException("salt an empty value.", nameof(salt));
    }

    var pbkdf2 = new Rfc2898DeriveBytes(value, GetBytes(salt), DeriveBytesIterationsCount);
    var hash = Convert.ToBase64String(pbkdf2.GetBytes(SaltSize));

    return hash;

  }

  public string GetSalt(string value) {

    if (string.IsNullOrWhiteSpace(value)) {
      throw new ArgumentException("Can not generate salt from an empty value.", nameof(value));
    }

    var random = new Random();
    var saltBytes = new byte[SaltSize];
    var rng = RandomNumberGenerator.Create();
    rng.GetBytes(saltBytes);

    return Convert.ToBase64String(saltBytes);

  }


  private static byte[] GetBytes(string value) {

    var bytes = new byte[value.Length * sizeof(char)];
    Buffer.BlockCopy(value.ToArray(), 0, bytes, 0, bytes.Length);

    return bytes;

  }
}
