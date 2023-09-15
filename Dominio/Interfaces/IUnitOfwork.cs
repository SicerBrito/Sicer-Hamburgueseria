namespace Dominio.Interfaces;
    public interface IUnitOfWork{
        
        IUsuario Usuarios {get;}
        IRol Roles {get;}
        ICategoria ? Categorias { get;}
        IChef ? Chefs { get; }
        IHamburgesa ? Hamburgesas { get; }
        IIngrediente ? Ingredientes { get; }
        Task<int> SaveAsync();
        
    }
