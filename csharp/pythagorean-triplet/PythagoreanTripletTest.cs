using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using System;

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

  public static Triplet[] Where(int maxFactor = 1000, int minFactor = 1, int sum = 0)
  {
    var n = minFactor;
    var lastFactor = 0;
    var triplets = new List<Triplet>();
    while (lastFactor <= maxFactor)
    {
      var m = n + 1;
      var triplet = new Triplet((int)(Math.Pow(m, 2) - Math.Pow(n, 2)), 2 * m * n, (int)(Math.Pow(m, 2) + Math.Pow(n, 2)));
      if (triplet.IsPythagorean() && (sum == 0 || sum < triplet.Sum()))
        triplets.Add(triplet);
      lastFactor = triplet.ElementAt(2);
      n++;
    }
    return triplets.ToArray();
  }
}

[TestFixture]
public class PythagoreanTripletTest
{
  [Test]
  public void Calculates_the_sum()
  {
    Assert.That(new Triplet(3, 4, 5).Sum(), Is.EqualTo(12));
  }

  [Test]
  public void Calculates_the_product()
  {
    Assert.That(new Triplet(3, 4, 5).Product(), Is.EqualTo(60));
  }

  [TestCase(3, 4, 5, ExpectedResult = true)]
  [TestCase(5, 6, 7, ExpectedResult = false)]
  public bool Can_recognize_a_valid_pythagorean(int a, int b, int c)
  {
    return new Triplet(a, b, c).IsPythagorean();
  }

  [Ignore("Remove to run test")]
  [Test]
  public void Can_make_triplets_up_to_10()
  {
    var triplets = Triplet.Where(maxFactor: 10);
    var products = triplets.Select(x => x.Product()).OrderBy(x => x);
    Assert.That(products, Is.EqualTo(new[] { 60, 480 }));
  }

  [Ignore("Remove to run test")]
  [Test]
  public void Can_make_triplets_from_11_to_20()
  {
    var triplets = Triplet.Where(minFactor: 11, maxFactor: 20);
    var products = triplets.Select(x => x.Product());
    Assert.That(products, Is.EqualTo(new[] { 3840 }));
  }

  [Ignore("Remove to run test")]
  [Test]
  public void Can_make_triplets_filtered_on_sum()
  {
    var triplets = Triplet.Where(sum: 180, maxFactor: 100);
    var products = triplets.Select(x => x.Product()).OrderBy(x => x);
    Assert.That(products, Is.EqualTo(new[] { 118080, 168480, 202500 }));
  }
}