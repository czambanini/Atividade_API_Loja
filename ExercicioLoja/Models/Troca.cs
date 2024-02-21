namespace ExercicioLoja.Models
{
    public class Troca
    {
        public int Id { get; set; }
        private static int ContadorId = 1;
        public string NomeCliente { get; set; }
        public List<Produto> ProdutoTrocado { get; set; }
        public List<Produto> ProdutoAdquirido { get; set; }
        public decimal Acerto { get; set; }
        public DateTime RealizadaEm { get; set; }

        public Troca(string? nomecliente, List<Produto> produtostrocados, List<Produto> produtosadquiridos, decimal acerto)
        {
            Id = ContadorId++;
            NomeCliente = nomecliente;
            ProdutoTrocado = produtostrocados;
            ProdutoAdquirido = produtosadquiridos;
            Acerto = acerto;
            RealizadaEm = DateTime.Now;
        }

    }
}
