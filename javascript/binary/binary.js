var Binary = function (binary) {
  this.binary = binary;
};

Binary.prototype.toDecimal = function () {
  var result = 0;
  for (var i = 0; i < this.binary.length; i++) {
    if (this.binary[i] == '0' || this.binary[i] == '1') {
      result += this.binary[i] * Math.pow(2, this.binary.length - (i + 1));
    } else {
      return 0;
    }
  }
  return result;
};

module.exports = Binary;