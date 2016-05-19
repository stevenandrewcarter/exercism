function buildAddIns(numberText, alternating) {
  var addends = [];
  for (var i = numberText.length - 1; i >= 0; i--) {
    var n = parseInt(numberText[i]);
    var r = alternating ? n * 2 : n;
    if (r > 9) {
      r -= 9;
    }
    addends.push(r);
    alternating = !alternating;
  }
  return addends.reverse();
}

var Luhn = function (number) {
  this.numberText = number.toString();
  this.checkDigit = parseInt(this.numberText[this.numberText.length - 1]);
  this.addends = buildAddIns(this.numberText, false);
  this.checksum = this.addends.reduce(function (a, b) {
    return a + b;
  });
  this.valid = this.checksum % 10 == 0;
};

Luhn.create = function (number) {
  var numberText = number.toString();
  var addEnds = buildAddIns(numberText, true);
  var checksum = addEnds.reduce(function (a, b) {
    return a + b;
  });
  if (checksum % 10 == 0) {
    numberText += '0';
  } else {
    var checksumText = checksum.toString();
    var lastNumber = parseInt(checksumText[checksumText.length - 1]);
    numberText += (10 - lastNumber).toString();
  }
  return parseInt(numberText);
};

module.exports = Luhn;