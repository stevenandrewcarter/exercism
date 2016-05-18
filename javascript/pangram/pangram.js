function Pangram(sentence) {
  this.sentence = sentence;

  this.isPangram = function () {
    var lowerCaseSentence = this.sentence.toLowerCase();
    var isPangram = true;
    var alphabet = "abcdefghijklmnopqrstuvwxyz";
    for (var i = 0; i < alphabet.length && isPangram; i++) {
      if (lowerCaseSentence.indexOf(alphabet[i]) === -1) {
        isPangram = false;
      }
    }
    return isPangram;
  }
}

module.exports = Pangram;
