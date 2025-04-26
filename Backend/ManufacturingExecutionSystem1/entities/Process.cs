using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ManufacturingExecutionSystem1.entities
{
  [Index(nameof(CodeProcess), IsUnique = true)]
  public class Process
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IDPorcess { get; set; }
    [Key]
    [Required]
    [StringLength(50)]
    public string CodeProcess { get; set; }
   public string DescProcess { get; set; }
    public bool Rework { get; set; }
    public bool WithSetupMandatory { get; set; }
    public bool WithToolingVerification { get; set; }
    public bool WithIncomplete { get; set; }
    public bool WithQuality { get; set; }
    public bool WithValidationManualReport { get; set; }
    public bool WithQualityReturnValidation { get; set; }
    public string ReturnValidationProfil { get; set; }
    public bool WarehouseWithSupplierCode { get; set; }
    public bool InputForCmes { get; set; }
    public bool WarehouseCMES { get; set; }
    public bool Quality_100_100 { get; set; }
    public bool WarehouseIncomplet { get; set; }
    public bool With_Metalic_Number_In_Prod { get; set; }
    public bool Cnx_Par_Zone { get; set; }
    public bool With_Demarrage { get; set; }
    public bool NB_Wire_Fois_Recette { get; set; }
    public string Img_Process { get; set; }
    public string CodeProcessToRework { get; set; }
    public bool Stock_In_LPDM { get; set; }
    public string StockName { get; set; }
    public bool Dechet_Activate { get; set; }
    public string PLC_Assigned { get; set; }
    public bool Warehouse_Metal { get; set; }
    public bool Many_Output_For_One_Input { get; set; }
    public int Model_Label { get; set; }
    public bool Input_Manual_MetaliqueNumber { get; set; }
    public bool WithoutFifo { get; set; }
    public int Long_Machine_Stop_min { get; set; }
    public bool FTQwithFirstValidationQuality { get; set; }
    public bool HV_TEST { get; set; }
    public bool WithValidationRequestInsolation { get; set; }
    public bool WithValidationRequestColorant { get; set; }
    public bool WithScrapDeclaration { get; set; }
    public bool QAStopLabelRed { get; set; }
    public bool Hide_HU_from_NOK_Quality_label { get; set; }
    public bool FTQ_update_in_the_Same_Shift { get; set; }
    public bool Accept_OK_NOT_INC_Spools_As_input_Rewinders { get; set; }
    public bool EventDetectionIncludeSpooler { get; set; }
    public IEnumerable<Machine> Machines;
    public IEnumerable<Product> Products;
    public IEnumerable<Caracters> Caracters;
    public ICollection<ProfilUser> ProfilUsers;
    public ICollection<Process_ProfilUser> Process_ProfilUsers;
  }
}
