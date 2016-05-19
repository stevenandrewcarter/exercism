var Triplet = function (a, b, c) {
  this.a = a;
  this.b = b;
  this.c = c;
};

Triplet.prototype.sum = function () {
  return this.a + this.b + this.c;
};

Triplet.prototype.product = function () {
  return this.a * this.b * this.c;
};

Triplet.prototype.isPythagorean = function () {
  return Math.pow(this.a, 2) + Math.pow(this.b, 2) == Math.pow(this.c, 2);
};

Triplet.where = function (parameters) {
  var min = parameters.minFactor != null ? parameters.minFactor : 1;
  var max = parameters.maxFactor;
  var triplets = [];
  for (var a = min; a <= max; a++) {
    for (var b = a; b <= max; b++) {
      for (var c = b; c <= max; c++) {
        var triplet = new Triplet(a, b, c);
        if (triplet.isPythagorean() && (parameters.sum == null || (parameters.sum == triplet.sum()))) {
          triplets.push(triplet);
        }
      }
    }
  }
  return triplets;
}
;

module.exports = Triplet;