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

  [Index(nameof(Machine_Code), IsUnique = true)]
  [Index(nameof(Code_Machine_OPC), IsUnique = true)]
  [Index(nameof(Code_Machine_Serial_Number), IsUnique = true)]

  public class Machine
  {

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IDPlant_Machine { get; set; }
    [Key]
    [Required]
    [StringLength(50)]
    public string Machine_Code { get; set; }
    public string? Description { get; set; }
    public string? NOK_Location { get; set; }
    public string? NOK_Warehouse { get; set; }
    public string? OK_Location { get; set; }
    public string? OK_Warehouse { get; set; }
    public string? NameMachine { get; set; }
    [ForeignKey("Process")]
    [Required]
    [StringLength(50)]
    public string CodeProcess { get; set; }
    public Process Process;
    public string? Bulding { get; set; }
    public string Code_Machine_OPC { get; set; }
    public string Code_Machine_Serial_Number { get; set; }
    public string? ActualUser { get; set; }
    public string? CodeZone { get; set; }
    public string? Type { get; set; }
    public byte? Aff_Input_Interface_Prod { get; set; }
    public bool? OnlyWithPO { get; set; }
    public bool? ActualRecette_ValitadedSetup { get; set; }
    public bool? With_Consumption { get; set; }
    public bool? With_Integration_ERP { get; set; }
    public bool? Dec_In_Quality { get; set; }
    public string? ActualUser_Qualite { get; set; }
    public bool? With_Contro_Input_BOM { get; set; }
    public string? RepertoireReport { get; set; }
    public string? RepertoireReportArchive { get; set; }
    public string? RepertoireReportRejete { get; set; }
    public bool? Rapport_Externe { get; set; }
    public bool? SN_Machine { get; set; }
    public byte? Plan_Affichage_Interface_Prod { get; set; }
    public bool? Verifiation_Complement_Par_Ligne { get; set; }
    public bool? With_Remplissage { get; set; }
    public int? StartingTimeCalculeStop { get; set; }
    public string? Format_Date_Report { get; set; }
    public bool? affectation_Direct_Ray { get; set; }
    public string? ReadingReport { get; set; }
    public bool? VerrouOF { get; set; }
    public string? Type_Fic { get; set; }
    public string? Type_Machine { get; set; }
    public string? Grp_Objectif { get; set; }
    public string? Code_Process2 { get; set; }
    public string? Unite { get; set; }
    public bool? Wip_After_Validation_QA { get; set; }
    public bool? Without_Quality { get; set; }
    public bool? Print_Label_CB_QA { get; set; }
    public byte? TraitementPO { get; set; }
    public bool? NotConnected { get; set; }
    public string? ImprimanteCmes { get; set; }
    public string? ImprimantePanel { get; set; }
    public bool? With_Consumption_ERP { get; set; }
    public bool? With_Control_Insolation { get; set; }
    public bool? With_Control_Colorant { get; set; }
    public bool? With_Control_Tape { get; set; }
    public bool? With_Sequential_Consumption { get; set; }
    public bool? WithScrapDeclaration { get; set; }
    public bool? ScrapDeclarationMode_A_1_M_0 { get; set; }
    public bool? With_CB_In_Production_NOK { get; set; }
    public bool? IRR_Real_Time_From_XML_File { get; set; }
    public bool? Disable_the_use_of_Machine_detected_Issues { get; set; }
    public bool? With_delete_report { get; set; }
    public bool? TPV100_100 { get; set; }
    public bool? With_Many_Input_For_Extrusion { get; set; }
    public int? Time_waiting_before_validation_next_report { get; set; }
    public bool? Modif_Recipe_OPC_MUL { get; set; }
    public bool? Read_Report_With_Windows_Service { get; set; }
    public bool? With_PO_First { get; set; }
    public string? WorkCenter { get; set; }
    public string? Inc_Warehouse { get; set; }
    public string? Inc_Location { get; set; }
    public string? Setup_Warehouse { get; set; }
    public string? Setup_Location { get; set; }
    public string? Inspection_Warehouse { get; set; }
    public string? Inspection_Location { get; set; }
    public IEnumerable<CaractersStartOfShiftValues>? CaractersStartOfShiftValues;
  }
}
