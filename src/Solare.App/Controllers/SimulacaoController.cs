using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solare.App.ViewModels;
using Solare.Business.Interfaces;
using Solare.Business.Models;

namespace Solare.App.Controllers
{
    [Authorize]
    public class SimulacaoController : BaseController
    {
        private readonly ISimulacaoRepository _simulacaoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public SimulacaoController(ISimulacaoRepository simulacaoRepository,
                                  IClienteRepository clienteRepository,
                                  IMapper mapper)
        {
            _simulacaoRepository = simulacaoRepository;
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        [Route("lista-de-simulacaos")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<SimulacaoViewModel>>(await _simulacaoRepository.ObterSimulacoesClientes()));
        }

        [Route("dados-do-simulacao/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var simulacaoViewModel = await ObterSimulacao(id);

            if (simulacaoViewModel == null)
            {
                return NotFound();
            }

            return View(simulacaoViewModel);
        }

        [Route("novo-simulacao")]
        public async Task<IActionResult> Create()
        {
            var simulacaoViewModel = await PopularClientes(new SimulacaoViewModel());

            return View(simulacaoViewModel);
        }

        [Route("novo-simulacao")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SimulacaoViewModel simulacaoViewModel)
        {
            simulacaoViewModel = await PopularClientes(simulacaoViewModel);
            if (!ModelState.IsValid) return View(simulacaoViewModel);
            await _simulacaoRepository.Adicionar(_mapper.Map<Simulacao>(simulacaoViewModel));

            return RedirectToAction("Index");
        }


        [Route("excluir-simulacao/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var simulacao = await ObterSimulacao(id);

            if (simulacao == null)
            {
                return NotFound();
            }

            return View(simulacao);
        }

        [Route("excluir-simulacao/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var simulacao = await ObterSimulacao(id);

            if (simulacao == null)
            {
                return NotFound();
            }

            await _simulacaoRepository.Remover(id);

            TempData["Sucesso"] = "Simulacao excluido com sucesso!";

            return RedirectToAction("Index");
        }

        private async Task<SimulacaoViewModel> ObterSimulacao(Guid id)
        {
            var simulacao = _mapper.Map<SimulacaoViewModel>(await _simulacaoRepository.ObterSimulacoesCliente(id));
            simulacao.Clientes = _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterTodos());
            return simulacao;
        }

        private async Task<SimulacaoViewModel> PopularClientes(SimulacaoViewModel simulacao)
        {
            simulacao.Clientes = _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterTodos());
            return simulacao;
        }
    }

}
