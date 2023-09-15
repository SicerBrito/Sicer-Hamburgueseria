using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class CategoriaRepository : GenericRepository<Categoria>, ICategoria
{
    private readonly DbAppContext _Context;
    public CategoriaRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }
}
