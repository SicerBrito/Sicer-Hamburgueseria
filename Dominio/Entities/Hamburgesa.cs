namespace Dominio.Entities;
    public class Hamburgesa : BaseEntity{
        
        public string ? NombreHamburgesa { get; set; }
        public string ? CategoriaId { get; set; }
        public Categoria ? Categorias { get; set; }
        public int Precio { get; set; }
        public string ? ChefId { get; set; }
        public Chef ? Chefs { get; set; }
        public ICollection<HamburgesaIngrediente> ? HamburgesaIngredientes { get; set; }

    }
