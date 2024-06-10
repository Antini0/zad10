using zad10.Data;
using zad10.DTOs;

namespace zad10.Services;

public interface IDbService
{
    Task<bool> PatientExists(int idPatient);
    Task AddPatient(Patient patient);
    Task<bool> MedicamentExists(int idMedicament);
    Task AddPerscription(Perscription perscription);
    Task AddPerscription_Medicament(Perscription_Medicament perscriptionMedicament);
    Task<PatientDetailDTO?> GetPatientDetails(int idPatient);
}