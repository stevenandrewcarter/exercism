var generatedNames = [];

function generateName() {
  var generatedName = false;
  var name = '';
  while (!generatedName) {
    name = String.fromCharCode(97 + Math.floor((Math.random() * 25) + 1)).toUpperCase();
    name += String.fromCharCode(97 + Math.floor((Math.random() * 25) + 1)).toUpperCase();
    name += Math.floor((Math.random() * 10));
    name += Math.floor((Math.random() * 10));
    name += Math.floor((Math.random() * 10));
    if (generatedNames.indexOf(name) === -1) {
      generatedNames.push(name);
      generatedName = true;
    }
  }
  return name;
}

function Robot() {
  this.name = generateName();

  this.reset = function () {
    this.name = generateName();
  }
}

module.exports = Robot;