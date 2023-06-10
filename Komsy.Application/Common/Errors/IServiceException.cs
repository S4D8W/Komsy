using System.Net;
namespace Komsy.Application.Common.Errors;

public interface IServiceException {

  public HttpStatusCode StatusCode { get; }
  public string Message { get; }
}
