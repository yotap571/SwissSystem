using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SwissSystem.Models
{
    /// <summary>
    /// path: Models/teams.cs
    /// </summary>

    // Compare this snippet from Models/teams.cs
    public class Teams {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }
        public string? team_name { get; set; } // ชื่อทีม
        public string? team_passcode { get; set; } // รหัสผ่านการเข้าร่วม
        public string? team_leader { get; set; } // ผู้นำทีม
        public string? team_member { get; set; } // สมาชิกทีม
        public string? team_remark { get; set; } // หมายเหตุ
        public string? team_score { get; set; } // คะแนน
        public string? team_event_id { get; set; } // รหัสงาน
        public DateTime create_date { get; set; } // วันที่สร้าง
        public string? create_by { get; set; }
        public DateTime update_date { get; set; }
        public string? update_by { get; set; }
    }
}

/// <summary>
/// path: Models/TeamMatched.cs
/// </summary>

// Compare this snippet from Models/TeamMatched.cs
public class TeamRound1 {

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? _id { get; set; }
     public string? event_id { get; set; } // รหัสงาน
    public int round { get; set; } // รอบการแข่งขัน
    public string? stadium { get; set; } // สนามกีฬา
    public string? team1 { get; set; } // ทีมที่ 1
    public string? team2 { get; set; } // ทีมที่ 2
    public string? score1 { get; set; } // คะแนนทีมที่ 1
    public string? score2 { get; set; } // คะแนนทีมที่ 2
    public string? resultscore { get; set; } // ผลการแข่งขัน
    public string? remark { get; set; } // หมายเหตุ
    public int bhn { get; set; }
    public int fbhn { get; set; }
    public string? status { get; set; } // สถานะการแข่งขัน
    public DateTime create_date { get; set; } // วันที่สร้าง
    public string? create_by { get; set; } // สร้างโดย
    public DateTime update_date { get; set; } // วันที่แก้ไข
    public string? update_by { get; set; } // แก้ไขโดย
}



public class TeamRound2 {
    
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }
        public string? event_id { get; set; } // รหัสงาน
        public int round { get; set; } // รอบการแข่งขัน
        public string? stadium { get; set; } // สนามกีฬา
        public string? team1 { get; set; } // ทีมที่ 1
        public string? team2 { get; set; } // ทีมที่ 2
        public string? score1 { get; set; } // คะแนนทีมที่ 1
        public string? score2 { get; set; } // คะแนนทีมที่ 2
        public string? resultscore { get; set; } // ผลการแข่งขัน
        public string? remark { get; set; } // หมายเหตุ
        public int bhn { get; set; }
        public int fbhn { get; set; }
        public string? status { get; set; } // สถานะการแข่งขัน
        public DateTime create_date { get; set; } // วันที่สร้าง
        public string? create_by { get; set; } // สร้างโดย
        public DateTime update_date { get; set; } // วันที่แก้ไข
        public string? update_by { get; set; } // แก้ไขโดย
}


// Path: Models/TeamGroup.cs
// Compare this snippet from Models/teamgroup.cs:
public class TeamGroup {
    public string? team_id { get; set; } // รหัสทีม
    public string? group_id { get; set; }    // รหัสกลุ่ม
    public string? event_id { get; set; } // รหัสงาน
    public string? round { get; set; } // รอบการแข่งขัน
    public string? score { get; set; } // คะแนน
    public string? remark { get; set; } // หมายเหตุ
    public DateTime create_date { get; set; } // วันที่สร้าง
    public string? create_by { get; set; } // สร้างโดย
    public DateTime update_date { get; set; } //   วันที่แก้ไข
    public string? update_by { get; set; } // แก้ไขโดย
}