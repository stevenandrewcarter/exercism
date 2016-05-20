using System;

class Octal
{
  public static int ToDecimal(string value)
  {
    var result = 0;
    var position = value.Length - 1;
    foreach (var c in value)
    {
      if (char.IsDigit(c))
      {
        var number = (int)char.GetNumericValue(c);
        if (number > 7)
          return 0;
        result += number * (int)Math.Pow(8, position);
        position--;
      }
      else
      {
        return 0;
      }
    }
    return result;
  }
}