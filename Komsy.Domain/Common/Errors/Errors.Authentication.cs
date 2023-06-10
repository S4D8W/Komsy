using ErrorOr;

namespace Komsy.Domain.Common.Errors;

public static partial class Errors {

  public static class Authentication {

    public static Error InvalideCredentials => Error.Validation(
      code: "Auth.InvalideCredentials",
      description: "Invalid credentials");
  }
}
