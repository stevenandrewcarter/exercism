var Cipher = function (key) {
  this.key = "";
  if (key != null) {
    if (key == '') {
      throw new Error('Bad key');
    }
    for (var i = 0; i < key.length; i++) {
      if (key[i] == key[i].toUpperCase() || (key[i] >= '0' && key[i] <= '9')) {
        throw new Error('Bad key');
      }
    }
    this.key = key;
  } else {
    for (var i = 0; i < 100; i++) {
      this.key += String.fromCharCode(97 + Math.floor((Math.random() * 25) + 1));
    }
  }

  this.encode = function (message) {
    var encoded = "";
    for (var i = 0; i < message.length; i++) {
      var charIndex = (message[i].charCodeAt(0) - 97) + (this.key[i].charCodeAt(0) - 97);
      while (charIndex >= 26) {
        charIndex -= 26;
      }
      encoded += String.fromCharCode(97 + Math.abs(charIndex));
    }
    return encoded;
  };

  this.decode = function (encoded) {
    var message = "";
    for (var i = 0; i < encoded.length; i++) {
      var charIndex = (encoded[i].charCodeAt(0) - 97) - (this.key[i].charCodeAt(0) - 97);
      while (charIndex < 0) {
        charIndex += 26;
      }
      message += String.fromCharCode(97 + Math.abs(charIndex));
    }
    return message;
  }
};

module.exports = Cipher;