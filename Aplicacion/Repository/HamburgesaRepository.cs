using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class HamburgesaRepository : GenericRepository<Hamburgesa>, IHamburgesa
{
    private readonly DbAppContext _Context;
    public HamburgesaRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }

    public async Task<Hamburgesa> GetByCategoryAsync(string category)
    {
        return (await _Context.Set<Hamburgesa>()
                            .Include(u => u.Categorias)
                            .FirstOrDefaultAsync(u => u.NombreHamburgesa!.ToLower()==category.ToLower()))!;
    }

    public async Task<Hamburgesa> GetByIngredientsAsync(string ingredients)
    {
        return (await _Context.Set<Hamburgesa>()
                            .Include(u => u.HamburgesaIngredientes)
                            .FirstOrDefaultAsync(u => u.NombreHamburgesa!.ToLower()==ingredients.ToLower()))!;
    }
}
