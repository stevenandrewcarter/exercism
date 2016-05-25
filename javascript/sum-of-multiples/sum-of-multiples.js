function to(num) {
  return Array.apply(null, Array(num)).reduce(function (total, _, n) {
    if (this.some(function (mul) {
        return n % mul == 0
      }))
      return total + n;
    return total;
  }.bind(this.factors), 0)
}

module.exports = function (factors) {
  return {
    factors: factors || [3, 5],
    to: to
  };
};