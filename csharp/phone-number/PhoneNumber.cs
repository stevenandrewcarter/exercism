using System.Linq;

public class PhoneNumber
{
  public PhoneNumber(string aNumber)
  {
    Number = new string(aNumber.Where(c => char.IsDigit(c)).ToArray());
    if (Number.Length != 10)
    {
      Number = Number.Length > 10 && Number[0] == '1' ? Number.Remove(0, 1) : "0000000000";
    }
  }

  public string Number { get; private set; }
  public string AreaCode
  {
    get
    {
      return Number.Substring(0, 3);
    }
  }

  public override string ToString()
  {
    return "(" + AreaCode + ") " + Number.Substring(3, 3) + "-" + Number.Substring(6, 4);
  }
}