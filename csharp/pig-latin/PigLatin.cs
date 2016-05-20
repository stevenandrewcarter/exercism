using System.Collections.Generic;

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