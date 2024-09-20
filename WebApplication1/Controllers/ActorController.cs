using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Commands;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorRepository _actorRepository = null;
        private IMediator _mediator;

        public ActorController(IActorRepository _actorRepository, IMediator mediator)
        {
            this._actorRepository = _actorRepository;
            this._mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _mediator.Send(new GetActorListsQuery());
            return View(data);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var CommandData = new GetActorByIdQuery() { Id = id };

            var actorData = await _mediator.Send(CommandData);
            return View(actorData);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Actor data)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(new CreateActorCommand(data.Name, data.Gender, data.Dob, data.Bio));
                return RedirectToAction("Index", "Actor");
            }
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var CommandData = new GetActorByIdQuery() { Id = id };
            var actorData = await _mediator.Send(CommandData);

            return View(actorData);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Actor data)
        {
            if (id != data.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _mediator.Send(new UpdateActorCommand(id, data.Name, data.Gender, data.Dob, data.Bio));
                return RedirectToAction("Index", "Actor");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var CommandData = new GetActorByIdQuery() { Id = id };

            var actorData = await _mediator.Send(CommandData);
            return View(actorData);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            if (id != null && id != 0)
            {
                await _mediator.Send(new DeleteActorQuery() { Id = id });
                return RedirectToAction("Index", "Actor");
            } 
            else
            {
                return NotFound();
            }
            
        }
    }
}
