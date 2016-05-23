class Acronym
{
  public static string Abbreviate(string phrase)
  {
    if (phrase.Length == 0) return "";
    var result = "";
    if (phrase.Contains(":"))
    {
      result = phrase.Substring(0, phrase.IndexOf(':'));
    }
    else
    {
      var words = phrase.Split(new char[] { ' ', '-' });
      foreach (var word in words)
      {
        result += word[0];
        for (var i = 1; i < word.Length; i++)
        {
          if (char.IsUpper(word[i]))
            result += word[i];
        }
      }
    }
    return result.ToUpper();
  }
}