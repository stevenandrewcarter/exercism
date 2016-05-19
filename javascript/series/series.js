var Series = function (series) {
  var seriesArray = series.split('');
  this.digits = [];
  for (var i = 0; i < seriesArray.length; i++) {
    this.digits.push(+seriesArray[i]);
  }
};

Series.prototype.slices = function (sliceSize) {
  if (sliceSize > this.digits.length) {
    throw new Error('Slice size is too big.');
  }
  var slices = [];
  var i = 0;
  while (i < this.digits.length) {
    if (sliceSize + i <= this.digits.length) {
      var slice = [];
      for (var j = i; j < sliceSize + i; j++) {
        slice.push(this.digits[j]);
      }
      slices.push(slice);
    }
    i++;
  }
  return slices;
};

module.exports = Series;