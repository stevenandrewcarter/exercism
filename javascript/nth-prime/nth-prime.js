module.exports = {
  nth: function (n) {
    if(n <= 0)
      throw new Error("Prime is not possible");
    if (n == 1)
      return 2;
    var pos = 3;
    var currentPrime = 1;
    while (currentPrime != n)
    {
      var isPrime = true;
      for (var div = 2; div < pos && isPrime; div++)
      {
        if (pos % div == 0)
          isPrime = false;
      }
      if (isPrime)
        currentPrime++;
      if (currentPrime != n)
        pos++;
    }
    return pos;
  }
};
