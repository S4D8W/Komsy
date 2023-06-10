using Komsy.Application.Common.Interfaces.Services;

namespace MealPlanner.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider {
  public DateTime UtcNow => DateTime.UtcNow;
}
