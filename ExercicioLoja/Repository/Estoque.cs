using ExercicioLoja.Models;

namespace ExercicioLoja.Repository
{
    public class Estoque : IEstoque
    {
        public List<Produto> listaProdutos = new List<Produto>();

        public Estoque()
        {
            listaProdutos.Add(new Produto("Camiseta Amarela", (decimal)40.50));
            listaProdutos.Add(new Produto("Shorts Jeans", (decimal)76.40));
            listaProdutos.Add(new Produto("Regata Branca", (decimal)38.90));
            listaProdutos.Add(new Produto("Saia Midi Preta", (decimal)69.90));
            listaProdutos.Add(new Produto("Calça Jeans", (decimal)120.20));
            listaProdutos.Add(new Produto("Cropped Branco", (decimal)37.90));
        }

        public List<Produto> GetAll()
        {
            return listaProdutos;
        }

        public Produto? GetById(int id)
        {
            return listaProdutos.FirstOrDefault(produto => produto.Id == id);

        }

    }
}
