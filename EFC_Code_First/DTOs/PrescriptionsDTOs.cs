namespace EFC_Code_First.Models
{
    public class PatientDto
    {
        public int IdPatient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly Birthdate { get; set; }
        public List<PrescriptionDto> Prescriptions { get; set; }
    }

    public class PrescriptionDto
    {
        public int IdPrescription { get; set; }
        public DateOnly Date { get; set; }
        public DateOnly DueDate { get; set; }
        public DoctorDto IdDoctorNavigation { get; set; }
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
}