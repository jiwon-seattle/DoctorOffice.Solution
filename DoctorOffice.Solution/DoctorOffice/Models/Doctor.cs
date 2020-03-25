using System.Collections.Generic;
using System;

namespace DoctorOffice.Models
{
  public class Doctor
  {
    public int DoctorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Specialty { get; set; }
    public int PagerNumber { get; set; }
    public bool AcceptNewPatients { get; set; }
    public DateTime HireDate { get; set; }
    public virtual ApplicationUser User { get; set; }
    public ICollection<DoctorPatient> Patients { get; set; }
    public Doctor()
    {
      this.Patients = new HashSet<DoctorPatient>();
    }

  }
}