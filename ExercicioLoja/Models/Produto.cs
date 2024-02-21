namespace ExercicioLoja.Models
{
    public class Produto
    {
        public int Id { get; set; }
        private static int ContadorId = 1;

        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public Produto(string nome, decimal preco)
        {
            Id = ContadorId++;
            Nome = nome;
            Preco = preco;
        }
    }
}
