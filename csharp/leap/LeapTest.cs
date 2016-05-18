using NUnit.Framework;

class Year
{
  public static bool IsLeap(int year)
  {
    if (year % 4 == 0)
    {
      if (year % 100 == 0 && year % 400 != 0)
      {
        return false;
      }
      return true;
    }
    return false;
  }
}

[TestFixture]
public class LeapTest
{
    [Test]
    public void Valid_leap_year()
    {
        Assert.That(Year.IsLeap(1996), Is.True);
    }
    
    [Test]
    public void Invalid_leap_year()
    {
        Assert.That(Year.IsLeap(1997), Is.False);
    }

    [Test]
    public void Turn_of_the_20th_century_is_not_a_leap_year()
    {
        Assert.That(Year.IsLeap(1900), Is.False);
    }

    [Test]
    public void Turn_of_the_25th_century_is_a_leap_year()
    {
        Assert.That(Year.IsLeap(2400), Is.True);
    }
}