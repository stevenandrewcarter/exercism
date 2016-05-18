function isDigit(n) {
  var n = n.toLowerCase();
  return n != ' ' && n >= '0' && n <= '9';
}

var PhoneNumber = function (phoneNumber) {
  this.phoneNumber = phoneNumber;
};

PhoneNumber.prototype.number = function () {
  var numbers = "";
  for (var i = 0; i < this.phoneNumber.length; i++) {
    if (isDigit(this.phoneNumber[i])) {
      numbers += this.phoneNumber[i]
    }
  }
  if (numbers.length == 11 && numbers[0] == '1') {
    numbers = numbers.substr(1, 10);
  }
  return numbers.length != 10 ? "0000000000" : numbers;
};

PhoneNumber.prototype.areaCode = function () {
  return this.number().substr(0, 3);
};

PhoneNumber.prototype.toString = function () {
  return '(' + this.areaCode() + ') ' + this.number().substr(3, 3) + '-' + this.number().substr(6, 4);
};

module.exports = PhoneNumber;
