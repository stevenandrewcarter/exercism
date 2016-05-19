var Squares = function (number) {
  this.squareOfSums = 0;
  this.sumOfSquares = 0;
  for (var i = 1; i <= number; i++) {
    this.squareOfSums += i;
    this.sumOfSquares += Math.pow(i, 2);
  }
  this.squareOfSums = Math.pow(this.squareOfSums, 2);
  this.difference = this.squareOfSums - this.sumOfSquares;
};

module.exports = Squares;