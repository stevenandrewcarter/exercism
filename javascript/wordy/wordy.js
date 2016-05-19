var ArgumentError = function () {

};

module.exports.ArgumentError = ArgumentError;

var WordProblem = function (question) {
  this.question = question.split(' ');
};

WordProblem.prototype.answer = function () {
  var answer = '';
  for (var i = 0; i < this.question; i++) {

  }
  return answer;
};

module.exports.WordProblem = WordProblem;