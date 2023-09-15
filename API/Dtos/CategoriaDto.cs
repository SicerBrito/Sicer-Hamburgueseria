using System.ComponentModel.DataAnnotations;

namespace API.Dtos;
    public class CategoriaDto{
        
        [Required]
        public string ? Nombre { get; set; }
        
    }
