using System.Collections.Generic;
using System.Linq;

class Sieve
{
  public static int[] Primes(int limit)
  {
    var unmarked = new Dictionary<int, bool>();
    for (var i = 0; i < limit; i++)
    {
      unmarked.Add(i + 1, false);
    }
    for (var i = 2; i < limit; i++)
    {
      if (!unmarked[i])
      {
        var nextPosition = i;
        while (nextPosition <= limit)
        {
          nextPosition += i;
          if (nextPosition <= limit)
          {
            unmarked[nextPosition] = true;
          }
        }
      }
    }
    return unmarked.Where(i => i.Key != 1 && !i.Value).ToDictionary(p => p.Key, p => p.Value).Keys.ToArray();
  }
}