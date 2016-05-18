function Gigasecond(startDate) {
  this.startDate = startDate;

  this.date = function () {
    var adjusted = new Date(this.startDate.getTime() + 1000 * 1e9);
    return adjusted;
  }
}

module.exports = Gigasecond;
