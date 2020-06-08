using System.ComponentModel.DataAnnotations;


namespace Apontador_RodrigoHideki.Models
{
    public class Apontador
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Endereco")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Telefone")]        
        public string Telefone { get; set; }

    }
}