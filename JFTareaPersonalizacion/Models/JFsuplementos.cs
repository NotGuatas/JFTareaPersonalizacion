using System.ComponentModel.DataAnnotations;

namespace JFTareaPersonalizacion.Models
{
    public class JFsuplementos
    {
        public int ID { get; set; }
        [Required]
        public string? Nombre { get; set; }

        public bool Whey {  get; set; }
        public bool Cafeina { get; set; }

        [Range(0.01,9999.99)]
        public decimal Precio { get; set; }
    }
}
