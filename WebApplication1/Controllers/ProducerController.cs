using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Commands;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    public class ProducerController : Controller
    {
        private readonly IProducerRepository _producerRepository = null;
        private IMediator _mediator;

        public ProducerController(IProducerRepository _producerRepository, IMediator mediator)
        {
            this._producerRepository = _producerRepository;
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _mediator.Send(new GetProducerListsQuery());
            return View(data);
        }

        public async Task<IActionResult> Details(int id)
        {
            var data = await _mediator.Send(new GetProducerByIdQuery() { Id = id});
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Producer data)
        {
            await _mediator.Send(new CreateProducerCommand(data.Name, data.Gender, data.Dob, data.Bio));
            return RedirectToAction("Index", "Producer");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var data = await _mediator.Send(new GetProducerByIdQuery() { Id = id });
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Producer data)
        {
            _producerRepository.UpdateProducer(data);
            return RedirectToAction("Index", "Producer");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var data = await _mediator.Send(new GetProducerByIdQuery() { Id = id });
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

