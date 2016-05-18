var BufferEmptyException = function () {
};

var BufferFullException = function () {
};

var CircularBuffer = function (size) {
  this.clear = function () {
    this.items = [];
    this.itemCount = 0;
  };

  this.size = size;
  this.clear();

  this.read = function () {
    if (this.items == undefined || this.itemCount == 0) {
      throw new BufferEmptyException();
    }
    var result = this.items.shift();
    this.itemCount -= 1;
    return result;
  };

  this.write = function (value) {
    if (value != null) {
      if (this.itemCount == this.size) {
        throw new BufferFullException();
      }
      this.itemCount += 1;
      this.items.push(value);
    }
  };

  this.forceWrite = function (value) {
    if (this.itemCount == this.size) {
      this.read();
    }
    this.write(value);
  }
};

module.exports.bufferEmptyException = function () {
  return new BufferEmptyException();
};

module.exports.circularBuffer = function (size) {
  return new CircularBuffer(size);
};

module.exports.bufferFullException = function () {
  return new BufferFullException();
};