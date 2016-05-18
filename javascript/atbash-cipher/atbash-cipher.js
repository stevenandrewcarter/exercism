var decoded = "abcdefghijklmnopqrstuvwxyz";
var encoded = "zyxwvutsrqponmlkjihgfedcba";

module.exports = {
  encode: function (message) {
    var result = "";
    var breakPoint = 5;
    var currentPoint = 0;
    for (var i = 0; i < message.length; i++) {
      var c = message[i].toLowerCase();
      if (c != ' ' && ((c >= 'a' && c <= 'z') || (c >= '0' && c <= '9') )) {
        var index = decoded.indexOf(c);
        result += index >= 0 ? encoded[index] : c;
        currentPoint += 1;
      }
      if (currentPoint / breakPoint == 1) {
        result += ' ';
        currentPoint = 0;
      }
    }
    return result.trim();
  }
};
