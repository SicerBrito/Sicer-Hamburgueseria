using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class ChefRepository : GenericRepository<Chef>, IChef
{
    private readonly DbAppContext _Context;
    public ChefRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }

    public Task<Hamburgesa> GetByHamburgerAsync(string hamburger)
    {
        throw new NotImplementedException();
    }

    public Task<Hamburgesa> GetByIngredientsAsync(string ingredients)
    {
        throw new NotImplementedException();
    }
}