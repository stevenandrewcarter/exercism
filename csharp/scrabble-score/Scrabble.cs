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