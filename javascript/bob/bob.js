function isLetter(n) {
  var upper = n.toUpperCase();
  return upper != ' ' && (upper >= 'A' && upper <= 'Z') || (upper == '\xc4' || upper == '\xe4' || upper == '\xdc' || upper == '\xfc');
}

function isUpperCase(n) {
 return n != ' ' && n == n.toUpperCase()
}

function isShouting(input) {
  var numberOfLetters = 0;
  var upperCaseLetters = 0;
  for (var i = 0; i < input.length; i++) {
    if (isLetter(input[i])) {
      numberOfLetters++;
      if (isUpperCase(input[i])) {
        upperCaseLetters++;
      }
    }
  }
  return numberOfLetters > 0 && numberOfLetters == upperCaseLetters;
}

function isQuestion(input) {
  return input[input.length - 1] == '?';
}

function isSilence(input) {
  return input.length == 0;
}

var Bob = function () {
};

Bob.prototype.hey = function (input) {
  input = input.trim();
  var response = 'Whatever.';
  if (isSilence(input)) {
    return 'Fine. Be that way!';
  }
  if (isShouting(input)) {
    response = 'Whoa, chill out!';
  } else if (isQuestion(input)) {
    response = 'Sure.';
  }
  return response;
};

module.exports = Bob;
