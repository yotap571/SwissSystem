using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SwissSystem.Models;
using SwissSystem.Utils;

namespace SwissSystem.Services
{
    public class MasterService
    {
        private IMongoCollection<TblConfigs> _configs;

        public MasterService()
        {
            var db = new ConnectDb().Connect();
            _configs = db.GetCollection<TblConfigs>("tblconfigs");
        }

        public List<TblConfigs> GetConfigs(string cfgType, string cfgName)
        {
            return _configs.Find(x => x.cfg_type == cfgType && x.cfg_name == cfgName).ToList();
        }

        public TblConfigs GetConfig(string id)
        {
            return _configs.Find(x => x._id.ToString() == id).FirstOrDefault();
        }

        public TblConfigs CreateConfig(TblConfigs config)
        {
            _configs.InsertOne(config);
            return config;
        }

        public void UpdateConfig(string id, TblConfigs config)
        {
            _configs.ReplaceOne(x => x._id.ToString() == id, config);
        }

        public void DeleteConfig(string id)
        {
            _configs.DeleteOne(x => x._id.ToString() == id);
        }
    }
}