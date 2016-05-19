var Sieve = function (number) {
  var unmarked = [];
  for (var i = 0; i <= number; i++) {
    unmarked[i] = false;
  }
  for (var i = 2; i <= number; i++) {
    if (!unmarked[i]) {
      var nextPosition = i;
      while (nextPosition <= number) {
        nextPosition += i;
        if (nextPosition <= number) {
          unmarked[nextPosition] = true;
        }
      }
    }
  }
  this.primes = [];
  for (var i = 2; i < unmarked.length; i++) {
    if (!unmarked[i]) {
      this.primes.push(i);
    }
  }
};

module.exports = Sieve;