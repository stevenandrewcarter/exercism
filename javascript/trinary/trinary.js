var Trinary = function (trinary) {
  this.trinary = trinary;
};

Trinary.prototype.toDecimal = function () {
  var result = 0;
  for (var i = 0; i < this.trinary.length; i++) {
    if (this.trinary[i] == '0' || this.trinary[i] == '1' || this.trinary[i] == '2') {
      result += this.trinary[i] * Math.pow(3, this.trinary.length - (i + 1));
    } else {
      return 0;
    }
  }
  return result;
};

module.exports = Trinary;