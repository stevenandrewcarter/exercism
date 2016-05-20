using System.Collections.Generic;
using System.Text;

class Phrase
{
  private static string[] GetWords(string phrase)
  {
    var sb = new StringBuilder();
    for (var i = 0; i < phrase.Length; i++)
    {
      var c = phrase[i];
      if (char.IsLetterOrDigit(c) || (c == '\'' && (char.IsLetterOrDigit(phrase[i - 1]) || char.IsLetterOrDigit(phrase[i + 1]))))
      {
        sb.Append(c);
      }
      else
      {
        sb.Append(' ');
      }
    }
    var words = sb.ToString().ToLower().Split(' ');
    var collapsedWords = new List<string>();
    // Collapse Array and remove blank entries
    foreach (var word in words)
    {
      if (word.Length > 0)
      {
        var addedWord = word;
        if (word.StartsWith("'"))
        {
          addedWord = word.Remove(0, 1);
        }
        else if (word.EndsWith("'"))
        {
          addedWord = word.Remove(word.Length - 1);
        }
        collapsedWords.Add(addedWord);
      }
    }
    return collapsedWords.ToArray();
  }

  public static Dictionary<string, int> WordCount(string phrase)
  {
    var counts = new Dictionary<string, int>();
    var words = GetWords(phrase);
    foreach (var word in words)
    {
      if (counts.ContainsKey(word))
      {
        counts[word]++;
      }
      else
      {
        counts.Add(word, 1);
      }
    }
    return counts;
  }
}