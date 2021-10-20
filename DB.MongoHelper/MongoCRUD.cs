using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace DB.MongoHelper
{
    public class MongoCRUD
    {
        IMongoDatabase db;

        public bool IsUpsert { get; private set; }

        public MongoCRUD(string database)
        {
            var client = new MongoClient();
            db = client.GetDatabase(database);
        }
            
        public void InsertObject<T>(string table, T record)
        {
            var collection = db.GetCollection<T>(table);
            collection.InsertOne(record);
        }

        public  List<T> LoadRecords<T>(string table)
        {
            var collection = db.GetCollection<T>(table);
            return collection.Find(new BsonDocument()).ToList();
        }

        public T LoadRecordById<T>(string table, Guid id, T record)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("id", id);

            return collection.Find(filter).First();
        }

        [Obsolete]
        public void UpsertRecord<T>(string table,Guid id, T record)
        {
            var collection = db.GetCollection<T>(table);
            var result = collection.ReplaceOne(
                new BsonDocument("_id",id),
                record,
                new UpdateOptions { IsUpsert = true });
        }

        public void DeleteRecord<T>(string table, Guid id, T record)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("id", id);
            collection.DeleteOne(filter);
        }

    }
}
