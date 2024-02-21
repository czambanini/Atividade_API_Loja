namespace ExercicioLoja.Models
{
    public class Devolucao
    {
        public int Id { get; set; }
        private static int ContadorId = 1;
        public string NomeCliente { get; set; }
        public List<Produto> ProdutoDevolvido { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime RealizadaEm { get; set; }

        public Devolucao(string? nomecliente, List<Produto> produtos, decimal valortotal)
        {
            Id = ContadorId++;
            NomeCliente = nomecliente;
            ProdutoDevolvido = produtos;
            ValorTotal = valortotal;
            RealizadaEm = DateTime.Now;
        }
    }
}
