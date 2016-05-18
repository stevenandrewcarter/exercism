﻿using System;
using NUnit.Framework;
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

public class SaddlePointTests
{
  [Test]
  public void Readme_example()
  {
    var values = new[,]
    {
            { 9, 8, 7 },
            { 5, 3, 2 },
            { 6, 6, 7 }
        };
    var actual = new SaddlePoints(values).Calculate();
    Assert.That(actual, Is.EqualTo(new[] { Tuple.Create(1, 0) }));
  }

  [Test]
  public void No_saddle_point()
  {
    var values = new[,]
    {
            { 2, 1 },
            { 1, 2 }
        };
    var actual = new SaddlePoints(values).Calculate();
    Assert.That(actual, Is.Empty);
  }

  [Test]
  public void Saddle_point()
  {
    var values = new[,]
    {
            { 1, 2 },
            { 3, 4 }
        };
    var actual = new SaddlePoints(values).Calculate();
    Assert.That(actual, Is.EqualTo(new[] { Tuple.Create(0, 1) }));
  }

  [Test]
  public void Another_saddle_point()
  {
    var values = new[,]
    {
            { 18,  3, 39, 19,  91 },
            { 38, 10,  8, 77, 320 },
            {  3,  4,  8,  6,   7 }
        };
    var actual = new SaddlePoints(values).Calculate();
    Assert.That(actual, Is.EqualTo(new[] { Tuple.Create(2, 2) }));
  }

  [Test]
  public void Multiple_saddle_points()
  {
    var values = new[,]
    {
            { 4, 5, 4 },
            { 3, 5, 5 },
            { 1, 5, 4 }
        };
    var actual = new SaddlePoints(values).Calculate();
    Assert.That(actual, Is.EqualTo(new[] { Tuple.Create(0, 1), Tuple.Create(1, 1), Tuple.Create(2, 1) }));
  }
}