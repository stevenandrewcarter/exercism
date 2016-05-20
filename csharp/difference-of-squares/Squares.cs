using System;

class Squares
{
  public Squares(int aMaxLimit)
  {
    if (aMaxLimit < 0) throw new ArgumentException();    
    for (var i = 1; i <= aMaxLimit; i++)
    {
      squareOfSums += i;
      sumOfSquares += (int)Math.Pow(i, 2);
    }
  }

  public int SquareOfSums()
  {    
    return (int)Math.Pow(squareOfSums, 2);
  }

  public int SumOfSquares()
  { 
    return sumOfSquares;
  }

  public int DifferenceOfSquares()
  {
    return SquareOfSums() - SumOfSquares();
  }

  private int squareOfSums;
  private int sumOfSquares;
}