using System.ServiceModel;

namespace ClassLibrary1
{
  public class ServerUser
  {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public OperationContext operationContext { get; set; }
  }
}
