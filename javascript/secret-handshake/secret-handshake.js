function zeroFill(number, width) {
  width -= number.toString().length;
  if (width > 0) {
    return number + new Array(width + (/\./.test(number) ? 2 : 1)).join('0');
  }
  return number + ""; // always return a string
}

var SecretHandshake = function (handshake) {
  if (isNaN(handshake)) {
    throw new Error('Handshake must be a number');
  }
  this.handshake = (handshake >>> 0).toString(2);
};

SecretHandshake.prototype.commands = function () {
  var commands = [];
  for (var c = this.handshake.length - 1; c >= 0; c--) {
    var command = zeroFill(+this.handshake[c], this.handshake.length - (c));
    switch (command) {
      case '1':
        commands.push("wink");
        break;
      case '10':
        commands.push("double blink");
        break;
      case '100':
        commands.push("close your eyes");
        break;
      case '1000':
        commands.push("jump");
        break;
      case '10000':
        commands = commands.reverse();
        break;
    }
  }
  return commands;
};

module.exports = SecretHandshake;