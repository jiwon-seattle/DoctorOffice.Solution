using Microsoft.EntityFrameworkCore;

namespace ProjectName.Models
{
  public class ProjectNameContext : DbContext
  {
    public virtual DbSet<ParentClassName> ParentClassesName { get; set; }
    public DbSet<ClassName> ClassesName { get; set; }
    public DbSet<ParentChildClassName> ParentChildClassName { get; set; }
    public ProjectNameContext(DbContextOptions options) : base(options) { }
  }
}