var Anagram = function (word) {
  this.word = word.toLowerCase();

  this.matches = function () {
    var words = arguments;
    if (Object.prototype.toString.call(words[0]) === '[object Array]') {
      words = words[0];
    }
    var foundMatches = [];
    for (var wordIndex = 0; wordIndex < words.length; wordIndex++) {
      var isAnagram = words[wordIndex].length == this.word.length;
      if (words[wordIndex].toLowerCase() == this.word) {
        isAnagram = false;
      }
      var adjustedWord = this.word;
      for (var i = 0; i < words[wordIndex].length && isAnagram; i++) {
        var foundPosition = adjustedWord.indexOf(words[wordIndex][i].toLowerCase());
        if (foundPosition === -1) {
          isAnagram = false;
        }
        adjustedWord = adjustedWord.substr(0, foundPosition) + adjustedWord.substr(foundPosition + 1, adjustedWord.length - foundPosition);
      }
      if (isAnagram) {
        foundMatches.push(words[wordIndex]);
      }
    }
    return foundMatches;
  }
};

module.exports = Anagram;