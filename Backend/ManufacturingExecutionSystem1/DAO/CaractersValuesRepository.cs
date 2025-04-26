
using ManufacturingExecutionSystem1.GenericRepository;
using Microsoft.EntityFrameworkCore;
using ManufacturingExecutionSystem1.Data;
using ManufacturingExecutionSystem1.entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ManufacturingExecutionSystem1.Service
{
  public class CaractersValuesRepository : IRepository<CaracterValues>
    {
        private Context _context;
        public CaractersValuesRepository(Context context)
        {
            _context = context;
        }
        public async Task<CaracterValues> Add(CaracterValues model)
        {
            var car = await _context.CaracterValues.AddAsync(model);
            await _context.SaveChangesAsync();
            return car.Entity;
        }

        public async Task Delete(string code)
        {
            var car = await _context.CaracterValues.FirstOrDefaultAsync(c => c.IDCaracterValues.ToString() == code);   
            if (car != null)
            {
                _context.CaracterValues.Remove(car);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CaracterValues>> GetAll()
        {
            return await _context.CaracterValues.ToListAsync();
        }

        public async Task<CaracterValues> GetById(int id)
        {
            return await _context.CaracterValues.FirstOrDefaultAsync(c => c.IDCaracterValues == id);
        }
    public async Task<CaracterValues> GetByCode(string code)
    {
      return await _context.CaracterValues.FirstOrDefaultAsync(c => c.IDCaracterValues.ToString() == code);
    }
    public async Task<CaracterValues> Update(CaracterValues caractersValuesDTO)
        {
            var cv = await _context.CaracterValues.FirstOrDefaultAsync(c => c.IDCaracterValues == caractersValuesDTO.IDCaracterValues);
            if (cv != null) {
                cv.Value1Caracter = caractersValuesDTO.Value1Caracter;
                cv.CodeCaracter = caractersValuesDTO.CodeCaracter;
                cv.ITemGroup = caractersValuesDTO.ITemGroup;
                cv.Value2Caracter = caractersValuesDTO.Value2Caracter;
                cv.OperationArithmetique1 = caractersValuesDTO.OperationArithmetique1;
                cv.OperationArithmetique2 = caractersValuesDTO.OperationArithmetique2; 
            await _context.SaveChangesAsync();
                return cv;
            }
            return null;
        }
    public bool DataExist(string code)
    {
      return _context.CaracterValues.Any(d => d.IDCaracterValues.ToString() == code);
    }
  }
}
