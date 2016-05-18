var Raindrops = function () {
  this.convert = function (number) {
    var result = "";
    if (number % 3 == 0) {
      result += 'Pling';
    }
    if (number % 5 == 0) {
      result += 'Plang';
    }
    if (number % 7 == 0) {
      result += 'Plong';
    }
    if (result == "") {
      result = number.toString();
    }
    return result;
  };
};

module.exports = Raindrops;