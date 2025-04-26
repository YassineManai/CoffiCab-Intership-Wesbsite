

namespace ManufacturingExecutionSystem1.GenericRepository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> GetByCode(string code);
        Task<T> Add(T model);
        Task<T> Update(T model);
        Task Delete(string code);
        bool DataExist(string code);

  }
}
