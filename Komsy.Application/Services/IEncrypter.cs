namespace Komsy.Application.Services {
  public interface IEncrypter {

    string GetSalt(string value);
    string GetHash(string value, string salt);

  }
}
