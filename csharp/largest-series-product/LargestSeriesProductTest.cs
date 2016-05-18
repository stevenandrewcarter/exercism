using System;
using NUnit.Framework;
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

[TestFixture]
public class LargestSeriesProductTest
{
  [TestCase("01234567890", 2, ExpectedResult = 72)]
  [TestCase("1027839564", 3, ExpectedResult = 270)]
  public int Gets_the_largest_product(string digits, int seriesLength)
  {
    return new LargestSeriesProduct(digits).GetLargestProduct(seriesLength);
  }

  [Test]
  public void Largest_product_works_for_small_numbers()
  {
    Assert.That(new LargestSeriesProduct("19").GetLargestProduct(2), Is.EqualTo(9));
  }

  [Test]
  public void Largest_product_works_for_large_numbers()
  {
    const string LARGE_NUMBER = "73167176531330624919225119674426574742355349194934";
    Assert.That(new LargestSeriesProduct(LARGE_NUMBER).GetLargestProduct(6), Is.EqualTo(23520));
  }

  [TestCase("0000", 2, ExpectedResult = 0)]
  [TestCase("99099", 3, ExpectedResult = 0)]
  public int Largest_product_works_if_all_spans_contain_zero(string digits, int seriesLength)
  {
    return new LargestSeriesProduct(digits).GetLargestProduct(seriesLength);
  }

  [TestCase("", ExpectedResult = 1)]
  [TestCase("123", ExpectedResult = 1)]
  public int Largest_product_for_empty_span_is_1(string digits)
  {
    return new LargestSeriesProduct(digits).GetLargestProduct(0);
  }

  [TestCase("123", 4)]
  [TestCase("", 1)]
  public void Cannot_take_largest_product_of_more_digits_than_input(string digits, int seriesLength)
  {
    Assert.Throws<ArgumentException>(() => new LargestSeriesProduct(digits).GetLargestProduct(seriesLength));
  }
}