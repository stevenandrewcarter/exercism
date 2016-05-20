using System.Collections.Generic;

class Anagram
{
  public Anagram(string aBaseWord)
  {
    baseWord = aBaseWord.ToLower();
  }

  private bool ContainsWord(string word)
  {
    var contains = true;
    var tempBaseWord = baseWord;
    var compareWord = word.ToLower();
    foreach (var c in compareWord)
    {
      var characterLocation = tempBaseWord.IndexOf(c);
      if (characterLocation < 0)
      {
        contains = false;
      }
      else
      {
        tempBaseWord = tempBaseWord.Remove(characterLocation, 1);
      }
    }
    return contains;
  }

  public string[] Match(string[] words)
  {
    var matches = new List<string>();
    foreach (var word in words)
    {
      if (word.Length == baseWord.Length && word.ToLower() != baseWord.ToLower() && ContainsWord(word))
      {
        matches.Add(word);
      }
    }
    return matches.ToArray();
  }

  private string baseWord;
}