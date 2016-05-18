using NUnit.Framework;

class Clock
{
  public Clock(int aHours = 0, int aMinutes = 0)
  {
    hours = aHours;
    if (hours >= 24)
      hours -= 24;
    if (aMinutes == 60)
    {
      hours++;
      minutes = 0;
    }
    else
      minutes = aMinutes;
  }

  public Clock Add(int aMinutes)
  {
    var newHours = hours;
    var newMinutes = minutes + aMinutes;
    while (newMinutes > 60)
    {
      newHours++;
      if (newHours > 23)
        newHours = 0;
      newMinutes -= 60;
    }
    return new Clock(newHours, newMinutes);
  }

  public Clock Subtract(int aMinutes)
  {
    var newHours = hours;
    var newMinutes = minutes - aMinutes;
    while (newMinutes < 0)
    {
      newHours--;
      if (newHours < 0)
        newHours = 23;
      newMinutes += 60;
    }
    return new Clock(newHours, newMinutes);
  }

  public override string ToString()
  {
    return hours.ToString().PadLeft(2, '0') + ":" + minutes.ToString().PadLeft(2, '0');
  }

  public override bool Equals(object obj)
  {
    return obj.ToString() == ToString();
  }

  private int hours;
  private int minutes;
}

[TestFixture]
public class ClockTest
{
  [TestCase(8, "08:00")]
  [TestCase(9, "09:00")]
  public void Prints_the_hour(int hours, string expected)
  {
    Assert.That(new Clock(hours).ToString(), Is.EqualTo(expected));
  }

  [TestCase(11, 9, "11:09")]
  [TestCase(11, 19, "11:19")]
  public void Prints_past_the_hour(int hours, int minutes, string expected)
  {
    Assert.That(new Clock(hours, minutes).ToString(), Is.EqualTo(expected));
  }

  [Test]
  public void Can_add_minutes()
  {
    var clock = new Clock(10).Add(3);
    Assert.That(clock.ToString(), Is.EqualTo("10:03"));
  }

  [Test]
  public void Can_add_over_an_hour()
  {
    var clock = new Clock(10).Add(63);
    Assert.That(clock.ToString(), Is.EqualTo("11:03"));
  }

  [Test]
  public void Can_add_over_more_than_one_day()
  {
    var clock = new Clock(10).Add(7224);
    Assert.That(clock.ToString(), Is.EqualTo("10:24"));
  }

  [Test]
  public void Can_subtract_minutes()
  {
    var clock = new Clock(10, 3).Subtract(3);
    Assert.That(clock.ToString(), Is.EqualTo("10:00"));
  }

  [Test]
  public void Can_subtract_to_previous_hour()
  {
    var clock = new Clock(10, 3).Subtract(30);
    Assert.That(clock.ToString(), Is.EqualTo("09:33"));
  }

  [Test]
  public void Can_subtract_over_an_hour()
  {
    var clock = new Clock(10, 3).Subtract(70);
    Assert.That(clock.ToString(), Is.EqualTo("08:53"));
  }

  [Test]
  public void Wraps_around_midnight()
  {
    var clock = new Clock(23, 59).Add(2);
    Assert.That(clock.ToString(), Is.EqualTo("00:01"));
  }

  [Test]
  public void Wraps_around_midnight_backwards()
  {
    var clock = new Clock(0, 1).Subtract(2);
    Assert.That(clock.ToString(), Is.EqualTo("23:59"));
  }

  [Test]
  public void Midnight_is_zero_hundred_hours()
  {
    var clock = new Clock(24);
    Assert.That(clock.ToString(), Is.EqualTo("00:00"));
  }

  [Test]
  public void Sixty_minutes_is_next_hour()
  {
    var clock = new Clock(1, 60);
    Assert.That(clock.ToString(), Is.EqualTo("02:00"));
  }
  
  [Test]
  public void Clocks_with_same_time_are_equal()
  {
    var clock1 = new Clock(14, 30);
    var clock2 = new Clock(14, 30);
    Assert.That(clock1, Is.EqualTo(clock2));
  }
  
  [Test]
  public void Overflown_clocks_with_same_time_are_equal()
  {
    var clock1 = new Clock(14, 30);
    var clock2 = new Clock(38, 30);
    Assert.That(clock1, Is.EqualTo(clock2));
  }
}