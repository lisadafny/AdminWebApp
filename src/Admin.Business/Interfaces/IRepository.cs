using Admin.Business.Models;
using System.Linq.Expressions;

namespace Admin.Business.Interfaces
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        Task Add(T entity);
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task Update(T entity);
        Task Delete(Guid id);
        Task<IEnumerable<T>> Search(Expression<Func<T, bool>> predicate);
        Task<int> SaveChanges();
    }
}
