using ExercicioLoja.Models;
using ExercicioLoja.Repository;
using System.Diagnostics.Eventing.Reader;
using ExercicioLoja.CustomExceptions;
using ExercicioLoja.Filters;

namespace ExercicioLoja.Services
{
    public class OperacoesService : IOperacoesService
    {
        private IEstoque _produtos;
        private readonly ILogger<FiltroExcecao> _logger;

        public OperacoesService(IEstoque estoque, ILogger<FiltroExcecao> logger)
        {
            _produtos = estoque;
            _logger = logger;
        }

        public List<Produto> ValidarListaDeProdutos(List<int> idProdutos)
        {
            if (idProdutos.Count == 0)
            {
                _logger.LogError("Falha na operação. Lista de produtos está vazia");
                throw new CustomException("Lista de produtos está vázia", 404);
            }

            List<Produto> produtos = new();

            foreach (int id in idProdutos)
            {
                var produto = _produtos.GetById(id);
                if (produto is not null) produtos.Add(produto);
                else
                {
                    _logger.LogError("Falha na operação. Id passado não corresponde a um produto");
                    throw new CustomException("Id passado não corresponde a um produto", 404);
                }

            }

            _logger.LogInformation("Validação da lista de produtos feita com sucesso");
            return produtos;

        }

        public decimal ValorTotal(List<Produto> produtosVenda)
        {
            decimal Total = 0;

            foreach (Produto produto in produtosVenda)
            {
                Total = Total + produto.Preco;
            }

            return Total;
        }

        public decimal ValorDoAcerto(List<Produto> trocados, List<Produto> adquiridos)
        {
            decimal valorAcerto = 0;

            foreach (var produto in trocados)
            {
                valorAcerto = valorAcerto - produto.Preco;
            }
            foreach (var produto in adquiridos)
            {
                valorAcerto = valorAcerto + produto.Preco;
            }

            return valorAcerto;
        }

    }
}
