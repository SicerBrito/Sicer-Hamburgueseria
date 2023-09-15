using Dominio.Entities;

namespace Dominio.Interfaces;
    public interface IChef : IGenericRepository<Chef>{
        Task<Hamburgesa> GetByHamburgerAsync(string hamburger);
        Task<Hamburgesa> GetByIngredientsAsync(string ingredients);
    }
