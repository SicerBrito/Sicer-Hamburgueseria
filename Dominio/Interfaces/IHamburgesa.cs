using Dominio.Entities;

namespace Dominio.Interfaces;
    public interface IHamburgesa : IGenericRepository<Hamburgesa>{
        Task<Hamburgesa> GetByCategoryAsync(string category);
        Task<Hamburgesa> GetByIngredientsAsync(string ingredients);
    
    }
