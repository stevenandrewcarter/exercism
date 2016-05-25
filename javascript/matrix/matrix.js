var Matrix = function (matrixString) {
  this.rows = [];
  this.columns = [];

  var split = matrixString.split('\n');
  for (var i = 0; i < split.length; i++) {
    var row = [];
    var column = split[i].split(' ');
    for (var j = 0; j < column.length; j++) {
      row.push(+column[j]);
      if (!this.columns[j]) {
        this.columns.push([]);
      }
      this.columns[j].push(+column[j]);
    }
    this.rows.push(row);
  }
};

module.exports = Matrix;