using System;

class Queen
{
  public Queen(int x, int y)
  {
    X = x;
    Y = y;
  }

  public int X { get; set; }
  public int Y { get; set; }

  public override bool Equals(object obj)
  {
    var compare = (Queen)obj;
    return X == compare.X && Y == compare.Y;
  }
}

class Queens
{
  public Queens(Queen white, Queen black)
  {
    if (white.Equals(black))
    {
      throw new ArgumentException();
    }
    White = white;
    Black = black;
  }

  public bool CanAttack()
  {
    if (White.X == Black.X)
      return true;
    if (White.Y == Black.Y)
      return true;
    if (Math.Abs(White.X - Black.X) == Math.Abs(White.Y - Black.Y))
      return true;
    return false;
  }

  public Queen White { get; set; }
  public Queen Black { get; set; }
}