using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solare.App.ViewModels;
using Solare.Business.Interfaces;
using Solare.Business.Models;

namespace Solare.App.Controllers
{
    public class SimulacaoController(ISimulacaoRepository simulacaoRepository, IFornecedorRepository fornecedorRepository,
                                IMapper mapper) : BaseController
    {
        public const double mediaHSPLocalBrasil = 5.153;

        private readonly ISimulacaoRepository _simulacaoRepository = simulacaoRepository;
        private readonly IFornecedorRepository _fornecedorRepository = fornecedorRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<ActionResult> Index()
        {
            return View(nameof(Create));
        }

        [Route("nova-simulacao")]
        public ActionResult Create()
        {
            return View();
        }

        [Route("nova-simulacao")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SimulacaoViewModel simulacaoViewModel)
        {
            if (!ModelState.IsValid) return View(simulacaoViewModel);

            var simulacao = _mapper.Map<Simulacao>(simulacaoViewModel);
            await _simulacaoRepository.Adicionar(simulacao);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> ExibirRelatorio()
        {

        }
    }

    public class Teste
    {

        // Passo 1: Calcular a Média Máxima Diária
        static double CalcularMediaMaximaDiaria(double mediaMensal, string tipoLigacao)
        {
            int taxaDisponibilidade = tipoLigacao switch
            {
                "monofasico" => 30,
                "bifasico" => 50,
                "trifasico" => 100,
                _ => throw new ArgumentException("Tipo de ligação inválido")
            };

            return (mediaMensal - taxaDisponibilidade) / 30;
        }

        // Passo 3: Calcular a Potência Necessária do Sistema
        static double CalcularPotenciaNecessaria(double consumoMensal, double hsp, double eficiencia = 0.75)
        {
            double consumoDiario = consumoMensal / 30;
            return consumoDiario / (hsp * eficiencia);
        }

        // Passo 4: Determinar o Número de Módulos Necessários
        static int CalcularNumeroModulos(double potenciaNecessaria, double potenciaModulo)
        {
            return (int)Math.Ceiling(potenciaNecessaria / potenciaModulo);
        }

        // Passo 5: Determinar a Potência de Inversores Necessários
        static double DeterminarPotenciaInversor(int numModulos, double potenciaModulo)
        {
            double potenciaTotal = numModulos * potenciaModulo;
            double[] potenciasInversores = { 3, 5, 10, 15, 30 };
            foreach (var potencia in potenciasInversores)
            {
                if (potenciaTotal <= potencia)
                    return potencia;
            }
            return potenciasInversores[^1]; // Retorna a maior potência disponível
        }

        static void Main(string[] args)
        {
            // Entrada de Dados
            Console.WriteLine("Digite o consumo médio mensal (kWh):");
            double consumoMensal = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Digite o tipo de ligação (monofasico, bifasico, trifasico):");
            string tipoLigacao = Console.ReadLine().ToLower();

            Console.WriteLine("Digite o CEP:");
            string cep = Console.ReadLine();

            Console.WriteLine("Digite a potência do módulo (kWp):");
            double potenciaModulo = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Digite o custo médio por módulo (R$):");
            double custoModulo = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Digite o custo médio do inversor (R$):");
            double custoInversor = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Digite o custo médio da estrutura (R$):");
            double custoEstrutura = Convert.ToDouble(Console.ReadLine());

            // Cálculos
            double mediaDiaria = CalcularMediaMaximaDiaria(consumoMensal, tipoLigacao);
            double potenciaNecessaria = CalcularPotenciaNecessaria(consumoMensal, mediaHSPLocalBrasil);
            int numModulos = CalcularNumeroModulos(potenciaNecessaria, potenciaModulo);
            double potenciaTotal = numModulos * potenciaModulo;
            double potenciaInversor = DeterminarPotenciaInversor(numModulos, potenciaModulo);

            double custoTotal = (numModulos * custoModulo) + custoInversor + custoEstrutura;
            double payback = custoTotal / ((consumoMensal * 12) / 12);

            // Saída de Dados
            Console.WriteLine("\n--- Resultados ---");
            Console.WriteLine($"Número de Módulos: {numModulos}");
            Console.WriteLine($"Potência Total (kWp): {potenciaTotal}");
            Console.WriteLine($"Potência do Inversor (kWp): {potenciaInversor}");
            Console.WriteLine($"Gasto Médio de Implantação (R$): {custoTotal}");
            Console.WriteLine($"Payback (anos): {Math.Round(payback, 2)}");
            Console.WriteLine("Estrutura: Telhado Inclinado"); // Exemplo fixo
            Console.WriteLine("Ângulo: 23° (latitude fictícia)"); // Substituir pela lógica real
            Console.WriteLine("Orientação: Norte (hemisfério sul)");

            // Telefones de instaladores cadastrados
            Console.WriteLine("\n--- Telefones de Instaladores ---");
            Console.WriteLine("João Silva: (11) 99999-9999");
            Console.WriteLine("Maria Oliveira: (21) 98888-8888");
        }
    }
}
