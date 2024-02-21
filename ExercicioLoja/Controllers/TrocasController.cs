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
    public class TrocasController : ControllerBase
    {
        private IOperacoesRepository _transacoes;
        private IOperacoesService _operacoesService;

        public TrocasController(IOperacoesRepository transacoes, IOperacoesService vendaService)
        {
            _transacoes = transacoes;
            _operacoesService = vendaService;
        }

        [HttpPost("NovaTroca")]
        public IActionResult Post([FromBody] TrocaRequest trocaRequest)
        {
            List<Produto> produtosTrocados = _operacoesService.ValidarListaDeProdutos(trocaRequest.IdProdutosTrocado);
            List<Produto> produtosAdquiridos = _operacoesService.ValidarListaDeProdutos(trocaRequest.IdProdutosAdquirido);
            decimal acerto = _operacoesService.ValorDoAcerto(produtosTrocados, produtosAdquiridos);
            var NovaTroca = new Troca(trocaRequest.NomeCliente, produtosTrocados, produtosAdquiridos, acerto);
            _transacoes.AddTroca(NovaTroca);
            return Ok(NovaTroca);
        }

        [HttpGet("ListarTrocas")]
        public IActionResult Get()
        {
            return Ok(_transacoes.GetTrocas());
        }
    }
}
