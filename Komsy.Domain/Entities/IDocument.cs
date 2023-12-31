﻿

using MongoDB.Bson;

namespace Komsy.Domain.Entities {
  public interface IDocument {

    ObjectId Id { get; set; }
    DateTime CreatedAt { get; }
    string UId { get; }
  }


  public abstract class Document : IDocument {

    public ObjectId Id { get; set; }
    public DateTime CreatedAt => Id.CreationTime;
    public string UId => Id.ToString();
  }
}
