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
  

  public class CaracterValues
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IDCaracterValues { get; set; }
    public string Value1Caracter { get; set; }
    [ForeignKey("Caracters")]
    [Required]
    [StringLength(50)]
    public string CodeCaracter { get; set; }
    public Caracters Caracters;
    public string ITemGroup { get; set; }
    public string Value2Caracter { get; set; }
    public string OperationArithmetique1 { get; set; }
    public string OperationArithmetique2 { get; set; }

  }
}
