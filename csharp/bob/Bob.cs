class Bob
{
  private static bool IsUpper(string phrase)
  {
    var isUpper = true;
    foreach (var c in phrase)
    {
      if (char.IsLetter(c) && !char.IsUpper(c))
      {
        isUpper = false;
      }
    }
    return isUpper;
  }

  private static bool IsNumeric(string phrase)
  {
    var isNumeric = true;
    foreach (var c in phrase)
    {
      if (char.IsLetter(c))
      {
        isNumeric = false;
      }
    }
    return isNumeric;
  }

  public static string Hey(string phrase)
  {
    phrase = phrase.Trim();
    if (phrase.Length == 0)
    {
      return "Fine. Be that way!";
    }
    else if (!IsNumeric(phrase) && IsUpper(phrase))
    {
      return "Whoa, chill out!";
    }
    else if (phrase.EndsWith("?"))
    {
      return "Sure.";
    }
    return "Whatever.";
  }
}