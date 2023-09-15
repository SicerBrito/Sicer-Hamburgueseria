using Dominio.Entities;

namespace API.Dtos;
    public class ChefComplementsDto{
        
        public int Id { get; set; }
        public string ? Nombre { get; set; }
        public string ? Especialidad { get; set; }
        public List<Hamburgesa> ? Hamburgesas{ get; set; }
        
    }
