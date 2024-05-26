using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SwissSystem.Models;
using SwissSystem.Utils;
using MongoDB.Driver;
using System.Diagnostics;
using Newtonsoft.Json;

namespace SwissSystem.Services
{
    public class MasterService
    {
        
        public List<tblconfigs> getddl(string cfg_type, string cfg_name)
        {
             connectdb conn = new connectdb();
            try
            {
              if (conn.db != null)
                {
                    var collection = conn.db.GetCollection<tblconfigs>("tblconfigs");
                    if (collection != null)
                    {
                        var result = collection.Find(x => x.cfg_type == cfg_type && x.cfg_name == cfg_name && x.cfg_flag == "Y").ToList();
                        return result;
                    }
                }
            } 
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
            return null;
         
        }

        
        public List<tblconfigs> getddlmock(string cfg_type,string cfg_name)
        {
            var json = System.IO.File.ReadAllText("mockdata/ddl.json");
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<tblconfigs>>(json);


            return result.Where(x => x.cfg_type == cfg_type && x.cfg_name == cfg_name).ToList();
        }
    }


}