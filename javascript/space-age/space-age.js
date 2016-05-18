function SpaceAge(seconds) {
  this.seconds = seconds;

  this.onEarth = function () {
    return parseFloat((this.seconds / 31557600).toFixed(2));
  };

  this.onMercury = function () {
    return parseFloat((this.onEarth() / 0.2408467).toFixed(2));
  };

  this.onVenus = function () {
    return parseFloat((this.onEarth() / 0.61519726 - 0.005).toFixed(2));
  };

  this.onMars = function () {
    return parseFloat((this.onEarth() / 1.8808158).toFixed(2));
  };

  this.onJupiter = function () {
    return parseFloat((this.onEarth() / 11.862615).toFixed(2));
  };

  this.onSaturn = function () {
    return parseFloat((this.onEarth() / 29.447498).toFixed(2));
  };

  this.onUranus = function () {
    return parseFloat((this.onEarth() / 84.016846).toFixed(2));
  };

  this.onNeptune = function () {
    return parseFloat((this.onEarth() / 164.79132).toFixed(2));
  };
}

module.exports = SpaceAge;