using Microsoft.AspNetCore.Mvc;
using Mission6.Models;
using System.Diagnostics;

namespace Mission6.Controllers
{
    public class HomeController : Controller
    {
        private FilmContext _context;
        public HomeController(FilmContext temp) 
        {
            _context = temp;
        }

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult AddFilm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFilm(Film response)
        {

            // set null values to empty strings
            if (response.Notes == null)
            {
                response.Notes = "";
            }
            if (response.LentTo == null)
            {
                response.LentTo = "";
            }

            // add record to database
            _context.films.Add(response);
            _context.SaveChanges();

            // return submitted response in film added view
            return View("FilmAdded", response);
        }
    }
}
