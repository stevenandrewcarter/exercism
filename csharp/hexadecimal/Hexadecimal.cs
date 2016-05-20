using System;

class Hexadecimal
{
  public static int ToDecimal(string hex)
  {
    var result = 0.0;
    for (var i = 0; i < hex.Length; i++)
    {
      if (!char.IsLetterOrDigit(hex[i]))
        return 0;
      if (char.IsDigit(hex[i]))
      {
        result += char.GetNumericValue(hex[i]) * Math.Pow(16, hex.Length - (i + 1));
      }
      else if (char.IsLetter(hex[i]))
      {
        var offset = char.ToLower(hex[i]) - 97;
        if (offset > 6)
          return 0;
        result += (10 + offset) * Math.Pow(16, hex.Length - (i + 1));
      }
    }
    return (int)result;
  }
}
