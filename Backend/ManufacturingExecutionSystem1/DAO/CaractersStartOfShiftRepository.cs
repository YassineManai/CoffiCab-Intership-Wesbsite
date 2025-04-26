using ManufacturingExecutionSystem1.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;
using ManufacturingExecutionSystem1.Data;
using ManufacturingExecutionSystem1.entities;

namespace ManufacturingExecutionSystem1.Service
{
  public class CaractersStartOfShiftRepository : IRepository<CaractersStartOfShiftValues>
    {
        private readonly Context _context;
        public CaractersStartOfShiftRepository(Context context) { _context = context; }
        public async Task<CaractersStartOfShiftValues> Add(CaractersStartOfShiftValues model)
        {
            var car = await _context.CaractersStartOfShiftValues.AddAsync(model);
            await _context.SaveChangesAsync();
            return car.Entity;
        }

        public async Task Delete(string code)
        {
            var car = await _context.CaractersStartOfShiftValues.FirstOrDefaultAsync(c => c.CodeCaracterStartOFShift == code);
            if(car != null)
            {
                 _context.CaractersStartOfShiftValues.Remove(car);
               await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CaractersStartOfShiftValues>> GetAll()
        {
           return await _context.CaractersStartOfShiftValues.ToListAsync();
        }

        public async Task<CaractersStartOfShiftValues> GetById(int id)
        {
            return await _context.CaractersStartOfShiftValues.FirstOrDefaultAsync(c => c.IDCaractersStartOfShiftValues == id);
        }
    public async Task<CaractersStartOfShiftValues> GetByCode(string code)
    {
      return await _context.CaractersStartOfShiftValues.FirstOrDefaultAsync(c => c.CodeCaracterStartOFShift == code);
    }
    public async Task<CaractersStartOfShiftValues> Update(CaractersStartOfShiftValues caractersStartOfShiftValuesDTO)
        {
            var car = await _context.CaractersStartOfShiftValues.FirstOrDefaultAsync(c => c.CodeCaracterStartOFShift == caractersStartOfShiftValuesDTO.CodeCaracterStartOFShift);

            car.Value = caractersStartOfShiftValuesDTO.Value;
                car.Id_Poste = caractersStartOfShiftValuesDTO.Id_Poste;
                car.Machine_Code = caractersStartOfShiftValuesDTO.Machine_Code;
                car.User = caractersStartOfShiftValuesDTO.User;
            await _context.SaveChangesAsync();
            return car; 
        }
    public bool DataExist(string code)
    {
      return _context.CaractersStartOfShiftValues.Any(d => d.CodeCaracterStartOFShift.ToString() == code);
    }
  }
}
