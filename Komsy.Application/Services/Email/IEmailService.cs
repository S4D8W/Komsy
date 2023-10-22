namespace Komsy.Application.Services.Email;

public interface IEmailService {

	Task SendResetPasswordEmailAsync(string email, string password);
}
