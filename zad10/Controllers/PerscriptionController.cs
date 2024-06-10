using Microsoft.AspNetCore.Mvc;
using zad10.Data;
using zad10.DTOs;
using zad10.Services;

namespace zad10.Controllers;

[Route("api/[controller]")]
[ApiController]
    public class PerscriptionController : ControllerBase
    {
        private readonly IDbService _dbService;

        public PerscriptionController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpPost("{IdPatient}/Perscriptions")]
        public async Task<IActionResult> AddNewPerscription(int IdPatient, NewPerscriptionDTO newPerscription)
        {
           if (newPerscription.Medicaments.Count > 10)
               return BadRequest("Recepta może obejmować maksymalnie 10 leków.");
           if (newPerscription.DueDate < newPerscription.Date)
               return BadRequest("DueDate musi być większy lub równy Date.");
           var patientExists = await _dbService.PatientExists(IdPatient);
           if (!patientExists)
           {
               var newPatient = new Patient
               {
                   IdPatient = IdPatient,
                   firstName = "Placeholder", // Uzupełnij odpowiednimi danymi
                   lastName = "Placeholder",  // Uzupełnij odpowiednimi danymi
                   BirthDate = DateTime.Now   // Uzupełnij odpowiednimi danymi
               };
               await _dbService.AddPatient(newPatient);
           }
           var perscription = new Perscription
           {
               Date = newPerscription.Date,
               DueDate = newPerscription.DueDate,
               IdPatient = IdPatient,
               IdDoctor = newPerscription.IdDoctor
           };
           await _dbService.AddPerscription(perscription);
           foreach (var medicamentDto in newPerscription.Medicaments)
           {
               var medicamentExists = await _dbService.MedicamentExists(medicamentDto.IdMedicament);
               if (!medicamentExists)
                   return BadRequest($"Lek o ID {medicamentDto.IdMedicament} nie istnieje.");
               var perscriptionMedicament = new Perscription_Medicament
               {
                   IdMedicament = medicamentDto.IdMedicament,
                   IdPerscription = perscription.IdPerscription,
                   dose = medicamentDto.Dose,
                   Details = medicamentDto.Details
               };
               await _dbService.AddPerscription_Medicament(perscriptionMedicament);
           }
           return Ok();
       }
}
    