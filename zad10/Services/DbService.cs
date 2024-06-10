using Microsoft.EntityFrameworkCore;
using zad10.Data;
using zad10.DTOs;

namespace zad10.Services;

public class DbService : IDbService
{
    private readonly myContext _context;

    public DbService(myContext context)
    {
        _context = context;
    }

    public async Task<bool> PatientExists(int idPatient)
    {
        return await _context.Patients.AnyAsync(p => p.IdPatient == idPatient);
    }

    public async Task AddPatient(Patient patient)
    {
        _context.Patients.Add(patient);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> MedicamentExists(int idMedicament)
    {
        return await _context.Medicaments.AnyAsync(m => m.IdMedicament == idMedicament);
    }

    public async Task AddPerscription(Perscription perscription)
    {
        _context.Perscriptions.Add(perscription);
        await _context.SaveChangesAsync();
    }
    

    public async Task AddPerscription_Medicament(Perscription_Medicament perscriptionMedicament)
    {
        _context.Perscription_Medicaments.Add(perscriptionMedicament);
        await _context.SaveChangesAsync();
    }
    public async Task<PatientDetailDTO?> GetPatientDetails(int idPatient)
    {
        var patient = await _context.Patients
            .Where(p => p.IdPatient == idPatient)
            .Select(p => new PatientDetailDTO
            {
                IdPatient = p.IdPatient,
                FirstName = p.firstName,
                LastName = p.lastName,
                BirthDate = p.BirthDate,
                Perscriptions = p.Perscriptions
                    .OrderBy(pr => pr.DueDate)
                    .Select(pr => new PerscriptionDetailDTO
                    {
                        IdPerscription = pr.IdPerscription,
                        Date = pr.Date,
                        DueDate = pr.DueDate,
                        Doctor = new DoctorDetailDTO
                        {
                            IdDoctor = pr.Doctor.IdDoctor,
                            FirstName = pr.Doctor.firstName,
                            LastName = pr.Doctor.lastName,
                            Email = pr.Doctor.email
                        },
                        Medicaments = pr.PerscriptionMedicaments
                            .Select(pm => new MedicamentDetailDTO
                            {
                                IdMedicament = pm.Medicament.IdMedicament,
                                Name = pm.Medicament.Name,
                                Description = pm.Medicament.Description,
                                Type = pm.Medicament.Type,
                                Dose = pm.dose,
                                Details = pm.Details
                            }).ToList()
                    }).ToList()
            })
            .FirstOrDefaultAsync();

        return patient;
    }
}