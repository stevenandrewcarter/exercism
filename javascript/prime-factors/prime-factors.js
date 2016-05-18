module.exports = {
  for: function (limit) {
    var factors = [];
    for (var div = 2; div <= limit; div++)
    {
      while (limit % div == 0)
      {
        factors.push(div);
        limit = limit / div;
      }
    }
    return factors;
  }
};
