namespace Application.Interfaces;

public interface IGenericRepository<T>
{
    Task<IEnumerable<T>> GetAll(int pageNr, int pageSize);
    
    Task<T> GetById(int id);
    
    T Create(T newEntity);
    
    T Update(T updatedEntity);
    
    void Delete(T entity);
}