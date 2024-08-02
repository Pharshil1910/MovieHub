using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    public class MovieController : Controller
    {
        private readonly FilmIndustryDBContext _context;
        private readonly IMovieRepository _movieRepository = null;

        public MovieController(FilmIndustryDBContext context, IMovieRepository _movieRepository)
        {
            this._context = context;
            this._movieRepository = _movieRepository;
        }
        public IActionResult Index()
        {
            var data = (from p in _context.Producers
                                   join e in _context.Movies on p.Id equals e.ProducerId
                                   select new MovieViewModel
                                   {
                                       Id = e.Id,
                                       Name = e.Name,
                                       Plot = e.Plot,
                                       Poster = e.Poster,
                                       ProducerName = p.Name
                                   }).ToList();
            ViewBag.Data = data;
            return View();
        }

        public IActionResult Create()
        {
            List<SelectListItem> ProducerData = _context.Producers.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            }).ToList();

            List<SelectListItem> actorData = _context.Actors.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            }).ToList();

            ViewBag.ProducerId = ProducerData;
            ViewBag.ActorList = actorData;

            return View();
        }

        [HttpPost("Movie/CreateWithActors")]
        public IActionResult CreateWithActors([FromBody] ActorMovieCommand data)
        {
            if(data != null)
            {
                if (data.Id > 0)
                {
                    _movieRepository.CreateWithActors(data);
                    //return StatusCode(200, new { message = "Success" });
                    return RedirectToAction("Index", "Movie");
                }
                else
                {
                    _movieRepository.CreateWithActors(data);

                    //return StatusCode(200, new { message = "Success" }); 
                    return RedirectToAction("Index", "Movie");
                }
            } 
            else
            {
                // Return a bad request status if the data is not valid
                return StatusCode(400, new { message = "Invalid data" }); // Bad Request
            }

        }

        public IActionResult Details(int? id)
        {
            var DetailData = (from p in _context.Producers
                              join e in _context.Movies on p.Id equals e.ProducerId
                              select new MovieViewModel
                              {
                                  Id = e.Id,
                                  Name = e.Name,
                                  Plot = e.Plot,
                                  Poster = e.Poster,
                                  ProducerName = p.Name
                              }).ToList();

            var movieWithActors = (from m in _context.Movies
                                   where m.Id == id
                                   join p in _context.Producers on m.ProducerId equals p.Id
                                   select new MovieWithActorsModel
                                   {
                                       Id = m.Id,
                                       Name = m.Name,
                                       Plot = m.Plot,
                                       Poster = m.Poster,
                                       ProducerName = p.Name,
                                       ActorNames = (from ma in _context.MovieActor
                                                     join a in _context.Actors on ma.ActorId equals a.Id
                                                     where ma.MovieId == id
                                                     select a.Name).ToList()
                                   }).FirstOrDefault();

            //ViewBag.Data = data;
            var data = DetailData.FirstOrDefault(x => x.Id == id);
            ViewBag.Data = movieWithActors;
            return View();
        }

        public IActionResult Edit(int? id)
        {
            var EditViewData = _context.Movies.Find(id);

            var SelectedActorList = (from ma in _context.MovieActor
                                     where ma.MovieId == id
                                     select new SelectedActorsModel
                                     {
                                         Id = ma.ActorId,
                                         IsChecked = false
                                     }).ToList();

            List<SelectListItem> actorData = _context.Actors.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
                Selected = false
            }).ToList();

            List<SelectListItem> ProducerData = _context.Producers.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            }).ToList();

            foreach (var item in actorData)
            {
                foreach (var item1 in SelectedActorList)
                {
                    if (item.Value == item1.Id.ToString())
                    {
                        item.Selected = true;
                        continue;
                    }
                }
            }

            ViewBag.ProducerId = ProducerData;
            ViewBag.ActorList = actorData;

            //var data = DetailData.FirstOrDefault(x => x.Id == id);
            ViewBag.movieWithActors = SelectedActorList;
            return View(EditViewData);
        }

        public IActionResult Delete(int? id)
        {
        if(id != null) { }
        var movieWithActors = (from m in _context.Movies
                                where m.Id == id
                                join p in _context.Producers on m.ProducerId equals p.Id
                                select new MovieWithActorsModel
                                {
                                    Id = m.Id,
                                    Name = m.Name,
                                    Plot = m.Plot,
                                    Poster = m.Poster,
                                    ProducerName = p.Name,
                                    ProducerId = p.Id,
                                    ActorNames = (from ma in _context.MovieActor
                                                    join a in _context.Actors on ma.ActorId equals a.Id
                                                    where ma.MovieId == id
                                                    select a.Name ).ToList()
                                }).FirstOrDefault();

        ViewBag.Data = movieWithActors;
        return View();

        }

        [HttpPost("Movie/DeleteMovie")]
        public IActionResult DeleteMovie([FromBody] ActorMovieCommand data)
        {
            if(data != null || data.Id != null)
            {
                var fromDB = _context.Movies.FirstOrDefault(a => a.Id == data.Id);
            
                fromDB.Poster = data.Poster;
                fromDB.Name = data.Name;
                fromDB.Plot = data.Plot;
                fromDB.Poster = data.Poster;
                fromDB.ProducerId = data.ProducerId;

                _context.Movies.Remove(fromDB);

                var movieActors = _context.MovieActor.Where(a => a.MovieId.Equals(data.Id)).ToList();

                _context.MovieActor.RemoveRange(movieActors);
                _context.SaveChanges();

                return RedirectToAction("Index", "Movie");
            }
            return StatusCode(400, new { message = "Invalid data" }); // Bad Request
        }
    }

}
