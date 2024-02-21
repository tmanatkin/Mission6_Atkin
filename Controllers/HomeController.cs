using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            // add viewbag to populate dropdown
            ViewBag.Categories = _context.Categories.ToList();

            return View(new Film());
        }

        // add film submission action
        [HttpPost]
        public IActionResult AddFilm(Film submission)
        {
            if (ModelState.IsValid)
            {
                // add record to database
                _context.Movies.Add(submission);
                _context.SaveChanges();

                // return submitted response in film added view
                return View("FilmAdded", submission);
            }
            else
            {
                // add viewbag to populate dropdown
                ViewBag.Categories = _context.Categories.ToList();

                return View(submission);
            }
        }

        public IActionResult ViewFilms()
        {
            // add viewbag so categories can display in table
            ViewBag.Categories = _context.Categories.ToList();

            var Movies = _context.Movies.ToList();
            return View(Movies);
        }

        public IActionResult EditFilm(int id)
        {
            // single record that is edited
            var record = _context.Movies
                .Single(x => x.MovieId == id);

            // add viewbag to populate dropdown
            ViewBag.Categories = _context.Categories.ToList();

            return View("AddFilm", record);
        }

        // edit film submission action
        [HttpPost]
        public IActionResult EditFilm(Film submission)
        {
            if (ModelState.IsValid)
            {
                // edit record in database
                _context.Update(submission);
                _context.SaveChanges();

                return RedirectToAction("ViewFilms");
            }
            else
            {
                // add viewbag to populate dropdown
                ViewBag.Categories = _context.Categories.ToList();

                return View("AddFilm", submission);
            }
        }

        public IActionResult DeleteFilm(int id)
        {
            var record = _context.Movies
                .Single(x => x.MovieId == id);

            return View("DeleteFilmConfirmation", record);
        }

        // delete film submission action
        [HttpPost]
        public IActionResult DeleteFilm(Film submission)
        {
            _context.Movies.Remove(submission);
            _context.SaveChanges();

            return RedirectToAction("ViewFilms");
        }
    }
}
