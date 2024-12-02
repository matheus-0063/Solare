using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solare.App.ViewModels;
using Solare.Business.Interfaces;
using Solare.Business.Models;
using Solare.Data.Repository;

namespace Solare.App.Controllers
{
    [Authorize]
    public class ContatoController : BaseController
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IMapper _mapper;

        public ContatoController(IContatoRepository contatoRepository, IMapper mapper)
        {
            _contatoRepository = contatoRepository;
            _mapper = mapper;
        }

        [Route("contato")]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [AllowAnonymous]
        [Route("novo-contato")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("novo-contato")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContatoViewModel contatoViewModel)
        {
            if (!ModelState.IsValid) return View(contatoViewModel);

            var fornecedor = _mapper.Map<Contato>(contatoViewModel);
            await _contatoRepository.Adicionar(fornecedor);

            return RedirectToAction("Obrigado");
        }

        public ActionResult Details(int id)
        {
            return View();
        }


        // GET: ContatoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContatoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
