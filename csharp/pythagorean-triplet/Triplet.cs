using System;
using System.Collections.Generic;
using System.Linq;

class Triplet : List<int>
{
  public Triplet(int a, int b, int c)
  {
    Add(a);
    Add(b);
    Add(c);
  }

  public int Product()
  {
    return this.ElementAt(0) * this.ElementAt(1) * this.ElementAt(2);
  }

  public bool IsPythagorean()
  {
    return Math.Pow(this.ElementAt(0), 2) + Math.Pow(this.ElementAt(1), 2) == Math.Pow(this.ElementAt(2), 2);
  }

  public static Triplet[] Where(int maxFactor, int minFactor = 1, int sum = 0)
  {
    var triplets = new List<Triplet>();
    for (var a = minFactor; a <= maxFactor; a++)
    {
      for (var b = a; b <= maxFactor; b++)
      {
        for (var c = b; c <= maxFactor; c++)
        {
          var triplet = new Triplet(a, b, c);
          if (triplet.IsPythagorean())
          {
            if (sum == 0 || (sum == triplet.Sum()))
            {
              triplets.Add(triplet);
            }
          }
        }
      }
    }
    return triplets.ToArray();
  }
}