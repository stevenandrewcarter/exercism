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