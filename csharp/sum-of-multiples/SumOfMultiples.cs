class SumOfMultiples
{
  public static int To(int[] multiples, int limit)
  {
    var sum = 0;
    for (var i = 2; i < limit; i++)
    {
      bool added = false;
      foreach (var m in multiples)
      {
        if (!added && i % m == 0)
        {
          sum += i;
          added = true;
        }
      }
    }
    return sum;
  }
}