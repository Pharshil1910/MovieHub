using MediatR;
using WebApplication1.Models;

namespace WebApplication1.Commands
{
    public class UpdateActorCommand : IRequest<int>
    {
        public UpdateActorCommand(int id, string name, Gender gender, DateTime? dob, string? bio) 
        {
            Id = id;
            Name = name;
            Gender = gender;
            Bio = bio;
            Dob = dob;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string? Bio { get; set; }
    }
}
