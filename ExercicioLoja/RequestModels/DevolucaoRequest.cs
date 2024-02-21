using System.ComponentModel.DataAnnotations;

namespace ExercicioLoja.RequestModels
{
    public class DevolucaoRequest
    {
        public string NomeCliente { get; set; }

        [Required]
        public List<int> IdProdutosDevolvidos { get; set; }
    }
}
