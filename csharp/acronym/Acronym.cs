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
      var words = phrase.Split(' ');
      foreach (var word in words)
      {
        result += char.ToUpper(word[0]);
        for (var i = 1; i < word.Length; i++)
        {
          if (char.IsUpper(word[i]))
            result += word[i];
          else if (word[i] == '-')
            result += char.ToUpper(word[i + 1]);
        }
      }
    }
    return result;
  }
}