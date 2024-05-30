using EFC_Code_First.Context;
using EFC_Code_First.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFC_Code_First.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class PatientController(AppDbContext context) : ControllerBase
{
    [HttpGet("{idPatient:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPatientWithAllDataAsync(int idPatient)
    {
        var patient = await context.Patients
            .Where(p => p.IdPatient == idPatient)
            .Include(p => p.Prescriptions)
            .ThenInclude(pr => pr.IdDoctorNavigation)
            .Include(p => p.Prescriptions)
            .ThenInclude(pr => pr.PrescriptionMedicaments)
            .ThenInclude(pm => pm.IdMedicamentNavigation)
            .Select(p => new PatientDto
            {
                IdPatient = p.IdPatient,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Birthdate = p.Birthdate,
                Prescriptions = p.Prescriptions
                    .OrderByDescending(pr => pr.DueDate)
                    .Select(pr => new PrescriptionDto
                    {
                        IdPrescription = pr.IdPrescription,
                        Date = pr.Date,
                        DueDate = pr.DueDate,
                        Doctor = new DoctorDto
                        {
                            IdDoctor = pr.IdDoctorNavigation.IdDoctor,
                            FirstName = pr.IdDoctorNavigation.FirstName,
                            LastName = pr.IdDoctorNavigation.LastName,
                            Email = pr.IdDoctorNavigation.Email
                        },
                        Medicaments = pr.PrescriptionMedicaments.Select(pm => new MedicamentDto
                            {
                                IdMedicament = pm.IdMedicamentNavigation.IdMedicament,
                                Name = pm.IdMedicamentNavigation.Name,
                                Description = pm.IdMedicamentNavigation.Description,
                                Type = pm.IdMedicamentNavigation.Type
                            }
                        ).ToList()
                    }
                ).ToList()
            })
            .FirstOrDefaultAsync();

        if (patient is null) return NotFound($"Patient with ID: {idPatient} not found");

        return Ok(patient);
    }
}