using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SwissSystem.Models
{

    public class tblconfigs
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string cfg_type { get; set; }
        public string cfg_name { get; set; }
        public string cfg_display { get; set; }
        public string cfg_val1 { get; set; }
        public string cfg_val2 { get; set; }
        public string cfg_val3 { get; set; }
        public string cfg_val4 { get; set; }
        public string cfg_flag { get; set; }
        public int __v { get; set; }
    }



}

