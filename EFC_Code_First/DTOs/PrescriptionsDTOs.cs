namespace EFC_Code_First.Models
{
    public class PatientDto
    {
        public int IdPatient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public List<PrescriptionDto> Prescriptions { get; set; }
    }

    public class PrescriptionDto
    {
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public DoctorDto Doctor { get; set; }
        public List<MedicamentDto> Medicaments { get; set; }
    }

    public class DoctorDto
    {
        public int IdDoctor { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public class MedicamentDto
    {
        public int IdMedicament { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }

    public class NewPrescriptionDto
    {
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public NewDoctorDto Doctor { get; set; }
        public NewPatientDto Patient { get; set; }
        public List<NewMedicamentDto> Medicaments { get; set; }
    }

    public class NewMedicamentDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Details { get; set; }
        public int ?Dose { get; set; }
    }

    public class NewPatientDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
    }

    public class NewDoctorDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}