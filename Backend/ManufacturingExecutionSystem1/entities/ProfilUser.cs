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
  [Index(nameof(Id_Profil), IsUnique = true)]
  public class ProfilUser
  {

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IDProfiUser { get; set; }
    [Key]
    [Required]
    [StringLength(50)]
    public string Id_Profil { get; set; }
    public string NomProfil { get; set; }
    public List<Process_ProfilUser> Process_ProfilUsers;
    public ICollection<Process> Processes;
    public List<ProgProfil> ProgProfiles;

  }
}
