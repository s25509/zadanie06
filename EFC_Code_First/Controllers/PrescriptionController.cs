using EFC_Code_First.Context;
using EFC_Code_First.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFC_Code_First.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class PrescriptionController(AppDbContext context) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddNewPrescriptionAsync([FromBody] NewPrescriptionDto dto)
    {
        if (dto.DueDate < dto.Date.AddDays(30))
            return Conflict(
                "Due Date is too short. We want to give Patients at least 30 days to fill the Prescription.");

        if (dto.Medicaments.Count > 10)
            return Conflict("Can only put 10 Medicaments or less on one Prescription");

        await using var transaction = await context.Database.BeginTransactionAsync();

        var patient = await context.Patients.SingleOrDefaultAsync(
            p => p.FirstName == dto.Patient.FirstName &&
                 p.LastName == dto.Patient.LastName &&
                 p.Birthdate == dto.Patient.Birthdate
        );

        if (patient is null)
        {
            patient = new Patient
            {
                FirstName = dto.Patient.FirstName,
                LastName = dto.Patient.LastName,
                Birthdate = dto.Patient.Birthdate
            };

            await context.Patients.AddAsync(patient);
            await context.SaveChangesAsync();
        }
        else if (dto.Patient.FirstName != patient.FirstName ||
                 dto.Patient.LastName != patient.LastName ||
                 dto.Patient.Birthdate != patient.Birthdate)
        {
            await transaction.RollbackAsync();
            return Conflict("Provided Patient data doesn't match data already stored in the system");
        }

        var doctor = await context.Doctors.SingleOrDefaultAsync(
            d => d.FirstName == dto.Doctor.FirstName &&
                 d.LastName == dto.Doctor.LastName &&
                 d.Email == dto.Doctor.Email
        );

        if (doctor is null)
        {
            doctor = new Doctor
            {
                FirstName = dto.Doctor.FirstName,
                LastName = dto.Doctor.LastName,
                Email = dto.Doctor.Email
            };

            await context.Doctors.AddAsync(doctor);
            await context.SaveChangesAsync();
        }
        else if (dto.Doctor.FirstName != doctor.FirstName ||
                 dto.Doctor.LastName != doctor.LastName ||
                 dto.Doctor.Email != doctor.Email)
        {
            await transaction.RollbackAsync();
            return Conflict("Provided Doctor data doesn't match data already stored in the system");
        }

        var prescription = new Prescription
        {
            Date = dto.Date,
            DueDate = dto.DueDate,
            IdDoctor = doctor.IdDoctor,
            IdPatient = patient.IdPatient
        };
        await context.Prescriptions.AddAsync(prescription);
        await context.SaveChangesAsync();

        foreach (var newMedicament in dto.Medicaments)
        {
            var medicament = await context.Medicaments.SingleOrDefaultAsync(
                m => m.Name == newMedicament.Name &&
                     m.Type == newMedicament.Type
            );

            if (medicament is null)
            {
                await transaction.RollbackAsync();
                return NotFound($"Provided Medicament {newMedicament.Name} is not in the system");
            }

            var prescriptionMedicament = new PrescriptionMedicament
            {
                IdPrescription = prescription.IdPrescription,
                IdMedicament = medicament.IdMedicament,
                Dose = newMedicament.Dose,
                Details = newMedicament.Details
            };
            await context.PrescriptionMedicaments.AddAsync(prescriptionMedicament);
            await context.SaveChangesAsync();
        }
        
        await transaction.CommitAsync();
        return Ok();
    }
}