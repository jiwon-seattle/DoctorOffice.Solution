using Microsoft.EntityFrameworkCore;

namespace DoctorOffice.Models
{
  public class DoctorOffice : DbContext
  {
    public virtual DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<DoctorPatient> DoctorPatients { get; set; }
    public DoctorOfficeContext(DbContextOptions options) : base(options) { }
  }
}