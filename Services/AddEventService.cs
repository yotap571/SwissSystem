using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SwissSystem.Models;
using SwissSystem.Utils;

namespace SwissSystem.Services
{
    public class EventService
    {
        private IMongoCollection<Events> _events;

        public EventService()
        {
            var db = new ConnectDb().Connect();
            _events = db.GetCollection<Events>("events");
        }

        public List<Events> GetEvents(string? year)
        {
            if (year == null)
            {
                throw new ArgumentNullException(nameof(year));
            }

            return _events.Find(x => x.event_date.Contains(year)).ToList();
        }

        public Events GetEvent(string id)
        {
            return _events.Find(x => x._id.ToString() == id).FirstOrDefault();
        }

        public Events CreateEvent(Events evt)
        {
            _events.InsertOne(evt);
            return evt;
        }

        public void UpdateEvent(string id, Events evt)
        {
            _events.ReplaceOne(x => x._id.ToString() == id, evt);
        }

        public void DeleteEvent(string id)
        {
            _events.DeleteOne(x => x._id.ToString() == id);
        }
    }
}