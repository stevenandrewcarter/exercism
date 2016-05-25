var BinarySearch = function (array) {
  var sorted = true;
  var e = array[0];
  for (var i = 1; i < array.length && sorted; i++) {
    if (e > array[i]) {
      sorted = false;
    }
    e = array[i];
  }
  this.array = sorted ? array : undefined;
};

BinarySearch.prototype.indexOf = function (value) {
  for (var min = -1, max = this.array.length; min < max;) {
    var mid = Math.floor(( min + max) / 2);
    if (this.array[mid] < value) {
      min = mid + 1;
    } else if (value < this.array[mid]) {
      max = mid - 1;
    } else {
      return mid;
    }
  }
  return -1;
};

module.exports = BinarySearch;