using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class IngredienteRepository : GenericRepository<Ingrediente>, IIngrediente
{
    private readonly DbAppContext _Context;
    public IngredienteRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }


}
