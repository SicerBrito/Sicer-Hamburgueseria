namespace Dominio.Entities;
    public class Chef : BaseEntity{
        
        public string ? NombreChef { get; set; }
        public string ? EspecialidadChef { get; set; }
        public ICollection<Hamburgesa> ? Hamburgesas { get; set; }


    }
