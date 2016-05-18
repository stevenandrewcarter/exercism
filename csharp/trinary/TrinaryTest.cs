using NUnit.Framework;
using System;

class Trinary
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
        if (number > 2)
          return 0;
        result += number * (int)Math.Pow(3, position);        
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

[TestFixture]
public class TrinaryTest
{
  // change Ignore to false to run test case or just remove 'Ignore = true'
  [TestCase("1", ExpectedResult = 1)]
  [TestCase("2", ExpectedResult = 2)]
  [TestCase("10", ExpectedResult = 3)]
  [TestCase("11", ExpectedResult = 4)]
  [TestCase("100", ExpectedResult = 9)]
  [TestCase("112", ExpectedResult = 14)]
  [TestCase("222", ExpectedResult = 26)]
  [TestCase("1122000120", ExpectedResult = 32091)]
  public int Trinary_converts_to_decimal(string value)
  {
    return Trinary.ToDecimal(value);
  }

  [TestCase("carrot")]
  [TestCase("3")]
  [TestCase("6")]
  [TestCase("9")]
  [TestCase("124578")]
  [TestCase("abc1z")]
  public void Invalid_trinary_is_decimal_0(string invalidValue)
  {
    Assert.That(Trinary.ToDecimal(invalidValue), Is.EqualTo(0));
  }
  
  [Test]
  public void Trinary_can_convert_formatted_strings()
  {
    Assert.That(Trinary.ToDecimal("011"), Is.EqualTo(4));
  }
}