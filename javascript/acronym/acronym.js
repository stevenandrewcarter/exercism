function isLetter(n) {
  var a = n.toLowerCase();
  return a != ' ' && a >= 'a' && a <= 'z';
}

module.exports = {
  parse: function (phrase) {
    var acronym = "";
    var words = phrase.split(/[\s-]+/);
    for (var i = 0; i < words.length; i++) {
      acronym += words[i][0].toUpperCase();
      for (var j = 1; j < words[i].length; j++) {
        if (isLetter(words[i][j]) && words[i][j] == words[i][j].toUpperCase()) {
          acronym += words[i][j].toUpperCase();
        }
        if (words[i][j] == ":") {
          return acronym;
        }
      }
    }
    return acronym;
  }
};
