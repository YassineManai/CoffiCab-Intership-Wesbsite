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
  
  [Index(nameof(CodeCaracter), IsUnique = true)]
  public class Caracters
  {
   [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IDCaracters { get; set; }
    [Key]
    [Required]
    [StringLength(50)]
    public string CodeCaracter { get; set; }
    public string DescCaracter { get; set; }
    public string Unit_of_measure { get; set; }
    public bool WithMaxMinValue { get; set; }
    public bool Visual_Value { get; set; }
    public bool IsUCS { get; set; }
    public bool Activated { get; set; }
    public bool IsSearchCreteria { get; set; }
    public bool Visible_InProductionView { get; set; }
    public bool VisibleInQualityView { get; set; }
    public bool Valeur { get; set; }
    public string Type { get; set; }
    public bool IsDatasheet { get; set; }
    [ForeignKey("Process")]
    [Required]
    [StringLength(50)]
    public string CodeProcess { get; set; }
    public Process Process;
    public bool ForInput { get; set; }
    public string MasqueSaisie { get; set; }
    public string Regroupement_Libille { get; set; }
    public int Ordre_Regroupement_Libille { get; set; }
    public int Ordre_Caracter { get; set; }
    public bool ParamStartOfShift { get; set; }
    public string Code_OPC { get; set; }
    public string LocalDescCaracter { get; set; }
    public bool IsToolingParameter { get; set; }
    public string? Image_Caracters { get; set; }
    public bool IsSpeed { get; set; }
    public bool Saisie_Automatique { get; set; }
    public bool IsRepetitif { get; set; }
    public string Lien_Cararactere_Nb_Repetition { get; set; }
    public bool IsResistance { get; set; }
    public bool Print_Character_In_Separate_Label { get; set; }
    public bool Activer_Controle_Soumission { get; set; }
    public List<CaracterValues> CaracterValues;
  }
}
