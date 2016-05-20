using System;

enum Schedule
{
  First,
  Second,
  Third,
  Fourth,
  Teenth,
  Last
}

class Meetup
{
  public Meetup(int aMonth, int aYear)
  {
    month = aMonth;
    year = aYear;
  }

  private DateTime GetNthOccuranceDayOfMonth(int nthOccurance, DayOfWeek dayOfWeek)
  {
    var occurance = 0;
    DateTime day = new DateTime();
    for (var i = 1; i <= DateTime.DaysInMonth(year, month); i++)
    {
      day = new DateTime(year, month, i);
      if (day.DayOfWeek == dayOfWeek)
      {
        occurance++;
        if (occurance == nthOccurance)
          break;
      }
    }
    return day;
  }

  public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
  {
    DateTime day = new DateTime(year, month, 1);

    switch (schedule)
    {
      case Schedule.First:
        day = GetNthOccuranceDayOfMonth(1, dayOfWeek);
        break;
      case Schedule.Second:
        day = GetNthOccuranceDayOfMonth(2, dayOfWeek);
        break;
      case Schedule.Third:
        day = GetNthOccuranceDayOfMonth(3, dayOfWeek);
        break;
      case Schedule.Fourth:
        day = GetNthOccuranceDayOfMonth(4, dayOfWeek);
        break;
      case Schedule.Teenth:
        for (var i = 13; i <= 19; i++)
        {
          day = new DateTime(year, month, i);
          if (day.DayOfWeek == dayOfWeek)
            break;
        }
        break;
      case Schedule.Last:
        for (var i = DateTime.DaysInMonth(year, month); i >= 1; i--)
        {
          day = new DateTime(year, month, i);
          if (day.DayOfWeek == dayOfWeek)
            break;
        }
        break;
    }
    return day;
  }

  private int month;
  private int year;
}