var Triangle = function (rows) {
  this.rows = [];

  for (var i = 0; i < rows; i++)
  {
    var c = 1;
    var row = [];
    for (var x = 0; x <= i; x++)
    {
      row.push(c);
      c = c * (i - x) / (x + 1);
    }
    this.rows.push(row);
  }
  this.lastRow = this.rows[this.rows.length - 1];
};

module.exports = Triangle;