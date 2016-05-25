var Queens = function (queens) {
  if (queens) {
    this.white = queens.white;
    this.black = queens.black;
  } else {
    this.white = [0, 3];
    this.black = [7, 3];
  }
  if (this.white[0] == this.black[0] && this.white[1] == this.black[1]) {
    throw 'Queens cannot share the same space';
  }
};

Queens.prototype.toString = function () {
  var result = "";
  for (var i = 0; i < 8; i++) {
    var row = [];
    for (var j = 0; j < 8; j++) {
      if (this.white[0] == i && this.white[1] == j) {
        row.push('W');
      } else if (this.black[0] == i && this.black[1] == j) {
        row.push('B');
      } else {
        row.push('_');
      }
    }
    result += row.join(' ');
    result += '\n';
  }
  return result;
};

Queens.prototype.canAttack = function () {
  if (this.white[0] == this.black[0]) {
    return true;
  } else if (this.white[1] == this.black[1]) {
    return true;
  } else if (Math.abs(this.white[0] - this.black[0]) == Math.abs(this.white[1] - this.black[1])) {
    return true;
  }
  return false;
};

module.exports = Queens;