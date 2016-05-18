namespace Exercism
{
  using NUnit.Framework;

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

  [TestFixture]
  public class AcronymTest
  {
    [Test]
    public void Empty_string_abbreviated_to_empty_string()
    {
      Assert.That(Acronym.Abbreviate(string.Empty), Is.EqualTo(string.Empty));
    }

    [TestCase("Portable Network Graphics", ExpectedResult = "PNG")]
    [TestCase("Ruby on Rails", ExpectedResult = "ROR")]
    [TestCase("HyperText Markup Language", ExpectedResult = "HTML")]
    [TestCase("First In, First Out", ExpectedResult = "FIFO")]
    [TestCase("PHP: Hypertext Preprocessor", ExpectedResult = "PHP")]
    [TestCase("Complementary metal-oxide semiconductor", ExpectedResult = "CMOS")]
    public string Phrase_abbreviated_to_acronym(string phrase)
    {
      return Acronym.Abbreviate(phrase);
    }
  }
}