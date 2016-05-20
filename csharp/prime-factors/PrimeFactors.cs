using System.Collections.Generic;

class PrimeFactors
{
  public static int[] For(long number)
  {
    var factors = new List<int>();
    for (var div = 2; div <= number; div++)
    {
      while (number % div == 0)
      {
        factors.Add(div);
        number = number / div;
      }
    }
    return factors.ToArray();
  }
}