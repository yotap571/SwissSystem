using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SwissSystem.Models
{

    public class Events
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; } // รหัสงาน
        public string? event_name { get; set; } // ชื่องาน
        public string? event_passcode { get; set; } // รหัสผ่านการเข้าร่วม
        public string? event_type { get; set; } // ประเภทการแข่งขัน
        public string? event_date { get; set; } // วันที่จัดงาน
        public string? event_round { get; set; } // รอบการแข่งขัน
        public string? event_remark { get; set; } // หมายเหตุ
        public string? event_location { get; set; } // สถานที่จัดงาน
        public int event_team { get; set; }  // จำนวนทีมที่เข้าร่วม
        public string? event_status { get; set; } // สถานะการจัดงาน
        public string? create_date { get; set; }
        public string? create_by { get; set; }
        public string? update_date { get; set; }
        public string? update_by { get; set; }

    }
}