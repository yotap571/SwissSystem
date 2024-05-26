// fuction connectdb : connect to mongo database

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace SwissSystem.Utils
{
    public class connectdb
    {
        public IMongoDatabase db;
        public connectdb()
        {
            var client = new MongoClient("mongodb://localhost:27017/");
            db = client.GetDatabase("competition");
        }
    }
}