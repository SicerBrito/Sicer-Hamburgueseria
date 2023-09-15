namespace Dominio.Entities;
    public class Ingrediente : BaseEntity{
        
        public string ? NombreIngrediente { get; set; }
        public string ? DescripcionIngrediente { get; set; }
        public int PrecioIngrediente { get; set; }
        public int StockIngrediente { get; set; }
        public ICollection<HamburgesaIngrediente> ? HamburgesaIngredientes { get; set; }
    public int Stock { get; set; }
}
