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