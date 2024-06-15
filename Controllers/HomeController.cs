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

namespace SwissSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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

            MasterService masterService = new MasterService();
            var ddltype = masterService.GetConfigs("ddl", "TYPE");
            ddltype.Insert(0, new TblConfigs { cfg_val1 = "0", cfg_display = "----กรุณาเลือก----" });
            ViewBag.ddltype = ddltype;

            var ddlround = masterService.GetConfigs("ddl", "round");
            ddlround.Insert(0, new TblConfigs { cfg_val1 = "0", cfg_display = "----กรุณาเลือก----" });
            ViewBag.ddlround = ddlround;


            return View();
        }

        public JsonResult GetEvent(string year)
        {
            EventService addEventService = new EventService();
            List<Events> result = addEventService.GetEvents(year);
            return new JsonResult(result);
        }
       

        // from body to form
        [HttpPost]
        public IActionResult AddEvent([FromForm] Events ev)
        {
            EventService addEventService = new EventService();
            if(addEventService.CreateEvent(ev) != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("AddEvent");
            }
            // if (addEventService.CreateEvent(ev) > 0)
            // {
            //     return RedirectToAction("Index");
            // }
            // else
            // {
            //     return RedirectToAction("AddEvent");
            // }
            
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
