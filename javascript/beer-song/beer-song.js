var BeerSong = function () {
};

BeerSong.prototype.verse = function (verseNumber) {
  if (verseNumber == 2)
    return verseNumber.toString() + ' bottles of beer on the wall, ' + verseNumber.toString() + ' bottles of beer.\nTake one down and pass it around, ' + (verseNumber - 1).toString() + ' bottle of beer on the wall.\n';
  else if (verseNumber == 1)
    return verseNumber.toString() + ' bottle of beer on the wall, ' + verseNumber.toString() + ' bottle of beer.\nTake it down and pass it around, no more bottles of beer on the wall.\n';
  else if (verseNumber == 0)
    return 'No more bottles of beer on the wall, no more bottles of beer.\nGo to the store and buy some more, 99 bottles of beer on the wall.\n';
  return verseNumber.toString() + ' bottles of beer on the wall, ' + verseNumber.toString() + ' bottles of beer.\nTake one down and pass it around, ' + (verseNumber - 1).toString() + ' bottles of beer on the wall.\n';
};

BeerSong.prototype.sing = function (startVerse, endVerse) {
  if (!endVerse) {
    endVerse = 0;
  }
  var song = [];
  var pos = 0;
  for (var i = startVerse; i >= endVerse; i--) {
    song[pos] = this.verse(i);
    pos++;
  }
  return song.join('\n');
};

module.exports = BeerSong;