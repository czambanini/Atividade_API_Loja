using ExercicioLoja.Models;
using ExercicioLoja.Repository;
using System.Diagnostics.Eventing.Reader;
using ExercicioLoja.CustomExceptions;

namespace ExercicioLoja.Services
{
    public class OperacoesService : IOperacoesService
    {
        private IEstoque _produtos;
        public OperacoesService(IEstoque estoque)
        {
            _produtos = estoque;
        }

        public List<Produto> ValidarListaDeProdutos(List<int> idProdutos)
        {
            if (idProdutos.Count == 0)
            {
                throw new CustomException("Lista de produtos está vázia", 404);
            }

            List<Produto> produtos = new();

            foreach (int id in idProdutos)
            {
                var produto = _produtos.GetById(id);
                if (produto is not null) produtos.Add(produto);
                else throw new CustomException("Id passado não corresponde a um produto", 404);
            }

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
