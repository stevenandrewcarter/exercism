var allergies = [];

var Allergies = function (score) {
  this.allergicTo = function (allergy) {
    return allergies.indexOf(allergy) >= 0;
  };

  this.addAllergy = function (allergy, currentIndex, index) {
    if (currentIndex >= index) {
      if (!this.allergicTo(allergy)) {
        allergies.push(allergy);
      }
      while (currentIndex >= index) {
        currentIndex -= index;
      }
    }
    return currentIndex;
  };

  allergies = [];
  score = this.addAllergy("cats", score, 128);
  score = this.addAllergy("pollen", score, 64);
  score = this.addAllergy("chocolate", score, 32);
  score = this.addAllergy("tomatoes", score, 16);
  score = this.addAllergy("strawberries", score, 8);
  score = this.addAllergy("shellfish", score, 4);
  score = this.addAllergy("peanuts", score, 2);
  this.addAllergy("eggs", score, 1);


  this.list = function () {
    return allergies.reverse();
  };
};

module.exports = Allergies;