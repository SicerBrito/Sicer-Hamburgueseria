namespace Dominio.Entities;
    public class HamburgesaIngrediente : BaseEntity{
        
        public int HamburgesaId { get; set; }
        public Hamburgesa ? Hamburgesas { get; set; }
        public int IngredienteId { get; set; }
        public Ingrediente ? Ingredientes { get; set; }

    }
