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
    public class VendasController : ControllerBase
    {
        private IOperacoesRepository _transacoes;
        private IOperacoesService _vendaService;

        public VendasController(IOperacoesRepository transacoes, IOperacoesService vendaService)
        {
            _transacoes = transacoes;
            _vendaService = vendaService;
        }

        [HttpPost("NovaVenda")]
        public IActionResult Post([FromBody] VendaRequest vendarequest)
        {
            List<Produto> produtosVenda = _vendaService.ValidarListaDeProdutos(vendarequest.IdProdutos);
            decimal valorTotal = _vendaService.ValorTotal(produtosVenda);
            var NovaVenda = new Venda(vendarequest.NomeCliente, produtosVenda, valorTotal);
            _transacoes.AddVenda(NovaVenda);
            return Ok(NovaVenda);
        }

        [HttpGet("ListarVendas")]
        public IActionResult Get()
        {
            return Ok(_transacoes.GetVendas());
        }
    }
}
