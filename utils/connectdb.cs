using MongoDB.Driver;
using System;

namespace SwissSystem.Utils
{
    public class ConnectDb
    {
        public IMongoDatabase Db { get; private set; }

        public IMongoDatabase Connect()
        {
            try
            {
                var client = new MongoClient("mongodb://localhost:27017/");
                Db = client.GetDatabase("competition");
                return Db;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting to the database: " + ex.Message);
                return null;
            }
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return Db.GetCollection<T>(collectionName);
        }
    }
}