var BigInt = require('./big-integer');

function Grains() {
  this.square = function (squareNumber) {
    var bigInt = BigInt(2);
    bigInt = bigInt.pow(squareNumber - 1);
    return bigInt.toString();
  }

  this.total = function() {
    var bigInt = BigInt(2);
    var sum = BigInt(0);
    for (var i = 0; i < 64; i++) {
      sum = sum.add(bigInt.pow(i));
    }
    return sum.toString();
  }
}

module.exports = Grains;