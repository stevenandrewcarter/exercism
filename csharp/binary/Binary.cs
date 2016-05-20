using System;

public class Binary
{
  public static int ToDecimal(string binary)
  {
    var result = 0;
    for (var i = 0; i < binary.Length; i++)
    {
      if (char.IsLetter(binary[i]))
        return 0;
      var value = char.GetNumericValue(binary[i]);
      if (value < 0 || value > 1)
        return 0;
      result += (int)(value * Math.Pow(2.0, binary.Length - (i + 1)));
    }
    return result;
  }
}