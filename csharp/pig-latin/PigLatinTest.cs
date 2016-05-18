using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

class PigLatin
{
  public static string Translate(string aWords)
  {
    var words = aWords.Split(' ');
    var newWords = new List<string>();
    foreach (var word in words)
    {
      var newWord = "";
      var firstChar = word[0];
      if (firstChar == 'a' || firstChar == 'e' || firstChar == 'i' || firstChar == 'o' || firstChar == 'u' || (firstChar == 'y' && word[1] == 't') || (firstChar == 'x' && word[1] == 'r'))
      {
        newWord = word + "ay";
      }
      else
      {
        if ((firstChar == 'c' && word[1] == 'h') || (firstChar == 'q' && word[1] == 'u') || (firstChar == 't' && word[1] == 'h' && word[2] != 'r'))
        {
          var firstPart = word.Substring(0, 2);
          newWord = word.Remove(0, 2);
          newWord += firstPart;
        }
        else if ((firstChar == 's' && word[1] == 'c' && word[2] == 'h') || (firstChar == 't' && word[1] == 'h' && word[2] == 'r') || (word[1] == 'q' && word[2] == 'u'))
        {
          var firstPart = word.Substring(0, 3);
          newWord = word.Remove(0, 3);
          newWord += firstPart;
        }
        else
        {
          newWord = word.Remove(0, 1);
          newWord += firstChar;
        }
        newWord += "ay";
      }
      newWords.Add(newWord);
    }
    return string.Join(" ", newWords.ToArray());
  }
}

[TestFixture]
public class PigLatinTest
{
  [TestCase("apple", ExpectedResult = "appleay")]
  [TestCase("ear", ExpectedResult = "earay")]
  [TestCase("igloo", ExpectedResult = "iglooay")]
  [TestCase("object", ExpectedResult = "objectay")]
  [TestCase("under", ExpectedResult = "underay")]
  public string Ay_is_added_to_words_that_start_with_vowels(string word)
  {
    return PigLatin.Translate(word);
  }
  
  [TestCase("pig", ExpectedResult = "igpay")]
  [TestCase("koala", ExpectedResult = "oalakay")]
  [TestCase("yellow", ExpectedResult = "ellowyay")]
  [TestCase("xenon", ExpectedResult = "enonxay")]
  public string First_letter_and_ay_are_moved_to_the_end_of_words_that_start_with_consonants(string word)
  {
    return PigLatin.Translate(word);
  }
  
  [Test]
  public void Ch_is_treated_like_a_single_consonant()
  {
    Assert.That(PigLatin.Translate("chair"), Is.EqualTo("airchay"));
  }
  
  [Test]
  public void Qu_is_treated_like_a_single_consonant()
  {
    Assert.That(PigLatin.Translate("queen"), Is.EqualTo("eenquay"));
  }
  
  [Test]
  public void Qu_and_a_single_preceding_consonant_are_treated_like_a_single_consonant()
  {
    Assert.That(PigLatin.Translate("square"), Is.EqualTo("aresquay"));
  }
  
  [Test]
  public void Th_is_treated_like_a_single_consonant()
  {
    Assert.That(PigLatin.Translate("therapy"), Is.EqualTo("erapythay"));
  }
  
  [Test]
  public void Thr_is_treated_like_a_single_consonant()
  {
    Assert.That(PigLatin.Translate("thrush"), Is.EqualTo("ushthray"));
  }
  
  [Test]
  public void Sch_is_treated_like_a_single_consonant()
  {
    Assert.That(PigLatin.Translate("school"), Is.EqualTo("oolschay"));
  }
  
  [Test]
  public void Yt_is_treated_like_a_single_vowel()
  {
    Assert.That(PigLatin.Translate("yttria"), Is.EqualTo("yttriaay"));
  }
  
  [Test]
  public void Xr_is_treated_like_a_single_vowel()
  {
    Assert.That(PigLatin.Translate("xray"), Is.EqualTo("xrayay"));
  }

  [Test]
  public void Phrases_are_translated()
  {
    Assert.That(PigLatin.Translate("quick fast run"), Is.EqualTo("ickquay astfay unray"));
  }
}