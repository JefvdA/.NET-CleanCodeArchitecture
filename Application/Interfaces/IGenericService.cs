namespace Application.Interfaces;

public interface IGenericService<T>
{
    IEnumerable<T> GetAll(int pageNr, int pageSize);
    
    Task<T> GetById(int id);
    
    Task<T> Create(T newEntity);
    
    Task<T> Update(T updatedEntity);
    
    Task Delete(int id);
}