using System;
using System.Collections.Generic;
using System.Linq;

class PalindromeProduct
{
  public PalindromeProduct(int aValue)
  {
    Value = aValue;
    factors = new List<Tuple<int, int>>();
  }

  public void AddFactor(Tuple<int, int> aTuple)
  {
    factors.Add(aTuple);
    factors.Sort();
  }

  public int Value { get; private set; }
  public Tuple<int, int>[] Factors { get { return factors.ToArray(); } }
  private List<Tuple<int, int>> factors;
}

class Palindrome
{
  private static bool IsPalindrome(int value)
  {
    var valueText = value.ToString();
    return valueText == new string(valueText.ToCharArray().Reverse().ToArray());
  }

  private static Dictionary<int, PalindromeProduct> Generate(int minFactor, int maxFactor)
  {
    var palindromes = new Dictionary<int, PalindromeProduct>();
    for (var i = minFactor; i <= maxFactor; i++)
    {
      for (var j = minFactor; j <= i; j++)
      {
        var product = i * j;
        if (IsPalindrome(product))
        {
          var tuple = i < j ? new Tuple<int, int>(i, j) : new Tuple<int, int>(j, i);
          if (palindromes.ContainsKey(product))
          {
            palindromes[product].AddFactor(tuple);
          }
          else
          {
            var palindromeProduct = new PalindromeProduct(product);
            palindromeProduct.AddFactor(tuple);
            palindromes.Add(product, palindromeProduct);
          }
        }
      }
    }
    return palindromes;
  }

  public static PalindromeProduct Largest(int maxValue)
  {
    var result = Generate(1, maxValue);
    var keys = result.Keys.ToList();
    keys.Sort();
    return result[keys.Last()];
  }

  public static PalindromeProduct Largest(int minValue, int maxValue)
  {
    var result = Generate(minValue, maxValue);
    var keys = result.Keys.ToList();
    keys.Sort();
    return result[keys.Last()];
  }

  public static PalindromeProduct Smallest(int maxValue)
  {
    var result = Generate(1, maxValue);
    var keys = result.Keys.ToList();
    keys.Sort();
    return result[keys.First()];
  }

  public static PalindromeProduct Smallest(int minValue, int maxValue = 0)
  {
    var result = Generate(minValue, maxValue);
    var keys = result.Keys.ToList();
    keys.Sort();
    return result[keys.First()];
  }
}
