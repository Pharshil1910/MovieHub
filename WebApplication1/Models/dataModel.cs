using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class dataModel
    {
        public int Id { get; set; }

        public List<SelectListItem> ActorList { get; set; }
    }

    public class MovieViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Plot { get; set; }
        public string? Poster { get; set; }
        public string ProducerName { get; set; }

        public int ProducerId { get; set; }
    }

    public class MovieWithActorsModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Plot { get; set; }
        public string? Poster { get; set; }
        public string ProducerName { get; set; }

        public int ProducerId { get; set; }
        public List<string> ActorNames { get; set; }
    }

    public class SelectedActorsModel
    {
        public int Id { get; set; }
        public Boolean IsChecked { get; set; }
    }

    public class ActorMovieCommand
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Plot { get; set; }
        public string? Poster { get; set; }
        public int ProducerId { get; set; }
        public List<int> ActorIds { get; set; }
    }

    public class ActorsList 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string? Bio { get; set; }
    }
}
