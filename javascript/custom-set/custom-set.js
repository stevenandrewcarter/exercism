var CustomSet = function (array) {
  this.set = [];
  if (array != null) {
    for (var i = 0; i < array.length; i++) {
      this.put(array[i]);
    }
  }
};

CustomSet.prototype.delete = function (value) {
  if (this.set.indexOf(value) >= 0) {
    this.set.splice(this.set.indexOf(value), 1);
  }
  return this;
};

CustomSet.prototype.difference = function (other) {
  var unique = [];
  for (var i = 0; i < this.set.length; i++) {
    if (other.set.indexOf(this.set[i]) === -1) {
      unique.push(this.set[i]);
    }
  }
  return new CustomSet(unique);
};

CustomSet.prototype.intersection = function (other) {
  var unique = [];
  for (var i = 0; i < this.set.length; i++) {
    if (other.set.indexOf(this.set[i]) >= 0) {
      unique.push(this.set[i]);
    }
  }
  return new CustomSet(unique);
};

CustomSet.prototype.disjoint = function (other) {
  var hasItem = false;
  for (var i = 0; i < this.set.length && !hasItem; i++) {
    if (other.set.indexOf(this.set[i]) >= 0) {
      hasItem = true;
    }
  }
  return !hasItem;
};

CustomSet.prototype.empty = function () {
  this.set = [];
  return this;
};

CustomSet.prototype.member = function (value) {
  return this.set.indexOf(value) >= 0;
};

CustomSet.prototype.put = function (value) {
  if (this.set.indexOf(value) === -1) {
    this.set.push(value);
  }
  this.set.sort();
  return this;
};

CustomSet.prototype.eql = function (other) {
  if (this.set.length != other.set.length)
    return false;

  for (var i = 0, l = this.set.length; i < l; i++) {
    if (this.set[i] != other.set[i]) {
      return false;
    }
  }
  return true;
};

CustomSet.prototype.subset = function (other) {
  if (other.size() > this.size()) {
    return false;
  }
  var subset = true;
  for (var i = 0; i < other.size() && subset; i++) {
    if (!this.member(other.set[i])) {
      subset = false;
    }
  }
  return subset;
};

CustomSet.prototype.toList = function () {
  return this.set;
};

CustomSet.prototype.size = function () {
  return this.set.length;
};

CustomSet.prototype.union = function (other) {
  for (var i = 0; i < other.size(); i++) {
    this.put(other.set[i]);
  }
  return this;
};

module.exports = CustomSet;