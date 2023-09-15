namespace Dominio.Interfaces;
    public interface IUnitOfWork{
        
        IUsuario Usuarios {get;}
        IRol Roles {get;}
        IEjemploInterface ? EjemploInterfaces { get;}
        Task<int> SaveAsync();
        
    }
