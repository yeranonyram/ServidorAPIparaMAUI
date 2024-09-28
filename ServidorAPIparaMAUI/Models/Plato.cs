using System.ComponentModel.DataAnnotations;

namespace ServidorAPIparaMAUI.Models
{
    public class Plato
    {
        [Key]//lave primaria de plato este modelo funcionara con 
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
