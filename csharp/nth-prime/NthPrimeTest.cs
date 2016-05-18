using NUnit.Framework;

class NthPrime
{
  public static int Nth(int prime)
  {
    if (prime == 1)
      return 2;
    var pos = 3;
    var currentPrime = 1;
    while (currentPrime != prime)
    {
      var isPrime = true;
      for (var div = 2; div < pos && isPrime; div++)
      {
        if (pos % div == 0)        
          isPrime = false;                  
      }
      if (isPrime)
        currentPrime++;
      if (currentPrime != prime)
        pos++;        
    }
    return pos;
  }
}

public class NthPrimeTest
{
  [TestCase(1, ExpectedResult = 2)]
  [TestCase(2, ExpectedResult = 3)]
  [TestCase(3, ExpectedResult = 5)]
  [TestCase(4, ExpectedResult = 7)]
  [TestCase(5, ExpectedResult = 11)]
  [TestCase(6, ExpectedResult = 13)]
  [TestCase(7, ExpectedResult = 17)]
  [TestCase(8, ExpectedResult = 19)]
  [TestCase(1000, ExpectedResult = 7919)]
  [TestCase(10000, ExpectedResult = 104729)]
  [TestCase(10001, ExpectedResult = 104743)]
  public int Nth_prime_calculated(int nth)
  {
    return NthPrime.Nth(nth);
  }
}