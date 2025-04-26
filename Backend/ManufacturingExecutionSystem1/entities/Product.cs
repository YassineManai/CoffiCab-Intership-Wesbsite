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
  
  [Index(nameof(ItemCode), IsUnique = true)]
  [Index(nameof(LocalItemCode), IsUnique = true)]
  public class Product
  {

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IDProduct { get; set; }
    public string TypeProduct { get; set; }
    [Key]
    [Required]
    [StringLength(50)]
    public string ItemCode { get; set; }
    public string ItemDesc { get; set; }
    public string ParentItemCode { get; set; }
    public string Image { get; set; }
    [ForeignKey("Process")]
    [Required]
    [StringLength(50)]
    public string CodeProcess { get; set; }
    public Process Process;
    public int ParentIDProduct { get; set; }
    public string CodeItemModel { get; set; }
    public string ITemGroup { get; set; }
    public string Warehouse { get; set; }
    public float ConsumptionPerOneKM_outPut { get; set; }
    public string CodePAC { get; set; }
    public string COdeTPV { get; set; }
    public string CodeItemNature { get; set; }
    [Required]
    [StringLength(50)]
    public string LocalItemCode { get; set; }
    public string CodeRecette { get; set; }
    public float Speed { get; set; }
    public int CunsumptionCopperKgPerOneKM { get; set; }
    public int CunsumptionPVCKgPerOneKM { get; set; }
    public string Famille { get; set; }
    public string Section { get; set; }
    public string Couleur { get; set; }
    public string couleurP { get; set; }
    public string couleurS { get; set; }
    public string TypeMatiere { get; set; }
    public double Diametre { get; set; }
    public byte m_min_m_sec { get; set; }
    public string CodePAC_DVR { get; set; }
    public string CodeItemModel_DVR { get; set; }
    public string Code_Recette_DVR { get; set; }
    public bool With_Rewinder { get; set; }
    public bool FG { get; set; }
    public string InforItem { get; set; }
    public string Warehouse_WIP { get; set; }
    public float ResistanceOptimal { get; set; }
    public string CodeTPV_DVR { get; set; }
    public float Poids_Conducteur_Kg_Km { get; set; }
    public float Poids_Insolation_Kg_Km { get; set; }
    public string Couleur_Marquage { get; set; }

  }
}
