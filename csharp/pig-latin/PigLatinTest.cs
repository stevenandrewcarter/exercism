using NUnit.Framework;

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