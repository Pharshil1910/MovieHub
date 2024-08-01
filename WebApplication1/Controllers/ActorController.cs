using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ActorController : Controller
    {
        private readonly FilmIndustryDBContext ActorDb;

        public ActorController(FilmIndustryDBContext context)
        {
            this.ActorDb = context;
        }

        public IActionResult Index()
        {
           var data = ActorDb.Actors.ToList();
            return View(data);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var actorData = await ActorDb.Actors.FirstOrDefaultAsync(x => x.Id == id);
            return View(actorData);
        }

        public IActionResult Create()
        {
            var ActorData = ActorDb.Actors.ToList();
            ViewBag.ActorList = ActorData;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Actor data)
        {
            if (ModelState.IsValid)
            {
                await ActorDb.Actors.AddAsync(data);
                await ActorDb.SaveChangesAsync();
                return RedirectToAction("Index", "Actor");
            }
            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var actorData = await ActorDb.Actors.FindAsync(id);
            return View(actorData);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Actor data)
        {
            if (id != data.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                ActorDb.Actors.Update(data);
                await ActorDb.SaveChangesAsync();
                return RedirectToAction("Index", "Actor");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var actorData = await ActorDb.Actors.FirstOrDefaultAsync(x => x.Id == id);
            return View(actorData);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmation(int? id)
        {
            var actorData = await ActorDb.Actors.FindAsync(id);
            if (actorData == null)
            {
                return NotFound();
            }
            ActorDb.Actors.Remove(actorData);
            await ActorDb.SaveChangesAsync();
            return RedirectToAction("Index", "Actor");
        }
    }
}
