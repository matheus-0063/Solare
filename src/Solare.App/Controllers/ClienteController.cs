using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solare.App.ViewModels;
using Solare.Business.Interfaces;
using Solare.Business.Models;

namespace Solare.App.Controllers
{
    [Authorize]
    public class ClienteController(IClienteRepository clienteRepository, IEnderecoSimulacaoRepository enderecoRepository,
                                  IMapper mapper) : BaseController
    {
        private readonly IClienteRepository _clienteRepository = clienteRepository;
        private readonly IEnderecoSimulacaoRepository _enderecoRepository = enderecoRepository;
        private readonly IMapper _mapper = mapper;

        [AllowAnonymous]
        [Route("lista-de-clientes")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterTodos()));
        }

        [AllowAnonymous]
        [Route("dados-do-cliente/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {

            var clienteViewModel = await ObterClienteEnderecoSimulacao(id);

            if (clienteViewModel == null)
            {
                return NotFound();
            }

            return View(clienteViewModel);
        }

        [Route("novo-cliente")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("novo-cliente")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) return View(clienteViewModel);

            var cliente = _mapper.Map<Cliente>(clienteViewModel);
            await _clienteRepository.Adicionar(cliente);

            return RedirectToAction("Index");
        }

        [Route("editar-cliente/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var clienteViewModel = await ObterClienteProdutosEnderecoSimulacao(id);
            if (clienteViewModel == null)
            {
                return NotFound();
            }
            return View(clienteViewModel);
        }

        [Route("editar-cliente/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ClienteViewModel clienteViewModel)
        {
            if (id != clienteViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(clienteViewModel);

            var cliente = _mapper.Map<Cliente>(clienteViewModel);
            await _clienteRepository.Atualizar(cliente);

            return RedirectToAction("Index");
        }

        [Route("excluir-cliente/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var clienteViewModel = await ObterClienteEnderecoSimulacao(id);

            if (clienteViewModel == null)
            {
                return NotFound();
            }

            return View(clienteViewModel);
        }

        [Route("excluir-cliente/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var cliente = await ObterClienteEnderecoSimulacao(id);

            if (cliente == null) return NotFound();

            await _clienteRepository.Remover(id);

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [Route("obter-endereco-cliente/{id:guid}")]
        public async Task<IActionResult> ObterEnderecoSimulacao(Guid id)
        {
            var cliente = await ObterClienteEnderecoSimulacao(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return PartialView("_DetalhesEnderecoSimulacao", cliente);
        }



        private async Task<ClienteViewModel> ObterClienteEnderecoSimulacao(Guid id)
        {
            return _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterClienteEnderecoSimulacao(id));
        }

        private async Task<ClienteViewModel> ObterClienteProdutosEnderecoSimulacao(Guid id)
        {
            return _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterClienteSimulacoesEndereco(id));
        }
    }
}
