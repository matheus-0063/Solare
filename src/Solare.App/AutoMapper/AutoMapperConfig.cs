using AutoMapper;
using Solare.App.ViewModels;
using Solare.Business.Models;

namespace Solare.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<EnderecoSimulacao, EnderecoSimulacaoViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
            CreateMap<Simulacao, SimulacaoViewModel>().ReverseMap();
            CreateMap<Contato, ContatoViewModel>().ReverseMap();
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
        }
    }
}
