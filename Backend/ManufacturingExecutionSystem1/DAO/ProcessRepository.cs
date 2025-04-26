
using ManufacturingExecutionSystem1.GenericRepository;
using Microsoft.EntityFrameworkCore;
using ManufacturingExecutionSystem1.Data;
using ManufacturingExecutionSystem1.entities;
using System.Security.Cryptography.X509Certificates;


namespace ManufacturingExecutionSystem1.Service
{
  public class ProcessRepository : IRepository<Process>
    {

        private readonly Context _context;
        public ProcessRepository(Context context)
        {
            _context = context;
        }
        
        public async Task<Process> Add(Process model)
        {
           
            var pr = await _context.Process.AddAsync(model);
            
            await _context.SaveChangesAsync();
            return pr.Entity;
        }

        public async Task Delete(string code)
        {
            var pr = await _context.Process.FirstOrDefaultAsync(p => p.CodeProcess == code);
            if (pr != null)
            {
                _context.Process.Remove(pr);
                await _context.SaveChangesAsync();

            }
        }

        public async Task<IEnumerable<Process>> GetAll()
        {
            return await _context.Process.ToListAsync();
        }

        public async Task<Process> GetById(int id)
        {
      return await _context.Process.FirstOrDefaultAsync(p => p.IDPorcess == id);
      
        }
        public async Task<Process> GetByCode(string code)
    {
      return await _context.Process.FirstOrDefaultAsync(p=>p.CodeProcess==code);
    }

    public async Task<Process> Update(Process model)
        {
            var process = await _context.Process.FirstOrDefaultAsync(p => p.CodeProcess == model.CodeProcess);
            if (process != null)
            {
                process.DescProcess = model.DescProcess; process.Rework = model.Rework; process.WithSetupMandatory = model.WithSetupMandatory; process.WithToolingVerification = model.WithToolingVerification;
                process.WithIncomplete = model.WithIncomplete; process.WithQuality = model.WithQuality; process.WithValidationManualReport = model.WithValidationManualReport; process.WithQualityReturnValidation = model.WithQualityReturnValidation;
                process.ReturnValidationProfil = model.ReturnValidationProfil; process.WarehouseWithSupplierCode = model.WarehouseWithSupplierCode; process.InputForCmes = model.InputForCmes; process.Input_Manual_MetaliqueNumber = model.Input_Manual_MetaliqueNumber;
                process.WithoutFifo = model.WithoutFifo; process.Long_Machine_Stop_min = model.Long_Machine_Stop_min; process.FTQwithFirstValidationQuality = model.FTQwithFirstValidationQuality; process.HV_TEST = model.HV_TEST;
                process.WithValidationRequestInsolation = model.WithValidationRequestInsolation; process.WithValidationRequestColorant = model.WithValidationRequestColorant; process.WithScrapDeclaration = model.WithScrapDeclaration;
                process.QAStopLabelRed = model.QAStopLabelRed; process.Hide_HU_from_NOK_Quality_label = model.Hide_HU_from_NOK_Quality_label; process.FTQ_update_in_the_Same_Shift = model.FTQ_update_in_the_Same_Shift;
                process.Accept_OK_NOT_INC_Spools_As_input_Rewinders = model.Accept_OK_NOT_INC_Spools_As_input_Rewinders; process.EventDetectionIncludeSpooler = model.EventDetectionIncludeSpooler;
                process.Cnx_Par_Zone = model.Cnx_Par_Zone; process.With_Demarrage = model.With_Demarrage; process.NB_Wire_Fois_Recette = model.NB_Wire_Fois_Recette; process.Img_Process = model.Img_Process;
                process.CodeProcessToRework = model.CodeProcessToRework; process.Stock_In_LPDM = model.Stock_In_LPDM; process.StockName = model.StockName; process.Dechet_Activate = model.Dechet_Activate;
                process.With_Metalic_Number_In_Prod = model.With_Metalic_Number_In_Prod; process.WarehouseIncomplet = model.WarehouseIncomplet; process.Quality_100_100 = model.Quality_100_100; process.WarehouseCMES = model.WarehouseCMES;
                process.PLC_Assigned = model.PLC_Assigned;process.Warehouse_Metal = model.Warehouse_Metal;process.Many_Output_For_One_Input = model.Many_Output_For_One_Input;process.Model_Label = model.Model_Label; 
await _context.SaveChangesAsync(); 
                return process; 
            }
            return null;
            }
    public bool DataExist(string code)
    {
      return _context.Process.Any(d => d.CodeProcess.ToString() == code);
    }
  }
}

