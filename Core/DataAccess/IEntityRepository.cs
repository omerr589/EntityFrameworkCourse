using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    // generic constraint -> generic constraint where T : class
    // It explains that T must be a reference type, which helps prevent incorrect implementations.
    // The IEntity part establishes the requirement that all implemented classes must either be IEntity or inherit from a class that derives from IEntity.
    // The ()new part signifies that it must be instantiable (i.e., it must be able to be instantiated using new), but since IEntity is an interface, it cannot be instantiated directly using new.

    public interface IEntityRepository <T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null); // This structure allows us to retrieve a specific subset of data using LINQ queries when using the GetAll function.

        T Get(Expression<Func<T, bool>> filter); // The filter parameter is mandatory and cannot be null.
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
