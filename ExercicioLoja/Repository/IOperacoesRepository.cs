using ExercicioLoja.Models;

namespace ExercicioLoja.Repository
{
    public interface IOperacoesRepository
    {
        public void AddVenda(Venda venda);

        public List<Venda> GetVendas();

        public void AddTroca(Troca troca);

        public List<Troca> GetTrocas();

        public void AddDevolucao(Devolucao devolucao);

        public List<Devolucao> GetDevolucoes();
    }
}
