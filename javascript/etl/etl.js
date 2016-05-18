function ETL() {
  this.transform = function (legacy) {
    var newTable = {};
    for (var i in legacy) {
      if (legacy.hasOwnProperty(i)) {
        for (var j = 0; j < legacy[i].length; j++) {
          newTable[legacy[i][j].toLowerCase()] = parseInt(i);
        }
      }
    }
    return newTable;
  }
}

module.exports = ETL;