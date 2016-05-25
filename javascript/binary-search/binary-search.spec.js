var BinarySearch = require('./binary-search');

describe('BinarySearch', function () {

  var sortedArray = [1, 2, 3, 4, 5, 6];
  var sortedArrayOfOddLength = [0, 1, 2, 2, 3, 10, 12];
  var unsortedArray = [10, 2, 5, 1];

  it('should require a sorted array', function () {
    var invalidBinarySearch = new BinarySearch(unsortedArray);
    var validBinarySearch = new BinarySearch(sortedArray);

    expect(typeof invalidBinarySearch.array).toEqual('undefined');
    expect(Array.isArray(validBinarySearch.array)).toEqual(true);
  });

  it('should find the correct index of an included value', function () {
    expect(new BinarySearch(sortedArray).indexOf(3)).toEqual(2);
  });

  it('should search the middle of the array', function () {
    expect(new BinarySearch(sortedArrayOfOddLength).indexOf(2)).toEqual(3);
  });

  it('should return -1 for a value not in the array', function () {
    expect(new BinarySearch(sortedArray).indexOf(10)).toEqual(-1);
  });
});

