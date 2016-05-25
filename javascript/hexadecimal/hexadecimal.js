var Hexadecimal = function (hexadecimal) {
  this.hexadecimal = hexadecimal.toLowerCase();
};

Hexadecimal.prototype.toDecimal = function () {
  var result = 0;
  for (var i = 0; i < this.hexadecimal.length; i++) {
    if ((this.hexadecimal[i] >= '0' && this.hexadecimal[i] <= '9') || (this.hexadecimal[i] >= 'a' && this.hexadecimal[i] <= 'f')) {
      var hexValue = (this.hexadecimal[i] >= 'a' && this.hexadecimal[i] <= 'f') ? this.hexadecimal.charCodeAt(i) - 87 : +this.hexadecimal[i];
      result += hexValue * Math.pow(16, this.hexadecimal.length - (i + 1));
    } else {
      return 0;
    }
  }
  return result;
};

module.exports = Hexadecimal;