using Microsoft.AspNetCore.Mvc;
using SwissSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SwissSystem.Utils;
using MongoDB.Driver;
using System.Diagnostics;
using Newtonsoft.Json;


namespace Name
{
    public class DetailController : Controller
    {
        private readonly ILogger<DetailController>? _logger;
        private readonly IMongoCollection<Events>? _events;
        private readonly IMongoCollection<Teams>? _teams;
        public DetailController(ILogger<DetailController> logger,IMongoClient client)
        {
            var database = client.GetDatabase("competition");
            _events = database.GetCollection<Events>("events");
            _teams = database.GetCollection<Teams>("teams");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EventById(string id)
        {
            var evt = _events.Find(x => x._id.ToString() == id).FirstOrDefault();
            return View(evt);
        }
        public JsonResult GetTeams(string event_id)
        {
            var teams = _teams.Find(x => x.team_event_id == event_id).ToList();
            return new JsonResult(teams);
        }
        public JsonResult RamdomTeam(List<string> teams)
        {
            // var teams = _teams.Find(x => x.team_event_id == event_id).ToList().Select(x => x.team_name).ToList();
            var teamList = TeamShuffle.Shuffle(teams);

            return new JsonResult(teamList);
        }

    }
    
}