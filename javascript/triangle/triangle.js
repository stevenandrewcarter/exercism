function Triangle(a, b, c) {
  this.a = a;
  this.b = b;
  this.c = c;

  this.kind = function () {
    if ((this.a == 0 && this.b == 0 && this.c == 0) || this.a < 0 || this.b < 0 || this.c < 0) {
      throw new Error();
    }
    if ((this.a + this.b < this.c) || (this.b + this.c < this.a) || (this.c + this.a < this.b)) {
      throw new Error();
    }
    kindName = "";
    if (this.a == this.b && this.b == this.c) {
      kindName = "equilateral";
    }
    else if (this.a == this.b || this.b == this.c || this.a == this.c) {
      kindName = "isosceles";
    } else {
      kindName = "scalene";
    }
    return kindName;
  };
}

module.exports = Triangle;