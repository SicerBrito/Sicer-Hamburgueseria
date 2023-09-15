namespace API.Dtos;
    public class HamburgesaComplementsDto{
        public int Id { get; set; }
        public string ? Nombre { get; set; }
        public List<CategoriaDto> ? Categorias { get; set; }
        public List<IngredienteDto> ? Ingredientes { get; set; }
    }
