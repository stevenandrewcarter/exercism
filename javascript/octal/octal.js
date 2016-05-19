var Octal = function (octal) {
  this.octal = octal;
};

Octal.prototype.toDecimal = function () {
  var result = 0;
  for (var i = 0; i < this.octal.length; i++) {
    if (this.octal[i] >= '0' && this.octal[i] <= '7') {
      result += this.octal[i] * Math.pow(8, this.octal.length - (i + 1));
    } else {
      return 0;
    }
  }
  return result;
};

module.exports = Octal;