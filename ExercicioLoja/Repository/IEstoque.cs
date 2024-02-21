using ExercicioLoja.Models;

namespace ExercicioLoja.Repository
{
    public interface IEstoque
    {
        public List<Produto> GetAll();
        public Produto GetById(int id);
    }
}
