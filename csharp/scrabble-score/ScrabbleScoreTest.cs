using NUnit.Framework;

class Scrabble
{
  public static int Score(string word)
  {
    if (word == null)
      return 0;
    var fixedWord = word.Trim().ToLower();
    if (fixedWord.Length == 0)
      return 0;
    var score = 0;
    foreach (var c in fixedWord)
    {
      if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u' || c == 'l' || c == 'n' || c == 'r' || c == 's' || c == 't')
        score += 1;
      else if (c == 'd' || c == 'g')
        score += 2;
      else if (c == 'b' || c == 'c' || c == 'm' || c == 'p')
        score += 3;
      else if (c == 'f' || c == 'h' || c == 'v' || c == 'w' || c == 'y')
        score += 4;
      else if (c == 'k')
        score += 5;
      else if (c == 'j' || c == 'x')
        score += 8;
      else if (c == 'q' || c == 'z')
        score += 10;
    }
    return score;
  }
}

[TestFixture]
public class ScrabbleScoreTest
{
  [Test]
  public void Empty_word_scores_zero()
  {
    Assert.That(Scrabble.Score(""), Is.EqualTo(0));
  }
  
  [Test]
  public void Whitespace_scores_zero()
  {
    Assert.That(Scrabble.Score(" \t\n"), Is.EqualTo(0));
  }
  
  [Test]
  public void Null_scores_zero()
  {
    Assert.That(Scrabble.Score(null), Is.EqualTo(0));
  }
  
  [Test]
  public void Scores_very_short_word()
  {
    Assert.That(Scrabble.Score("a"), Is.EqualTo(1));
  }
  
  [Test]
  public void Scores_other_very_short_word()
  {
    Assert.That(Scrabble.Score("f"), Is.EqualTo(4));
  }
  
  [Test]
  public void Simple_word_scores_the_number_of_letters()
  {
    Assert.That(Scrabble.Score("street"), Is.EqualTo(6));
  }
  
  [Test]
  public void Complicated_word_scores_more()
  {
    Assert.That(Scrabble.Score("quirky"), Is.EqualTo(22));
  }
  
  [Test]
  public void Scores_are_case_insensitive()
  {
    Assert.That(Scrabble.Score("OXYPHENBUTAZONE"), Is.EqualTo(41));
  }
}