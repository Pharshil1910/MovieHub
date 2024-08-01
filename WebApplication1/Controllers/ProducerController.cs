using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProducerController : Controller
    {
        private readonly FilmIndustryDBContext ProducerDb;

        public ProducerController(FilmIndustryDBContext context)
        {
            ProducerDb = context;
        }
        public IActionResult Index()
        {
            var data = ProducerDb.Producers.ToList();
            return View(data);
        }

        public async Task<IActionResult> Details(int? id)
        {
            var data = await ProducerDb.Producers.FindAsync(id);
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Producer data)
        {
            await ProducerDb.Producers.AddAsync(data);
            await ProducerDb.SaveChangesAsync();
            return RedirectToAction("Index", "Producer");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var data = await ProducerDb.Producers.FindAsync(id); 
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Producer data)
        {
            await ProducerDb.Producers.AddAsync(data);
            await ProducerDb.SaveChangesAsync();
            return RedirectToAction("Index", "Producer");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var data = await ProducerDb.Producers.FirstOrDefaultAsync(x => x.Id == id);
            return View(data);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConformation(int? id)
        {
            var data = await ProducerDb.Producers.FindAsync(id);
            if(data == null)
            {
                return NotFound();
            }
            ProducerDb.Producers.Remove(data);
            await ProducerDb.SaveChangesAsync();
            return RedirectToAction("Index", "Producer");
        }
    }
}

