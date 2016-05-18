using System.Collections.Generic;
using NUnit.Framework;
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

[TestFixture]
public class WordCountTest
{
  [Test]
  public void Count_one_word()
  {
    var counts = new Dictionary<string, int> {
            { "word", 1 }
        };

    Assert.That(Phrase.WordCount("word"), Is.EqualTo(counts));
  }

  [Test]
  public void Count_one_of_each()
  {
    var counts = new Dictionary<string, int> {
            { "one",  1 },
            { "of",   1 },
            { "each", 1 }
        };

    Assert.That(Phrase.WordCount("one of each"), Is.EqualTo(counts));
  }

  [Test]
  public void Count_multiple_occurrences()
  {
    var counts = new Dictionary<string, int> {
            { "one",  1 },
            { "fish", 4 },
            { "two",  1 },
            { "red",  1 },
            { "blue", 1 },
        };

    Assert.That(Phrase.WordCount("one fish two fish red fish blue fish"), Is.EqualTo(counts));
  }

  [Test]
  public void Count_everything_just_once()
  {
    var counts = new Dictionary<string, int> {
            { "all",    2 },
            { "the",    2 },
            { "kings",  2 },
            { "horses", 1 },
            { "and",    1 },
            { "men",    1 },
        };

    Assert.That(Phrase.WordCount("all the kings horses and all the kings men"), Is.EqualTo(counts));
  }

  [Test]
  public void Ignore_punctuation()
  {
    var counts = new Dictionary<string, int> {
            { "car",        1 },
            { "carpet",     1 },
            { "as",         1 },
            { "java",       1 },
            { "javascript", 1 },
        };

    Assert.That(Phrase.WordCount("car : carpet as java : javascript!!&@$%^&"), Is.EqualTo(counts));
  }

  [Test]
  public void Handles_cramped_list()
  {
    var counts = new Dictionary<string, int> {
            { "one",   1 },
            { "two",   1 },
            { "three", 1 },
        };

    Assert.That(Phrase.WordCount("one,two,three"), Is.EqualTo(counts));
  }

  [Test]
  public void Include_numbers()
  {
    var counts = new Dictionary<string, int> {
            { "testing", 2 },
            { "1",       1 },
            { "2",       1 },
        };

    Assert.That(Phrase.WordCount("testing, 1, 2 testing"), Is.EqualTo(counts));
  }

  [Test]
  public void Normalize_case()
  {
    var counts = new Dictionary<string, int> {
            { "go", 3 },
        };

    Assert.That(Phrase.WordCount("go Go GO"), Is.EqualTo(counts));
  }

  [Test]
  public void With_apostrophes()
  {
    var counts = new Dictionary<string, int> {
            { "first", 1 },
            { "don't", 2 },
            { "laugh", 1 },
            { "then",  1 },
            { "cry",   1 },
        };

    Assert.That(Phrase.WordCount("First: don't laugh. Then: don't cry."), Is.EqualTo(counts));
  }

  [Test]
  public void With_free_standing_apostrophes()
  {
    var counts = new Dictionary<string, int> {
            { "go", 3 },
        };

    Assert.That(Phrase.WordCount("go ' Go '' GO"), Is.EqualTo(counts));
  }

  [Test]
  public void With_apostrophes_as_quotes()
  {
    var counts = new Dictionary<string, int> {
            { "she", 1 },
            { "said", 1 },
            { "let's", 1 },
            { "meet", 1 },
            { "at", 1 },
            { "twelve", 1 },
            { "o'clock", 1 },
        };

    Assert.That(Phrase.WordCount("She said, 'let's meet at twelve o'clock'"), Is.EqualTo(counts));
  }
}