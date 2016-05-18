using NUnit.Framework;

class Beer
{
  public static string Verse(int number)
  {
    if (number == 0)
      return "No more bottles of beer on the wall, no more bottles of beer.\nGo to the store and buy some more, 99 bottles of beer on the wall.\n";
    if (number == 2)
      return "2 bottles of beer on the wall, 2 bottles of beer.\nTake one down and pass it around, 1 bottle of beer on the wall.\n";
    if (number == 1)
      return "1 bottle of beer on the wall, 1 bottle of beer.\nTake it down and pass it around, no more bottles of beer on the wall.\n";
    return string.Format("{0} bottles of beer on the wall, {0} bottles of beer.\nTake one down and pass it around, {1} bottles of beer on the wall.\n", number, number - 1);
  }

  public static string Sing(int startVerse, int stopVerse)
  {
    var song = "";
    for (var i = startVerse; i >= stopVerse; i--)
      song += Verse(i) + "\n";
    return song;
  }
}

public class BeerTests
{
  [TestCase(8, ExpectedResult = "8 bottles of beer on the wall, 8 bottles of beer.\nTake one down and pass it around, 7 bottles of beer on the wall.\n")]
  [TestCase(2, ExpectedResult = "2 bottles of beer on the wall, 2 bottles of beer.\nTake one down and pass it around, 1 bottle of beer on the wall.\n")]
  [TestCase(1, ExpectedResult = "1 bottle of beer on the wall, 1 bottle of beer.\nTake it down and pass it around, no more bottles of beer on the wall.\n")]
  [TestCase(0, ExpectedResult = "No more bottles of beer on the wall, no more bottles of beer.\nGo to the store and buy some more, 99 bottles of beer on the wall.\n")]
  public string Verse(int number)
  {
    return Beer.Verse(number);
  }

  [TestCase(8, 6, ExpectedResult = "8 bottles of beer on the wall, 8 bottles of beer.\nTake one down and pass it around, 7 bottles of beer on the wall.\n\n7 bottles of beer on the wall, 7 bottles of beer.\nTake one down and pass it around, 6 bottles of beer on the wall.\n\n6 bottles of beer on the wall, 6 bottles of beer.\nTake one down and pass it around, 5 bottles of beer on the wall.\n\n")]
  [TestCase(3, 0, ExpectedResult = "3 bottles of beer on the wall, 3 bottles of beer.\nTake one down and pass it around, 2 bottles of beer on the wall.\n\n2 bottles of beer on the wall, 2 bottles of beer.\nTake one down and pass it around, 1 bottle of beer on the wall.\n\n1 bottle of beer on the wall, 1 bottle of beer.\nTake it down and pass it around, no more bottles of beer on the wall.\n\nNo more bottles of beer on the wall, no more bottles of beer.\nGo to the store and buy some more, 99 bottles of beer on the wall.\n\n")]
  public string Sing(int start, int stop)
  {
    return Beer.Sing(start, stop);
  }
}