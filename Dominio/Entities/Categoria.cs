namespace Dominio.Entities;
    public class Categoria : BaseEntity{
        
        public string ? NombreCategoria { get; set; }
        public string ? DescripcionCategoria { get; set; }
        public ICollection<Hamburgesa> ? Hamburgesas{ get; set; }

    }
