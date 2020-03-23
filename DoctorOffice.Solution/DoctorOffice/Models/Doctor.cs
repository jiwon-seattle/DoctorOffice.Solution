using System;
using System.Collections.Generic;

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
    public ICollection<DoctorPatient> Patients { get; set; }
    public Doctor()
    {
      this.Patients = new HashSet<DoctorPatient>();
    }

  }
}