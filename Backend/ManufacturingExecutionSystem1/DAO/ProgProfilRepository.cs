
using ManufacturingExecutionSystem1.Data;
using ManufacturingExecutionSystem1.entities;
using ManufacturingExecutionSystem1.GenericRepository;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
namespace ManufacturingExecutionSystem1.Service
{
  public class ProgProfilRepository : IProgProfil
    {
        private Context _context;
        public ProgProfilRepository(Context context)
        {
            this._context = context;
        }
        public async Task<ProgProfil> AddProgProfil(ProgProfil model)
        {
            var pr = await _context.ProgProfils.AddAsync(model);
            await _context.SaveChangesAsync();
            return pr.Entity;
        }

        public async Task DeleteProgProfil(int id)
        {
            var pr = await _context.ProgProfils.FirstOrDefaultAsync(p => p.IDProgProfil == id);
            if(pr != null)
            {
                _context.ProgProfils.Remove(pr);
                await _context.SaveChangesAsync();
               
            }
        }

        public async Task<IEnumerable<ProgProfil>> GetProgProfils()
        {
            return await _context.ProgProfils.ToListAsync();
        }

        public async Task<ProgProfil> GetProgProfil(int id)
        {
            return await _context.ProgProfils.FirstOrDefaultAsync(p=>p.IDProgProfil == id);
        }

        public async Task<ProgProfil> UpdateProgProfil(ProgProfil model)
        {
            var pr = await _context.ProgProfils.FirstOrDefaultAsync(p=>p.IDProgProfil == model.IDProgProfil);
            if(pr != null)
            {
                pr.Id_Profil = model.Id_Profil;
                pr.LibProgramme = model.LibProgramme;
                pr.NomProgramme = model.NomProgramme;
                pr.onlyconsultation = model.onlyconsultation;
                pr.Intitule = model.Intitule;   
                await _context.SaveChangesAsync();
                return pr;
            }
            return null;
        }
    public bool DataExist(string code)
    {
      return _context.ProgProfils.Any(d=>d.IDProgProfil.ToString() == code);
    }
    }
}
