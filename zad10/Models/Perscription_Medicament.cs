using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace zad10.Data;

[PrimaryKey(nameof(IdMedicament), nameof(IdPerscription))]
public class Perscription_Medicament
{
    [Key]
    public int IdMedicament { get; set; }
    
    [Key]
    public int IdPerscription { get; set; }
    
    public int dose { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string Details { get; set; }
}