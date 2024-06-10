namespace zad10.DTOs;

public class PatientDetailDTO
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public ICollection<PerscriptionDetailDTO> Perscriptions { get; set; } = new List<PerscriptionDetailDTO>();
}

public class PerscriptionDetailDTO
{
    public int IdPerscription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public DoctorDetailDTO Doctor { get; set; } = null!;
    public ICollection<MedicamentDetailDTO> Medicaments { get; set; } = new List<MedicamentDetailDTO>();
}

public class DoctorDetailDTO
{
    public int IdDoctor { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
}

public class MedicamentDetailDTO
{
    public int IdMedicament { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Type { get; set; } = null!;
    public int Dose { get; set; }
    public string? Details { get; set; }
}