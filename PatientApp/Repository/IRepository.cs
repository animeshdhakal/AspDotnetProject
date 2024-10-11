using System.Linq.Expressions;
using PatientApp.Dtos;

namespace PatientApp.Repository;

public interface IRepository<T> where T : class
{
   Task<IQueryable<T>> GetAll();
   
   Task<T?> GetById(int id);

   Task<T?> Get(Expression<Func<T, bool>> predicate);
   
   Task Add(T entity);
   
   Task Update(T entity);
   
   Task Delete(T entity);
   
   Task Save(); 
}