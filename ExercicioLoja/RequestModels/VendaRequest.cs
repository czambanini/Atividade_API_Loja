using ExercicioLoja.Models;
using System.ComponentModel.DataAnnotations;

namespace ExercicioLoja.RequestModels
{
    public class VendaRequest
    {
        public string NomeCliente { get; set; }

        [Required(ErrorMessage = "A venda deve possuir pelo menos um produto")]
        public List<int> IdProdutos { get; set; }

    }
}
