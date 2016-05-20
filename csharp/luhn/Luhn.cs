using System;
using System.Collections.Generic;
using System.Linq;

class Luhn
{
  public static int[] GenerateAddEnds(string numberString, bool alternating)
  {
    var addEnds = new List<int>();    
    for (var i = numberString.Length - 1; i >= 0; i--)
    {
      if (alternating)
      {
        var addEnd = (int)char.GetNumericValue(numberString[i]) * 2;
        addEnds.Add(addEnd > 9 ? addEnd - 9 : addEnd);
      }
      else
      {
        addEnds.Add((int)char.GetNumericValue(numberString[i]));
      }
      alternating = !alternating;
    }
    addEnds.Reverse();
    return addEnds.ToArray();
  }

  public Luhn(int aNumber)
  {
    var numberString = aNumber.ToString();
    CheckDigit = (int)char.GetNumericValue(numberString[numberString.Length - 1]);
    
    Addends = GenerateAddEnds(numberString, false);
    Checksum = Addends.Sum();
    Valid = Checksum % 10 == 0;
  }

  public int CheckDigit { get; }
  public int[] Addends { get; }
  public int Checksum { get; }
  public bool Valid { get; }

  public static Int64 Create(int aNumber)
  {
    var numberString = aNumber.ToString();
    var addEnds = GenerateAddEnds(numberString, true);
    var sumEnds = addEnds.Sum();
    if (sumEnds % 10 == 0)
    {
      numberString += "0";
    }
    else
    {
      var sumString = sumEnds.ToString();
      var lastNumber = char.GetNumericValue(sumString[sumString.Length - 1]);
      numberString += (10 - lastNumber).ToString();
    }
    return Int64.Parse(numberString);
  }
}