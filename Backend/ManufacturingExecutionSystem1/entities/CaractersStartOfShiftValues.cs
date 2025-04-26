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
  
  [Index(nameof(CodeCaracterStartOFShift), IsUnique = true)]
  public class CaractersStartOfShiftValues
  {
    
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IDCaractersStartOfShiftValues { get; set; }
    public string Value { get; set; }
    public string Id_Poste { get; set; }
    [Key]
    public string CodeCaracterStartOFShift { get; set; }
    [ForeignKey("Machine")]
    [Required]
    [StringLength(50)]
    public string Machine_Code { get; set; }
    public Machine Machine;
    public string User { get; set; }
  }
}
