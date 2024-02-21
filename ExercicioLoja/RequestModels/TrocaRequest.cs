using ExercicioLoja.Models;
using System.ComponentModel.DataAnnotations;

namespace ExercicioLoja.RequestModels
{
    public class TrocaRequest
    {
        public string NomeCliente { get; set; }

        [Required]
        public List<int> IdProdutosTrocado { get; set; }

        [Required]
        public List<int> IdProdutosAdquirido { get; set; }
    }
}
