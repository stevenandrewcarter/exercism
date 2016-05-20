using System;

class Gigasecond
{
  public static DateTime Date(DateTime startDate)
  {
    DateTime newDate = startDate;
    newDate = newDate.AddSeconds(Math.Pow(10, 9));
    return newDate;
  }
}
