using MediatR;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.Commands
{
    public class CreateProducerCommand : IRequest<Producer>
    {
        public CreateProducerCommand(string name, Gender gender, DateTime? dob, string? bio) 
        {
            Name = name;
            Gender = gender;
            Bio = bio;
            Dob = dob;
        }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string? Bio { get; set; }
    }
}
