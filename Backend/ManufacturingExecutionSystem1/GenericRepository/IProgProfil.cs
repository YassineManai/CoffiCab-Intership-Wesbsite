using ManufacturingExecutionSystem1.entities;

namespace ManufacturingExecutionSystem1.GenericRepository
{
  public interface IProgProfil
    {
        Task<IEnumerable<ProgProfil>> GetProgProfils();
        Task<ProgProfil> GetProgProfil(int id);
        Task<ProgProfil> AddProgProfil(ProgProfil model);
        Task<ProgProfil> UpdateProgProfil(ProgProfil model);
        Task DeleteProgProfil(int id);
        bool DataExist(string code);

     }
}
