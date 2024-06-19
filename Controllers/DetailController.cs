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

        private readonly IMongoCollection<TeamRound1>? _teamRound1;
        public DetailController(ILogger<DetailController> logger,IMongoClient client)
        {
            var database = client.GetDatabase("competition");
            _events = database.GetCollection<Events>("events");
            _teams = database.GetCollection<Teams>("teams");
            _teamRound1 = database.GetCollection<TeamRound1>("teamRound1");
            _logger = logger;
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
            var teamList = TeamShuffle.Shuffle(teams);
            return new JsonResult(teamList);
        }

        public JsonResult GetTeamRound1(string event_id)
        {
            var teamRound1 = _teamRound1.Find(x => x.event_id == event_id).ToList();
            Console.WriteLine(JsonConvert.SerializeObject(teamRound1));
            return new JsonResult(teamRound1);
        }

        public JsonResult ConfirmRandom(List<PairTeam> pairTeam, string event_id)
        {
            foreach (var item in pairTeam)
            {
                var team = new TeamRound1();
                team.team1 = item.Team1;
                team.team2 = item.Team2;
                team.event_id = event_id;
                team.round = 1;
                team.create_date = DateTime.Now;
                team.create_by = "admin";

                _teamRound1.InsertOne(team);
            }
            return new JsonResult("Success");
        }

    }
    
}