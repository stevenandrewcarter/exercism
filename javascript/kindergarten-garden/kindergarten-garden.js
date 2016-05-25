function getPlant(symbol) {
  switch (symbol) {
    case 'R':
      return 'radishes';
    case 'C':
      return 'clover';
    case 'G':
      return 'grass';
    case 'V':
      return 'violets';
  }
}

function determineCups(child, rows) {
  var cups = [];
  for (var r = 0; r < rows.length; r++) {
    for (var c = 0; c < 2; c++) {
      cups.push(getPlant(rows[r][(child * 2) + c]));
    }
  }
  return cups;
}

var Garden = function (garden, students) {
  var rows = garden.split('\n');
  if (students == null) {
    students = ['alice', 'bob', 'charlie', 'david', 'eve', 'fred', 'ginny', 'harriet', 'ileana', 'joseph', 'kincaid', 'larry'];
  }
  students.sort();
  for (var i = 0; i < students.length; i++) {
    this[students[i].toLowerCase()] = determineCups(i, rows);
  }
};

module.exports = Garden;