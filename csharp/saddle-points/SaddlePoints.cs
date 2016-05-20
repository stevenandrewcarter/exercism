using System;
using System.Collections.Generic;

class SaddlePoints
{
  public SaddlePoints(int[,] matrix)
  {
    Matrix = matrix;
  }

  public Tuple<int, int>[] Calculate()
  {
    var tuples = new List<Tuple<int, int>>();
    for (var x = 0; x < Matrix.GetLength(0); x++)
    {
      for (var y = 0; y < Matrix.GetLength(1); y++)
      {
        var value = Matrix[x, y];
        if (MaxInRow(x, value) && MinInColumn(y, value))
          tuples.Add(new Tuple<int, int>(x, y));
      }
    }
    return tuples.ToArray();
  }

  private bool MinInColumn(int colNumber, int value)
  {
    for (var x = 0; x < Matrix.GetLength(0); x++)
    {
      if (Matrix[x, colNumber] < value)
        return false;
    }
    return true;
  }

  private bool MaxInRow(int rowNumber, int value)
  {
    for (var y = 0; y < Matrix.GetLength(1); y++)
    {
      if (Matrix[rowNumber, y] > value)
        return false;
    }
    return true;
  }

  private int[,] Matrix { get; }
}