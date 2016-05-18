module.exports = function (array, operation) {
  var result = [];
  for (var i = 0; i < array.length; i++) {
    result[i] = operation(array[i]);
  }
  return result;
};
