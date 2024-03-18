using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEntityRepository <T>
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null); // Bu yapı GetAll fonksiyonunu kullandığımız yerlerde içine yazılan LINQ sorguları ile belli bir kısmını çekmemize yeter
        T Get(Expression<Func<T, bool>> filter); // filter = null olmadığından filtre zorunlu
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
