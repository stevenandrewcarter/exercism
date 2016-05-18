function isLetter(n) {
  var char = n.toLowerCase();
  return char != ' ' && char >= 'a' && char <= 'z';
}

function Isogram(word) {
  this.word = word;

  this.isIsogram = function () {
    var isIsogram = true;
    for (var i = 0; i < this.word.length && isIsogram; i++) {
      if (isLetter(this.word[i])) {
        for (var j = i + 1; j < this.word.length && isIsogram; j++) {
          if (isLetter(this.word[j]) && this.word[i].toLowerCase() == this.word[j].toLowerCase()) {
            isIsogram = false;
          }
        }
      }
    }
    return isIsogram;
  }
}

module.exports = Isogram;
