using ExercicioLoja.Models;
using ExercicioLoja.Repository;
using ExercicioLoja.RequestModels;
using ExercicioLoja.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExercicioLoja.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DevolucaoController : ControllerBase
    {
        private IOperacoesRepository _transacoes;
        private IOperacoesService _operacoesService;

        public DevolucaoController(IOperacoesRepository transacoes, IOperacoesService operacoesService)
        {
            _transacoes = transacoes;
            _operacoesService = operacoesService;
        }

        [HttpPost("NovaDevolucao")]
        public IActionResult Post([FromBody] DevolucaoRequest devolucaorequest)
        {
            List<Produto> produtosDevolvidos = _operacoesService.ValidarListaDeProdutos(devolucaorequest.IdProdutosDevolvidos);
            decimal valorTotal = _operacoesService.ValorTotal(produtosDevolvidos);
            var NovaDevolucao = new Devolucao(devolucaorequest.NomeCliente, produtosDevolvidos, valorTotal);
            _transacoes.AddDevolucao(NovaDevolucao);
            return Ok(NovaDevolucao);
        }

        [HttpGet("ListarDevolucoes")]
        public IActionResult Get()
        {
            return Ok(_transacoes.GetDevolucoes());
        }
    }
}
