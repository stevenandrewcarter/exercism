using NUnit.Framework;
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

[TestFixture]
public class HexadecimalTest
{
  // change Ignore to false to run test case or just remove 'Ignore = true'
  [TestCase("1", ExpectedResult = 1)]
  [TestCase("c", ExpectedResult = 12)]
  [TestCase("10", ExpectedResult = 16)]
  [TestCase("af", ExpectedResult = 175)]
  [TestCase("100", ExpectedResult = 256)]
  [TestCase("19ace", ExpectedResult = 105166)]
  [TestCase("19ace", ExpectedResult = 105166)]
  public int Hexadecimal_converts_to_decimal(string hexadecimal)
  {
    return Hexadecimal.ToDecimal(hexadecimal);
  }

  [Test]
  public void Invalid_hexadecimal_is_decimal_0()
  {
    Assert.That(Hexadecimal.ToDecimal("carrot"), Is.EqualTo(0));
  }

  [TestCase("000000", ExpectedResult = 0)]
  [TestCase("ffffff", ExpectedResult = 16777215)]
  [TestCase("ffff00", ExpectedResult = 16776960)]
  public int Octal_can_convert_formatted_strings(string hexidecimal)
  {
    return Hexadecimal.ToDecimal(hexidecimal);
  }
}