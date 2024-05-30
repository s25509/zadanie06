﻿namespace EFC_Code_First.Models;

public class Patient
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly Birthdate { get; set; }
    
    public virtual ICollection<Prescription> Prescriptions { get; set; }
}