using Komsy.Api;
using Komsy.Application;
using Komsy.Infrastructure;

var builder = WebApplication.CreateBuilder(args); {

  builder.Services
  .AddAPresentation()
  .AddApplication()
  .AddInfrastructure(builder.Configuration);
}


var app = builder.Build();

app.UseExceptionHandler("/error");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();



