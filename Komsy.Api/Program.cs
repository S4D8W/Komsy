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

if (app.Environment.IsDevelopment()) {
  //pApplication.UseSwagger();
  //pApplication.UseSwaggerUI();
  app.UseCors("DevCorsPolicy");
}
app.UseExceptionHandler("/error");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();



