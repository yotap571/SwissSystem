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

        public IActionResult AddEvent()
        {
            MasterService masterService = new MasterService();
            var ddltype = masterService.getddl("ddl", "TYPE");

            // ddltype = ddltype.OrderBy(x => x.cfg_val1).ToList();

            ddltype.Insert(0, new tblconfigs { cfg_val1 = "0", cfg_display = "----กรุณาเลือก----" });


            ViewBag.ddltype = ddltype;
            return View();
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
