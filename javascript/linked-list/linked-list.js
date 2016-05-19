var Node = function (value) {
  this.value = value;
  this.previous = null;
  this.next = null;
};

var LinkedList = function () {
  this.begin = new Node(null);
  this.end = new Node(null);
  this.begin.next = this.end;
  this.end.previous = this.begin;
  this.size = 0;
};

LinkedList.prototype.push = function (value) {
  var node = new Node(value);
  var previous = this.end.previous;
  previous.next = node;
  node.previous = previous;
  node.next = this.end;
  this.end.previous = node;
  this.size += 1;
};

LinkedList.prototype.pop = function () {
  var node = this.end.previous;
  this.end.previous = node.previous;
  node.previous.next = this.end;
  this.size -= 1;
  return node.value;
};

LinkedList.prototype.shift = function () {
  var node = this.begin.next;
  node.next.previous = this.begin;
  this.begin.next = node.next;
  this.size -= 1;
  return node.value;
};

LinkedList.prototype.unshift = function (value) {
  var node = new Node(value);
  var next = this.begin.next;
  next.previous = node;
  this.begin.next = node;
  node.previous = this.begin;
  node.next = next;
  this.size += 1;
};

LinkedList.prototype.count = function () {
  return this.size;
};

LinkedList.prototype.delete = function (value) {
  var currentNode = this.begin;
  while (currentNode != this.end) {
    if (currentNode.value == value) {
      currentNode.previous.next = currentNode.next;
      currentNode.next.previous = currentNode.previous;
      this.size -= 1;
      return;
    }
    currentNode = currentNode.next;
  }
};

module.exports = LinkedList;