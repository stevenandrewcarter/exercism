using System;
using System.Text;

public class Robot
{
  public Robot()
  {
    GenerateName();
  }

  public void Reset()
  {
    GenerateName();
  }

  public string Name { get; private set; }

  private void GenerateName()
  {
    var sb = new StringBuilder();
    var r = new Random(Guid.NewGuid().GetHashCode());
    sb.Append((char)r.Next(65, 90));
    sb.Append((char)r.Next(65, 90));
    sb.Append((char)r.Next(48, 57));
    sb.Append((char)r.Next(48, 57));
    sb.Append((char)r.Next(48, 57));
    Name = sb.ToString();
  }
}