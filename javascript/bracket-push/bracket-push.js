module.exports = function(bracketsString) {
  var brackets = [];
  for (var c = 0; c < bracketsString.length; c++) {
    var bracket = bracketsString[c];
    if (bracket == '{' || bracket == '(' || bracket == '[') {
      brackets.push(bracket);
    } else {
      var previousBracket = brackets.pop();
      if ((bracket == '}' && previousBracket != '{') || (bracket == ']' && previousBracket != '[') || (bracket == ')' && previousBracket != '(')) {
        return false;
      }
    }
  }
  return brackets.length == 0;
};