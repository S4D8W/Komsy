using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komsy.Infrastructure.Persistence {

  public interface IMongoDbSettings {
    public string DatabaseName { get; init; }
    public string ConnectionString { get; init; }
  }

  public class MongoDbSettings : IMongoDbSettings {

    public static string SectionName = "MongoDbSettings";
    public string DatabaseName { get; init; } = null!;
    public string ConnectionString { get; init; } = null!;

  }


}
