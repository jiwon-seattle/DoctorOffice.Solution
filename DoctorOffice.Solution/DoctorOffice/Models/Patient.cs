using System;
using System.Collections.Generic;

namespace DoctorOffice.Models
{
  public class Patient
  {
    public int PatientId { get; set; }
    public ICollection<DoctorPatient> Doctors { get; set; }

    public ClassName()
    {
      this.Doctors = new HashSet<DoctorPatient>();
    }

  }
}