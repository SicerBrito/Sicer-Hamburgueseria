using Aplicacion.Repository;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.UnitOfWork;
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbAppContext ? _Context;
        public UnitOfWork(DbAppContext context){
            _Context = context;
        }



        private RolRepository ? _Rol;
        private UsuarioRepository ? _Usuario;
        private CategoriaRepository ? _Categoria;
        private ChefRepository ? _Chef;
        private HamburgesaRepository ? _Hamburgesa;
        private IngredienteRepository ? _Ingrediente;



        
        public IRol Roles => _Rol ??= new RolRepository(_Context!);
        public IUsuario Usuarios => _Usuario ??= new UsuarioRepository(_Context!);
        public ICategoria Categorias => _Categoria ??= new CategoriaRepository(_Context!);
        public IChef Chefs => _Chef ??= new ChefRepository(_Context!);
        public IHamburgesa Hamburgesas => _Hamburgesa ??= new HamburgesaRepository(_Context!);
        public IIngrediente Ingredientes => _Ingrediente ??= new IngredienteRepository(_Context!);




        public void Dispose(){
            _Context!.Dispose();
            GC.SuppressFinalize(this); 
        }

        public Task<int> SaveAsync(){
            return _Context!.SaveChangesAsync();
        }
    }


