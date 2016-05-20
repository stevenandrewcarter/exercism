var ArgumentError = function () {

};

module.exports.ArgumentError = ArgumentError;

var WordNode = function (value) {
  this.value = value;
};

WordNode.prototype.calculate = function () {

};

var WordProblem = function (question) {
  this.question = question.split(' ');
};

WordProblem.prototype.answer = function () {
  var answer = new WordNode();
  for (var i = 0; i < this.question; i++) {

  }
  return answer.calculate();
};

module.exports.WordProblem = WordProblem;