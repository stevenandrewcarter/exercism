var CryptoSquare = function (message) {
  this.originalMessage = message;
  this.normalizedMessage = message.toLowerCase().split('').filter(function (c) {
    return c != ' ' && ((c >= '0' && c <= '9') || (c >= 'a' && c <= 'z'));
  });

  this.normalizePlaintext = function () {
    return this.normalizedMessage.join('');
  };

  this.size = function () {
    var square = Math.sqrt(this.normalizePlaintext().length);
    return Math.floor(square % 1 == 0 ? square : square + 1);
  };

  this.plaintextSegments = function () {
    var segments = [];
    var segment = "";
    var count = 0;
    for (var i = 0; i < this.normalizePlaintext().length; i++) {
      segment += this.normalizePlaintext()[i];
      count += 1;
      if (count == this.size()) {
        segments.push(segment);
        segment = "";
        count = 0;
      }
    }
    if (count > 0) {
      segments.push(segment);
    }
    return segments;
  };

  this.ciphertext = function () {
    var cipher = "";
    var segments = this.plaintextSegments();
    for (var i = 0; i < this.size(); i++) {
      for (var j = 0; j < segments.length; j++) {
        if (i < segments[j].length) {
          cipher += segments[j][i];
        }
      }
    }
    return cipher;
  }
};

module.exports = CryptoSquare;