class Raindrops
{
  public static string Convert(int number)
  {
    var result = "";
    if (number % 3 == 0)
    {
      result += "Pling";
    }
    if (number % 5 == 0)
    {
      result += "Plang";
    }
    if (number % 7 == 0)
    {
      result += "Plong";
    }
    if (result == string.Empty)
    {
      result = number.ToString();
    }
    return result;
  }
}