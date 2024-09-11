using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    public class ProducerController : Controller
    {
        private readonly IProducerRepository _producerRepository = null;

        public ProducerController(IProducerRepository _producerRepository)
        {
            this._producerRepository = _producerRepository;
        }
        public IActionResult Index()
        {
            var data = _producerRepository.ProducerLists();
            return View(data);
        }

        public IActionResult Details(int id)
        {
            var data = _producerRepository.GetProducerById(id);
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Producer data)
        {
            _producerRepository.AddProducer(data);
            return RedirectToAction("Index", "Producer");
        }

        public IActionResult Edit(int id)
        {
            var data = _producerRepository.GetProducerById(id); 
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Producer data)
        {
            _producerRepository.UpdateProducer(data);
            return RedirectToAction("Index", "Producer");
        }

        public IActionResult Delete(int id)
        {
            var data = _producerRepository.GetProducerById(id);
            return View(data);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConformation(int id)
        {
            if(id != null && id != 0)
            {
                _producerRepository.DeleteProducer(id);
                return RedirectToAction("Index", "Producer");
            }
            else
            {
                return NotFound();
            }
        }
    }
}

