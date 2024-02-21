using ExercicioLoja.Models;

namespace ExercicioLoja.Repository
{
    public class OperacoesRepository : IOperacoesRepository
    {
        public List<Venda> listaVendas = new List<Venda>();
        public List<Troca> listaTrocas = new List<Troca>();
        public List<Devolucao> listaDevolucoes = new List<Devolucao>();

        public void AddVenda(Venda venda)
        {
            listaVendas.Add(venda);
        }

        public List<Venda> GetVendas()
        {
            return listaVendas;
        }

        public void AddTroca(Troca troca)
        {
            listaTrocas.Add(troca);
        }

        public List<Troca> GetTrocas()
        {
            return listaTrocas;
        }

        public void AddDevolucao(Devolucao devolucao)
        {
            listaDevolucoes.Add(devolucao);
        }

        public List<Devolucao> GetDevolucoes()
        {
            return listaDevolucoes;
        }

    }
}
