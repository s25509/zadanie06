using System.Runtime.InteropServices.JavaScript;

namespace EFC_Code_First.Models;

public class Prescription
{
    public int IdPrescription { get; set; }
    public int IdPatient { get; set; }
    public int IdDoctor { get; set; }
    public DateOnly Date { get; set; }
    public DateOnly DueDate { get; set; }

    public virtual Doctor IdStudentNavigation { get; set; }
    public virtual Patient IdGroupNavigation { get; set; }
}