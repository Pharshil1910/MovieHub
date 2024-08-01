using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table(nameof(Movie), Schema = "dbo")]
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string? Name { get; set; }
        
        [Required]
        [DataType(DataType.Text)]
        public string? Plot { get; set; }

        [Required]
        public string? Poster { get; set; }
        [Required]
        public int ProducerId { get; set; }

        [ForeignKey(nameof(ProducerId))]
        public virtual Producer Producer { get; set; }

        public virtual List<MovieActor> MovieActors { get; set; }
    }
}
