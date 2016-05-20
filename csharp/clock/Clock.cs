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