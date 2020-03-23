using System.Collections.Generic;

namespace DoctorOffice.Models
{
  public class Doctor
  {
    public int DoctorId { get; set; }
    public ICollection<DoctorPatient> Patients { get; set; }
    public Doctor()
    {
      this.Patients = new HashSet<DoctorPatient>();
    }

  }
}