namespace Komsy.Application.Services.Email;

public interface IEmailService {

  Task SendResetPasswordAsync(string email, string password);

}
