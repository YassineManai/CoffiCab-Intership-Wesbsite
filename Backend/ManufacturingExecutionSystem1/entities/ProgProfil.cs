using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingExecutionSystem1.entities
{
  public class ProgProfil
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IDProgProfil { get; set; }
    [ForeignKey(nameof(ProfilUser))]
    [Required]
    public string Id_Profil { get; set; }
    public ProfilUser ProfilUser;
    public string LibProgramme { get; set; }
    public string NomProgramme { get; set; }
    public string Intitule { get; set; }
    public bool onlyconsultation { get; set; }

  }
}
