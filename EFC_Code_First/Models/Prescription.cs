using System.Runtime.InteropServices.JavaScript;

namespace EFC_Code_First.Models;

public class Prescription
{
    public int idPrescription { get; set; }
    public int idPatient { get; set; }
    public int idDoctor { get; set; }
    public DateOnly Date { get; set; }
    public DateOnly DueDate { get; set; }

    public virtual Doctor IdStudentNavigation { get; set; }
    public virtual Patient IdGroupNavigation { get; set; }
}