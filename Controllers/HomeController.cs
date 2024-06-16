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
using ExcelDataReader;
using System.IO;
using System.Text;

namespace SwissSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IMongoCollection<TblConfigs> _configs;
        private readonly IMongoCollection<Events> _events;
        private readonly IMongoCollection<Teams> _teams;


        public HomeController(ILogger<HomeController> logger,IMongoClient client)
        {
            _logger = logger;
            var database = client.GetDatabase("competition");
            _events = database.GetCollection<Events>("events");
            _configs = database.GetCollection<TblConfigs>("tblconfigs");
            _teams = database.GetCollection<Teams>("teams");
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult AddTeams() { 
           return View();
        }

        public IActionResult AddEvent()
        {
           var ddltype = _configs.Find(x => x.cfg_type == "ddl" && x.cfg_name == "TYPE").ToList();    

            ddltype.Insert(0, new TblConfigs { cfg_val1 = "0", cfg_display = "----กรุณาเลือก----" });
            ViewBag.ddltype = ddltype;

            // var ddlround = masterService.GetConfigs("ddl", "round");
            var ddlround = _configs.Find(x => x.cfg_type == "ddl" && x.cfg_name == "round").ToList();    
            ddlround.Insert(0, new TblConfigs { cfg_val1 = "0", cfg_display = "----กรุณาเลือก----" });
            ViewBag.ddlround = ddlround;


            return View();
        }

        public JsonResult GetEvent(string year)
        {
            List<Events> result = _events.Find(x => x.event_date.Contains(year)).ToList();
            return new JsonResult(result);
        }
       

        // from body to form
        [HttpPost]
        public IActionResult AddEvent([FromForm] Events ev)
        {
            _events.InsertOne(ev); // insert to database
            return RedirectToAction("Index");
            
        }

        [HttpPost]
        public JsonResult AddTeam(IFormFile bfile, string event_id)
        {
            var listTeams = new List<Teams>();

            using (var stream = bfile.OpenReadStream())
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        while (reader.Read()) // Each ROW
                        {
                            for (int column = 0; column < reader.FieldCount; column++)
                            {
                                    var team = new Teams
                                    {
                                        team_name = reader.GetValue(column).ToString(),
                                        team_event_id = event_id ,
                                        create_date = DateTime.Now,
                                        create_by = "admin",
                                    };
                                    _teams.InsertOne(team);
                                    listTeams.Add(team);
                                
                            }
                        }
                    }
                }

            _logger.LogInformation("Add Team Success", listTeams);
            return new JsonResult(listTeams);
        }

        

    
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
