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
    public class AddEventService
    {
       
       // add event
        public bool addevent(tblconfigs tblconfigs)
        {
            connectdb conn = new connectdb();
            try
            {
                var collection = conn.db.GetCollection<tblconfigs>("tblconfigs");
                collection.InsertOne(tblconfigs);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                conn.db.Client.Cluster.Dispose();
            }
        }

    }
}