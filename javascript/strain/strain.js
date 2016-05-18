module.exports = {
  keep: function (array, filter) {
    var result = [];
    for (var i = 0; i < array.length; i++) {
      if (filter(array[i])) {
        result.push(array[i]);
      }
    }
    return result;
  },
  discard: function (array, filter) {
    var result = [];
    for (var i = 0; i < array.length; i++) {
      if (!filter(array[i])) {
        result.push(array[i]);
      }
    }
    return result;
  }
};
