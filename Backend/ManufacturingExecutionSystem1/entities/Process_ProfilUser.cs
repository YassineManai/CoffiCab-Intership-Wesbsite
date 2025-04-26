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
 

  public class Process_ProfilUser
  {
    [Key, Column(Order = 1)]
    public string CodeProcess { get; set; }
    public Process Process;
    [Key, Column(Order = 2)]
    public string Id_Profil { get; set; }
    public ProfilUser ProfilUser;
  }
}
