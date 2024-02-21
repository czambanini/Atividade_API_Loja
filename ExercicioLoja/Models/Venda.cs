using System.ComponentModel.DataAnnotations;

namespace ExercicioLoja.Models
{
    public class Venda
    {
        public int Id { get; set; }
        private static int ContadorId = 1;
        public string NomeCliente { get; set; }
        public List<Produto> Produtos { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime RealizadaEm { get; set; }

        public Venda(string? nomecliente, List<Produto> produtos, decimal valortotal)
        {
            Id = ContadorId++;
            NomeCliente = nomecliente;
            Produtos = produtos;
            ValorTotal = valortotal;
            RealizadaEm = DateTime.Now;
        }
    }
}
