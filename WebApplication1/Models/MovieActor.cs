using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table(nameof(MovieActor), Schema = "dbo")]
    public class MovieActor
    {
        public int Id { get; set; }

        public int ActorId { get; set; }

        public int MovieId { get; set; }

        [ForeignKey(nameof(ActorId))]
        public virtual Actor Actor { get; set; }

        [ForeignKey(nameof(MovieId))]
        public virtual Movie Movie { get; set; }
    }
}
