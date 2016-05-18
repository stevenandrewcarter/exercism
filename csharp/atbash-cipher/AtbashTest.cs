using NUnit.Framework;
using System.Text;

class Atbash
{
  public static string Encode(string words)
  {
    var decoded = "abcdefghijklmnopqrstuvwxyz";
    var encoded = "zyxwvutsrqponmlkjihgfedcba";
    var breakPoint = 5;
    var currentPoint = 0;
    var result = new StringBuilder();
    for (var i = 0; i < words.Length; i++)
    {
      var c = words.ToLower()[i];
      if (char.IsLetterOrDigit(c))
      {
        var position = decoded.IndexOf(c);
        if (position >= 0)
        {
          result.Append(encoded[position]);
        }
        else
        {
          result.Append(c);
        }
        currentPoint++;
      }
      if (currentPoint / breakPoint == 1)
      {
        result.Append(" ");
        currentPoint = 0;
      }
    }
    return result.ToString().Trim();
  }
}

[TestFixture]
public class AtbashTest
{
  // change Ignore to false to run test case or just remove 'Ignore = true'
  [TestCase("no", ExpectedResult = "ml")]
  [TestCase("yes", ExpectedResult = "bvh")]
  [TestCase("OMG", ExpectedResult = "lnt")]
  [TestCase("mindblowingly", ExpectedResult = "nrmwy oldrm tob")]
  [TestCase("Testing, 1 2 3, testing.", ExpectedResult = "gvhgr mt123 gvhgr mt")]
  [TestCase("Truth is fiction.", ExpectedResult = "gifgs rhurx grlm")]
  [TestCase("The quick brown fox jumps over the lazy dog.", ExpectedResult = "gsvjf rxpyi ldmul cqfnk hlevi gsvoz abwlt")]
  public string Encodes_words_using_atbash_cipher(string words)
  {
    return Atbash.Encode(words);
  }
}