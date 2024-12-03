using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solare.App.ViewModels;
using Solare.Business.Interfaces;
using Solare.Business.Models;

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
            return View(_mapper.Map<IEnumerable<ContatoViewModel>>(await _contatoRepository.ObterTodos()));
        }

        [AllowAnonymous]
        [Route("novo-contato")]
        public IActionResult Create()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost("novo-contato")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContatoViewModel contatoViewModel)
        {
            if (!ModelState.IsValid) return View(contatoViewModel);

            var contato = _mapper.Map<Contato>(contatoViewModel);
            await _contatoRepository.Adicionar(contato);

            return RedirectToAction("Obrigado");
        }

        [Route("detalhes-contato/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var contatoViewModel = await ObterDetalhesContato(id);

            if (contatoViewModel == null) return NotFound();
            return View(contatoViewModel);
        }

        [AllowAnonymous]
        public ActionResult Obrigado()
        {
            return View();
        }

        private async Task<ContatoViewModel> ObterDetalhesContato(Guid id)
        {
            return _mapper.Map<ContatoViewModel>(await _contatoRepository.ObterPorId(id));
        }

    }
}
