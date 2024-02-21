using ExercicioLoja.Models;

namespace ExercicioLoja.Services
{
    public interface IOperacoesService
    {
        public List<Produto> ValidarListaDeProdutos(List<int> idProdutos);
        public decimal ValorTotal(List<Produto> produtosVenda);
        public decimal ValorDoAcerto(List<Produto> devolvidos, List<Produto> adquiridos);
    }
}
