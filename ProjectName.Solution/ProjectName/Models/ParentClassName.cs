using System.Collections.Generic;

namespace ProjectName.Models
{
  public class ParentClassName
  {
    public int ParentClassNameId { get; set; }
    public ICollection<ParentChildClassName> ParentChildClassesName { get; set; }
    public ParentClassName()
    {
      this.ClassesName = new HashSet<ParentChildClassName>();
    }

  }
}