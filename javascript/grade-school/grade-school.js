function School() {
  this.rosters = {};

  this.roster = function () {
    return this.rosters;
  };

  this.grade = function (grade) {
    return this.rosters[grade] ? this.rosters[grade] : [];
  };

  this.add = function(name, grade) {
    if (!this.rosters[grade]) {
      this.rosters[grade] = [];
    }
    this.rosters[grade].push(name);
    this.rosters[grade].sort();
  }
}

module.exports = School;