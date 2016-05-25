var Bst = function (data) {
  this.data = data;
  this.left = null;
  this.right = null;
};

Bst.prototype.insert = function (data) {
  if (data <= this.data) {
    if (this.left == null) {
      this.left = new Bst(data);
    } else {
      this.left.insert(data);
    }
  } else {
    if (this.right == null) {
      this.right = new Bst(data);
    } else {
      this.right.insert(data);
    }
  }
};

Bst.prototype.each = function (func) {
  if (this.left) this.left.each(func);
  func(this.data);
  if (this.right) this.right.each(func);
};

module.exports = Bst;