using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VeritabaniProjesi.Data;
using VeritabaniProjesi.Models;
using VeritabaniProjesi.ViewModels;

namespace VeritabaniProjesi.Controllers
{
    public class HomeController : Controller
    {
        private readonly BasicDataContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(BasicDataContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            HomeViewModel hwm = new HomeViewModel();
            var announcements = from t in _context.Announcements select t;
            hwm.Announcement = announcements.ToList();

            return View(hwm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
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
