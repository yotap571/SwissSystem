using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SwissSystem.Models
{

    public class events
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }{
        public string event_name { get; set; }
        public string event_passcode { get; set; }
        public string event_type { get; set; }
        public string event_date { get; set; }
        public string event_round { get; set; }
        public string event_remark { get; set; }
        public string event_location { get; set; }
    }
}