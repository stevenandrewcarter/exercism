class Hamming
{
  public static int Compute(string source, string comparer)
  {
    var distance = 0;
    if (source.Length != comparer.Length)
    {
      return distance;
    }
    for (var i = 0; i < source.Length; ++i)
    {
      if (comparer[i] != source[i])
      {
        distance++;
      }
    }
    return distance;
  }
}