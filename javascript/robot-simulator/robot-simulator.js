var Robot = function () {
  this.bearing = "north";
  this.coordinates = [0, 0];
};

Robot.prototype.orient = function (direction) {
  if (direction != 'north' && direction != 'east' && direction != 'south' && direction != 'west') {
    throw 'Invalid Robot Bearing';
  }
  this.bearing = direction;
};

Robot.prototype.turnRight = function () {
  switch (this.bearing) {
    case "north":
      this.bearing = "east";
      break;
    case "east":
      this.bearing = "south";
      break;
    case "south":
      this.bearing = "west";
      break;
    case "west":
      this.bearing = "north";
      break;
  }
};

Robot.prototype.turnLeft = function () {
  switch (this.bearing) {
    case "north":
      this.bearing = "west";
      break;
    case "east":
      this.bearing = "north";
      break;
    case "south":
      this.bearing = "east";
      break;
    case "west":
      this.bearing = "south";
      break;
  }
};

Robot.prototype.at = function (x, y) {
  this.coordinates = [x, y];
};

Robot.prototype.advance = function () {
  switch (this.bearing) {
    case "north":
      this.coordinates = [this.coordinates[0], this.coordinates[1] + 1];
      break;
    case "east":
      this.coordinates = [this.coordinates[0] + 1, this.coordinates[1]];
      break;
    case "south":
      this.coordinates = [this.coordinates[0], this.coordinates[1] - 1];
      break;
    case "west":
      this.coordinates = [this.coordinates[0] - 1, this.coordinates[1]];
      break;
  }
};

Robot.prototype.instructions = function (instructions) {
  var converted = [];
  for (var i = 0; i < instructions.length; i++) {
    switch (instructions[i]) {
      case 'A':
        converted.push('advance');
        break;
      case 'R':
        converted.push('turnRight');
        break;
      case 'L':
        converted.push('turnLeft');
        break;
    }
  }
  return converted;
};

Robot.prototype.place = function (location) {
  this.at(location.x, location.y);
  this.orient(location.direction);
};

Robot.prototype.evaluate = function (instructions) {
  var convertedInstructions = this.instructions(instructions);
  for (var i = 0; i < convertedInstructions.length; i++) {
    this[convertedInstructions[i]]();
  }
};

module.exports = Robot;