using System;
using System.Collections.Generic;

namespace DoctorOffice.Models
{
  public class Patient
  {
    public int PatientId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DOB { get; set; }
    public string PhoneNumber { get; set; }
    public string Allergies { get; set; }
    public string MedicalHistory { get; set; }
    public ICollection<DoctorPatient> Doctors { get; set; }

    public Patient()
    {
      this.Doctors = new HashSet<DoctorPatient>();
    }

  }
}