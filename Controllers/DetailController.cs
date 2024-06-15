using Microsoft.AspNetCore.Mvc;
using SwissSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SwissSystem.Utils;
using SwissSystem.Services;
using MongoDB.Driver;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Name
{
    public class DetailController : Controller
    {
        private readonly ILogger<DetailController> _logger;
        private readonly IMongoCollection<Events> _events;

        public DetailController(ILogger<DetailController> logger,IMongoClient client)
        {
            var database = client.GetDatabase("competition");
            _events = database.GetCollection<Events>("events");
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
    }
    
}