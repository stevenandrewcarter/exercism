function startsWithVowel(word) {
  var firstLetter = word.toLowerCase()[0];
  return firstLetter == 'a' || firstLetter == 'e' || firstLetter == 'o' || firstLetter == 'i' || firstLetter == 'u';
}

function moveLetters(word) {
  var index = 1;
  if (word.startsWith('thr') || word.startsWith('sch')) {
    index = 3;
  } else if (word.startsWith('ch') || word.startsWith('th')) {
    index  = 2;
  } else if (word.indexOf('qu') >= 0) {
    index = word.indexOf('qu') + 2;
  }
  return word.substr(index, word.length - 1) + word.substr(0, index);
}

module.exports = {
  translate: function (sentence) {
    var words = sentence.split(' ');
    var translatedWords = [];
    for (var i = 0; i < words.length; i++) {
      var translatedWord = words[i];
      if (!startsWithVowel(words[i])) {
        translatedWord = moveLetters(words[i]);
      }
      translatedWords.push(translatedWord  + 'ay');
    }
    return translatedWords.join(' ');
  }
};
