using System;
using System.Collections.Generic;
using System.Linq;

public class LargestSeriesProduct
{
  public LargestSeriesProduct(string digits)
  {
    Digits = digits;
  }

  public int GetLargestProduct(int seriesLength)
  {
    if (seriesLength > Digits.Length) throw new ArgumentException();
    if (seriesLength == 0 || Digits.Length == 0) return 1;
    var productSets = new List<string>();
    for (var c = 0; c < Digits.Length; c++)
    {
      var set = Digits[c].ToString();
      for (var i = 1; i < seriesLength; i++)
      {
        if (c + i < Digits.Length)
          set += Digits[c + i];
      }
      if (set.Length == seriesLength)
        productSets.Add(set);
    }
    var results = new List<int>();
    foreach (var series in productSets)
    {
      var result = 1;
      foreach (var c in series)
      {
        result *= (int)char.GetNumericValue(c);
      }
      results.Add(result);
    }
    results = results.OrderByDescending(o => o).ToList();
    return results[0];
  }

  private string Digits { get; }
}