using System.Collections.Generic;

namespace AppCadastro.src.Interfaces
{
    public interface IRepository<X>
    {
        List<X> List();
        X ReturnById(int id);        
        void Insert(X entidade);        
        void Delete(int id);        
        void Update(int id, X entidade);
        int NextId();
    }
}