var Series = function(digits) {
  this.digits = digits;
};

Series.prototype.largestProduct = function(seriesLength) {
  if (seriesLength > this.digits.length) throw new Error('Invalid input.');
  if (seriesLength == 0 || this.digits.length == 0) return 1;
  var productSets = [];
  for (var c = 0; c < this.digits.length; c++) {
    if (this.digits[c] < '0' || this.digits[c] > '9') {
      throw new Error('Invalid input.');
    }
    var set = this.digits[c];
    for (var i = 1; i < seriesLength; i++) {
      if (c + i < this.digits.length)
        set += this.digits[c + i];
    }
    if (set.length == seriesLength) {
      productSets.push(set);
    }
  }
  var results = [];
  for (var i = 0; i < productSets.length; i++) {
    var result = 1;
    for (var c = 0; c < productSets[i].length; c++) {
      result *= +productSets[i][c];
    }
    results.push(result);
  }
  results.sort(function(a, b){return b-a});
  return results[0];
};

module.exports = Series;