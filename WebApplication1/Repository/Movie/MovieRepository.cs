using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly FilmIndustryDBContext _context;

        public MovieRepository(FilmIndustryDBContext context)
        {
            this._context = context;
        }

        public List<MovieViewModel> MovieIndexData()
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
            
            return data;
        }

        public List<SelectListItem> ListOfActors()
        {
            List<SelectListItem> ProducerData = _context.Producers.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            }).ToList();

            return ProducerData;
        }

        public List<SelectListItem> ListOfProducers()
        {
            List<SelectListItem> actorData = _context.Actors.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            }).ToList();

            return actorData;
        }

        public void CreateWithActors(ActorMovieCommand data)
        {
            if (data.Id > 0)
            {
                var fromDB = _context.Movies.FirstOrDefault(a => a.Id == data.Id);

                fromDB.Poster = data.Poster;
                fromDB.Name = data.Name;
                fromDB.Plot = data.Plot;
                fromDB.Poster = data.Poster;
                fromDB.ProducerId = data.ProducerId;

                _context.Movies.Update(fromDB);

                var movieActors = _context.MovieActor.Where(a => a.MovieId.Equals(data.Id)).ToList();

                _context.MovieActor.RemoveRange(movieActors);

                var addMovieActior = new List<MovieActor>();
                foreach (var item in data.ActorIds)
                {
                    var movieActor = new MovieActor()
                    {
                        ActorId = item,
                        MovieId = fromDB.Id
                    };
                    addMovieActior.Add(movieActor);
                }

                _context.MovieActor.AddRange(addMovieActior);

                _context.SaveChanges();
            }
            else
            {
                Movie movie = new Movie()
                {
                    Name = data.Name,
                    Plot = data.Plot,
                    Poster = data.Poster,
                    ProducerId = data.ProducerId,
                };

                movie.MovieActors = new List<MovieActor>();
                foreach (var item in data.ActorIds)
                {
                    var movieActor = new MovieActor()
                    {
                        ActorId = item,
                        MovieId = movie.Id
                    };
                    movie.MovieActors.Add(movieActor);
                }

                _context.Movies.Add(movie);
                _context.SaveChanges();

            }
        }
    }
}
