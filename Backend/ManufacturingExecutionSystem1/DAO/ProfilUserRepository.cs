using ManufacturingExecutionSystem1.GenericRepository;
using Microsoft.EntityFrameworkCore;
using ManufacturingExecutionSystem1.Data;
using ManufacturingExecutionSystem1.entities;

namespace ManufacturingExecutionSystem1.Service
{
  public class ProfilUserRepository : IRepository<ProfilUser>
    {
        private readonly Context _context;
        public ProfilUserRepository(Context context)
        {
            _context = context; 
        }
        public async Task<ProfilUser> Add(ProfilUser model)
        {
            var pr = await _context.ProfilUser.AddAsync(model);
            await _context.SaveChangesAsync();
            return pr.Entity;
        }

        public async Task Delete(string code)
        {
            var pr = await _context.ProfilUser.FirstOrDefaultAsync(p=>p.Id_Profil == code);
            if(pr != null) {
                _context.ProfilUser.Remove(pr);
              await  _context.SaveChangesAsync();
                    }
        }

        public async Task<IEnumerable<ProfilUser>> GetAll()
        {
            return await _context.ProfilUser.ToListAsync();
        }

        public async Task<ProfilUser> GetById(int id)
        {
      // return await _context.ProfilUser.FirstOrDefaultAsync(p => p.IDProfiUser == id);
      return null;
        }
    public async Task<ProfilUser> GetByCode(string code)
    {
      return await _context.ProfilUser.FirstOrDefaultAsync(p => p.Id_Profil == code);
    }

    public async Task<ProfilUser> Update(ProfilUser profilUser)
        {
            var pr = await _context.ProfilUser.FirstOrDefaultAsync(p => p.Id_Profil == profilUser.Id_Profil);
            if( pr != null ) {
                pr.NomProfil = profilUser.NomProfil;
                pr.Id_Profil = profilUser.Id_Profil;
               // pr.IDProfiUser = profilUser.IDProfiUser;
                await _context.SaveChangesAsync();
                return pr;
            }
            return null;
        }
    public bool DataExist(string code)
    {
      return _context.ProfilUser.Any(d => d.Id_Profil.ToString() == code);
    }
  }
}
