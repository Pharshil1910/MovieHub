using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IMovieRepository
    {
        public List<MovieViewModel> MovieIndexData();

        public List<SelectListItem> ListOfActors();

        public List<SelectListItem> ListOfProducers();

        public void CreateWithActors(ActorMovieCommand data);
    }
}
