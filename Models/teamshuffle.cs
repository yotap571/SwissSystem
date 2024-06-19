using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SwissSystem.Models
{
    public class PairTeam
    {
        public int No { get; set; }
        public string? Team1 { get; set; }
        public string? Team2 { get; set; }
    }
}