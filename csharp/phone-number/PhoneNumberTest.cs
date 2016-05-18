using NUnit.Framework;
using System.Linq;

public class PhoneNumber
{
  public PhoneNumber(string aNumber)
  {
    Number = new string(aNumber.Where(c => char.IsDigit(c)).ToArray());
    if (Number.Length != 10)
    {
      Number = Number.Length > 10 && Number[0] == '1' ? Number.Remove(0, 1) : "0000000000";
    }
  }

  public string Number { get; private set; }
  public string AreaCode
  {
    get
    {
      return Number.Substring(0, 3);
    }
  }

  public override string ToString()
  {
    return "(" + AreaCode + ") " + Number.Substring(3, 3) + "-" + Number.Substring(6, 4);
  }
}

[TestFixture]
public class PhoneNumberTest
{
  [Test]
  public void Cleans_parens_spaces_and_dashes()
  {
    var phone = new PhoneNumber("(123) 456-7890");
    Assert.That(phone.Number, Is.EqualTo("1234567890"));
  }

  [Test]
  public void Cleans_numbers_with_dots()
  {
    var phone = new PhoneNumber("123.456.7890");
    Assert.That(phone.Number, Is.EqualTo("1234567890"));
  }

  [Test]
  public void Allows_us_country_code()
  {
    var phone = new PhoneNumber("11234567890");
    Assert.That(phone.Number, Is.EqualTo("1234567890"));
  }

  [Test]
  public void Invalid_when_11_digits()
  {
    var phone = new PhoneNumber("21234567890");
    Assert.That(phone.Number, Is.EqualTo("0000000000"));
  }

  [Test]
  public void Invalid_when_9_digits()
  {
    var phone = new PhoneNumber("123456789");
    Assert.That(phone.Number, Is.EqualTo("0000000000"));
  }

  [Test]
  public void Has_an_area_code()
  {
    var phone = new PhoneNumber("1234567890");
    Assert.That(phone.AreaCode, Is.EqualTo("123"));
  }

  [Test]
  public void Formats_a_number()
  {
    var phone = new PhoneNumber("1234567890");
    Assert.That(phone.ToString(), Is.EqualTo("(123) 456-7890"));
  }
}