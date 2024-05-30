﻿namespace EFC_Code_First.Models;

public class PrescriptionMedicament
{
    public int IdMedicament { get; set; }
    public int IdPrescription { get; set; }
    public int ?Dose { get; set; }
    public string Details { get; set; }

    public virtual Prescription IdPrescriptionNavigation { get; set; }
    public virtual Medicament IdMedicamentNavigation { get; set; }
}