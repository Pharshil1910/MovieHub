using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorRepository _actorRepository = null;

        public ActorController(IActorRepository _actorRepository)
        {
            this._actorRepository = _actorRepository;
        }

        public IActionResult Index()
        {
            var data = _actorRepository.ActorLists();
            return View(data);
        }

        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var actorData = _actorRepository.GetActorById(id);
            return View(actorData);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Actor data)
        {
            if (ModelState.IsValid)
            {
                _actorRepository.AddActor(data);
                return RedirectToAction("Index", "Actor");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var actorData = _actorRepository.GetActorById(id);
            return View(actorData);
        }

        [HttpPost]
        public IActionResult Edit(int? id, Actor data)
        {
            if (id != data.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _actorRepository.UpdateActor(data);
                return RedirectToAction("Index", "Actor");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var actorData = _actorRepository.GetActorById(id);
            return View(actorData);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmation(int id)
        {
            if (id != null && id != 0)
            {
                _actorRepository.DeleteActor(id);
                return RedirectToAction("Index", "Actor");
            } 
            else
            {
                return NotFound();
            }
            
        }
    }
}
