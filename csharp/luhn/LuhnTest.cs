using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

class Luhn
{
  public Luhn(int aNumber)
  {
    var numberString = aNumber.ToString();
    CheckDigit = (int)char.GetNumericValue(numberString[numberString.Length - 1]);
    var addEnds = new List<int>();
    var alternating = false;
    for (var i = numberString.Length - 1; i >= 0; i--)
    {
      if (alternating)
      {
        alternating = false;
        var addEnd = (int)char.GetNumericValue(numberString[i]) * 2;
        addEnds.Add(addEnd > 9 ? addEnd - 9 : addEnd);
      }
      else
      {
        alternating = true;
        addEnds.Add((int)char.GetNumericValue(numberString[i]));
      }
    }
    addEnds.Reverse();
    Addends = addEnds.ToArray();
    Checksum = addEnds.Sum();
    Valid = Checksum % 10 == 0;
  }

  public int CheckDigit { get; }
  public int[] Addends { get; }
  public int Checksum { get; }
  public bool Valid { get; }

  public static Int64 Create(int aNumber)
  {
    var numberString = aNumber.ToString();
    var addEnds = new List<int>();
    var alternating = true;
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

[TestFixture]
public class LuhnTest
{
  [Test]
  public void Check_digit_is_the_rightmost_digit()
  {
    Assert.That(new Luhn(34567).CheckDigit, Is.EqualTo(7));
  }
  
  [Test]
  public void Addends_doubles_every_other_number_from_the_right()
  {
    Assert.That(new Luhn(12121).Addends, Is.EqualTo(new[] { 1, 4, 1, 4, 1 }));
  }

  [Test]
  public void Addends_subtracts_9_when_doubled_number_is_more_than_9()
  {
    Assert.That(new Luhn(8631).Addends, Is.EqualTo(new[] { 7, 6, 6, 1 }));
  }
  
  [TestCase(4913, ExpectedResult = 22)]
  [TestCase(201773, ExpectedResult = 21)]
  public int Checksum_adds_addends_together(int number)
  {
    return new Luhn(number).Checksum;
  }
  
  [TestCase(738, ExpectedResult = false)]
  [TestCase(8739567, ExpectedResult = true)]
  public bool Number_is_valid_when_checksum_mod_10_is_zero(int number)
  {
    return new Luhn(number).Valid;
  }
  
  [Test]
  public void Luhn_can_create_simple_numbers_with_valid_check_digit()
  {
    Assert.That(Luhn.Create(123), Is.EqualTo(1230));
  }
  
  [Test]
  public void Luhn_can_create_larger_numbers_with_valid_check_digit()
  {
    Assert.That(Luhn.Create(873956), Is.EqualTo(8739567));
  }
  
  [Test]
  public void Luhn_can_create_huge_numbers_with_valid_check_digit()
  {
    Assert.That(Luhn.Create(837263756), Is.EqualTo(8372637564));
  }
}