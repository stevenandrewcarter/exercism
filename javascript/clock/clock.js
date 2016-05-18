var Clock = function (hour, minutes) {
  this.setMinutes = function () {
    while (this.minutes >= 60) {
      this.minutes = this.minutes - 60;
      this.hour = this.hour + 1;
    }
    while (this.minutes < 0) {
      this.minutes += 60;
      this.hour -= 1;
    }
  };

  this.setHours = function () {
    while (this.hour >= 24) {
      this.hour = this.hour - 24;
    }
    while (this.hour < 0) {
      this.hour += 24;
    }
  };

  this.plus = function(minutes) {
    this.minutes += minutes;
    this.setMinutes();
    this.setHours();
    return this;
  };

  this.minus = function (minutes) {
    this.minutes -= minutes;
    this.setMinutes();
    this.setHours();
    return this;
  };

  this.hour = hour;
  this.minutes = minutes != undefined ? minutes : 0;
  this.setMinutes();
  this.setHours();

  this.toString = function () {
    return ('0' + this.hour.toString()).slice(-2) + ":" + ('0' + this.minutes.toString()).slice(-2);
  };

  this.equals = function (other) {
    return this.hour == other.hour && this.minutes == other.minutes;
  }
};

module.exports.at = function(hour, minutes) {
  return new Clock(hour, minutes);
};