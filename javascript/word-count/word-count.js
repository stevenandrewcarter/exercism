function Words() {
  this.count = function (words) {
    var wordCount = {};
    words = words.trim();
    words.split(/[ \n\t]+/).forEach(function (word) {
      word = word.toLowerCase();
      wordCount[word] = (+wordCount[word] || 0) + 1;
    });
    return wordCount;
  }
}

module.exports = Words;
