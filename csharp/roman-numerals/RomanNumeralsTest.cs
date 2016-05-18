using NUnit.Framework;

namespace ExtensionMethods
{
  public static class MyExtensions
  {
    public static string ToRoman(this int number)
    {
      if ((number < 0) || (number > 3999)) throw new System.ArgumentOutOfRangeException("insert value betwheen 1 and 3999");
      if (number < 1) return string.Empty;
      if (number >= 1000) return "M" + ToRoman(number - 1000);
      if (number >= 900) return "CM" + ToRoman(number - 900); //EDIT: i've typed 400 instead 900
      if (number >= 500) return "D" + ToRoman(number - 500);
      if (number >= 400) return "CD" + ToRoman(number - 400);
      if (number >= 100) return "C" + ToRoman(number - 100);
      if (number >= 90) return "XC" + ToRoman(number - 90);
      if (number >= 50) return "L" + ToRoman(number - 50);
      if (number >= 40) return "XL" + ToRoman(number - 40);
      if (number >= 10) return "X" + ToRoman(number - 10);
      if (number >= 9) return "IX" + ToRoman(number - 9);
      if (number >= 5) return "V" + ToRoman(number - 5);
      if (number >= 4) return "IV" + ToRoman(number - 4);
      if (number >= 1) return "I" + ToRoman(number - 1);
      throw new System.ArgumentOutOfRangeException("something bad happened");
    }
  }

  [TestFixture]
  public class RomanNumeralsTest
  {
    // Change 'Ignore = true' to 'Ignore = false' to run a test case.
    // You can also just remove 'Ignore = true'.
    [TestCase(0, ExpectedResult = "")]
    [TestCase(1, ExpectedResult = "I")]
    [TestCase(2, ExpectedResult = "II")]
    [TestCase(3, ExpectedResult = "III")]
    [TestCase(4, ExpectedResult = "IV")]
    [TestCase(5, ExpectedResult = "V")]
    [TestCase(6, ExpectedResult = "VI")]
    [TestCase(9, ExpectedResult = "IX")]
    [TestCase(27, ExpectedResult = "XXVII")]
    [TestCase(48, ExpectedResult = "XLVIII")]
    [TestCase(59, ExpectedResult = "LIX")]
    [TestCase(93, ExpectedResult = "XCIII")]
    [TestCase(141, ExpectedResult = "CXLI")]
    [TestCase(163, ExpectedResult = "CLXIII")]
    [TestCase(402, ExpectedResult = "CDII")]
    [TestCase(575, ExpectedResult = "DLXXV")]
    [TestCase(911, ExpectedResult = "CMXI")]
    [TestCase(1024, ExpectedResult = "MXXIV")]
    [TestCase(3000, ExpectedResult = "MMM")]
    public string Convert_roman_to_arabic_numerals(int arabicNumeral)
    {
      return arabicNumeral.ToRoman();
    }
  }
}