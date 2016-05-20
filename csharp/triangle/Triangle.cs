enum TriangleKind
{
  Equilateral,
  Isosceles,
  Scalene
}

class TriangleException : System.Exception
{

}

class Triangle
{
  public static TriangleKind Kind(decimal a, decimal b, decimal c)
  {
    if (a == 0 && b == 0 && c == 0)
      throw new TriangleException();
    if (a < 0 || b < 0 || c < 0)
      throw new TriangleException();
    if ((a + b <= c) || (a + c <= b) || (b + c <= a))
      throw new TriangleException();
    if (a == b && b == c)
      return TriangleKind.Equilateral;
    else if (a == b || b == c || a == c)
      return TriangleKind.Isosceles;
    return TriangleKind.Scalene;
  }
}