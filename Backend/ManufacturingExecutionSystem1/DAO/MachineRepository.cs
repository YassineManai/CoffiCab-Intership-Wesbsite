using ManufacturingExecutionSystem1.GenericRepository;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Diagnostics;
using ManufacturingExecutionSystem1.Data;
using ManufacturingExecutionSystem1.entities;

namespace ManufacturingExecutionSystem1.Service
{
  public class MachineRepository : IRepository<Machine>
  {
    private Context _context;
    public MachineRepository(Context context)
    {
      this._context = context;
    }
    public async Task<Machine> Add(Machine model)
    {

      var pr = await _context.Machine.AddAsync(model);
      await _context.SaveChangesAsync();
      return pr.Entity;
    }

    public async Task Delete(string code)
    {
      var machineToDelete = await _context.Machine.FirstOrDefaultAsync(m => m.Machine_Code == code);


      if (machineToDelete != null)
      {
        _context.Machine.Remove(machineToDelete);
        await _context.SaveChangesAsync();

      }
    }

    public async Task<IEnumerable<Machine>> GetAll()
    {
      return await _context.Machine.ToListAsync();
    }

    public async Task<Machine> GetById(int id)
    {
      return await _context.Machine.FirstOrDefaultAsync(p => p.IDPlant_Machine == id);

    }
    public async Task<Machine> GetByCode(string code)
    {
      return await _context.Machine.FirstOrDefaultAsync(p => p.Machine_Code == code);
    }
    public async Task<Machine> Update(Machine machinedto)
    {
      var machine = await _context.Machine.FirstOrDefaultAsync(p => p.Machine_Code == machinedto.Machine_Code);
      if (machine != null)
      {
        machine.Description = machinedto.Description; machine.OK_Location = machinedto.OK_Location; machine.NOK_Warehouse = machinedto.NOK_Warehouse; machine.NOK_Location = machinedto.NOK_Location; machine.OK_Warehouse = machinedto.OK_Warehouse;
        machine.NameMachine = machinedto.NameMachine; machine.CodeProcess = machinedto.CodeProcess; machine.Bulding = machinedto.Bulding; machine.Code_Machine_OPC = machinedto.Code_Machine_OPC; machine.Code_Machine_Serial_Number = machinedto.Code_Machine_Serial_Number; machine.ActualUser = machinedto.ActualUser; machine.CodeZone = machinedto.CodeZone; machine.Type = machinedto.Type; machine.Aff_Input_Interface_Prod = machinedto.Aff_Input_Interface_Prod; machine.OnlyWithPO = machinedto.OnlyWithPO; machine.ActualRecette_ValitadedSetup = machinedto.ActualRecette_ValitadedSetup; machine.With_Consumption = machinedto.With_Consumption;
        machine.With_Integration_ERP = machinedto.With_Integration_ERP; machine.Dec_In_Quality = machinedto.Dec_In_Quality; machine.ActualUser_Qualite = machinedto.ActualUser_Qualite; machine.With_Contro_Input_BOM = machinedto.With_Contro_Input_BOM; machine.RepertoireReport = machinedto.RepertoireReport; machine.RepertoireReportArchive = machinedto.RepertoireReportArchive; machine.RepertoireReportRejete = machinedto.RepertoireReportRejete; machine.Rapport_Externe = machinedto.Rapport_Externe; machine.SN_Machine = machinedto.SN_Machine; machine.Plan_Affichage_Interface_Prod = machinedto.Plan_Affichage_Interface_Prod; machine.Verifiation_Complement_Par_Ligne = machinedto.Verifiation_Complement_Par_Ligne; machine.With_Remplissage = machinedto.With_Remplissage;
        machine.StartingTimeCalculeStop = machinedto.StartingTimeCalculeStop; machine.Format_Date_Report = machinedto.Format_Date_Report; machine.affectation_Direct_Ray = machinedto.affectation_Direct_Ray; machine.ReadingReport = machinedto.ReadingReport; machine.VerrouOF = machinedto.VerrouOF; machine.Type_Fic = machinedto.Type_Fic; machine.Type_Machine = machinedto.Type_Machine; machine.Grp_Objectif = machinedto.Grp_Objectif; machine.Code_Process2 = machinedto.Code_Process2; machine.Unite = machinedto.Unite; machine.Wip_After_Validation_QA = machinedto.Wip_After_Validation_QA; machine.Without_Quality = machinedto.Without_Quality; machine.Print_Label_CB_QA = machinedto.Print_Label_CB_QA; machine.TraitementPO = machinedto.TraitementPO; machine.NotConnected = machinedto.NotConnected; machine.ImprimanteCmes = machinedto.ImprimanteCmes;
        machine.ImprimantePanel = machinedto.ImprimantePanel; machine.With_Consumption_ERP = machinedto.With_Consumption_ERP; machine.With_Control_Insolation = machinedto.With_Control_Insolation; machine.With_Control_Colorant = machinedto.With_Control_Colorant; machine.With_Control_Tape = machinedto.With_Control_Tape; machine.With_Sequential_Consumption = machinedto.With_Sequential_Consumption; machine.WithScrapDeclaration = machinedto.WithScrapDeclaration; machine.ScrapDeclarationMode_A_1_M_0 = machinedto.ScrapDeclarationMode_A_1_M_0; machine.With_CB_In_Production_NOK = machinedto.With_CB_In_Production_NOK; machine.IRR_Real_Time_From_XML_File = machinedto.IRR_Real_Time_From_XML_File;
        machine.Disable_the_use_of_Machine_detected_Issues = machinedto.Disable_the_use_of_Machine_detected_Issues; machine.With_delete_report = machinedto.With_delete_report; machine.TPV100_100 = machinedto.TPV100_100; machine.With_Many_Input_For_Extrusion = machinedto.With_Many_Input_For_Extrusion; machine.Time_waiting_before_validation_next_report = machinedto.Time_waiting_before_validation_next_report; machine.Modif_Recipe_OPC_MUL = machinedto.Modif_Recipe_OPC_MUL; machine.Read_Report_With_Windows_Service = machinedto.Read_Report_With_Windows_Service;
        machine.With_PO_First = machinedto.With_PO_First; machine.WorkCenter = machinedto.WorkCenter;
        machine.Inc_Warehouse = machinedto.Inc_Warehouse; machine.Inc_Location = machinedto.Inc_Location; machine.Setup_Warehouse = machinedto.Setup_Warehouse; machine.Setup_Location = machinedto.Setup_Location; machine.Inspection_Warehouse = machinedto.Inspection_Warehouse; machine.Inspection_Location = machinedto.Inspection_Location;
        await _context.SaveChangesAsync();
        return machine;
      }
      return null;
    }
    public bool DataExist(string code)
    {
      return _context.Machine.Any(d => d.Machine_Code.ToString() == code);
    }
  }
}


