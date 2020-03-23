namespace ProjectName.Models
{
  public class ParentChildClassName
  {       
    public int ParentChildClassNameId { get; set; }
    public int ClassNameId { get; set; }
    public int ParentClassNameId { get; set; }
    public ClassName ClassName { get; set; }
    public ParentClassName ParentClassName { get; set; }
  }
}