using System.ComponentModel.DataAnnotations;

namespace zad10.DTOs;

public class NewPerscriptionDTO
{
    [Required]
    public int IdDoctor { get; set; }
        
    [Required]
    public DateTime Date { get; set; }
        
    [Required]
    public DateTime DueDate { get; set; }
        
    [MaxLength(300)]
    public string? Comments { get; set; } = null;
        
    [Required]
    public ICollection<NewPerscription_MedicamentDTO> Medicaments { get; set; } = new List<NewPerscription_MedicamentDTO>();
}

public class NewPerscription_MedicamentDTO
{
    [Required]
    public int IdMedicament { get; set; }
        
    [Required]
    [Range(1, int.MaxValue)]
    public int Dose { get; set; }
        
    [MaxLength(300)]
    public string? Details { get; set; }
}