enum Bearing
{
  North, East, South, West
}

class Coordinate
{
  public Coordinate(int x, int y)
  {
    X = x;
    Y = y;
  }

  public override bool Equals(object obj)
  {
    var compare = (Coordinate)obj;
    return X == compare.X && Y == compare.Y;
  }

  public void Adjust(Bearing bearing)
  {
    switch (bearing)
    {
      case Bearing.North:
        Y = Y + 1;
        break;
      case Bearing.East:
        X = X + 1;
        break;
      case Bearing.South:
        Y = Y - 1;
        break;
      case Bearing.West:
        X = X - 1;
        break;
    }
  }

  public int X { get; set; }
  public int Y { get; set; }
}

class RobotSimulator
{
  public RobotSimulator(Bearing bearing, Coordinate coordinate)
  {
    Bearing = bearing;
    Coordinate = coordinate;
  }

  public void TurnLeft()
  {
    switch (Bearing)
    {
      case Bearing.North:
        Bearing = Bearing.West;
        break;
      case Bearing.East:
        Bearing = Bearing.North;
        break;
      case Bearing.South:
        Bearing = Bearing.East;
        break;
      case Bearing.West:
        Bearing = Bearing.South;
        break;
    }
  }

  public void TurnRight()
  {
    switch (Bearing)
    {
      case Bearing.North:
        Bearing = Bearing.East;
        break;
      case Bearing.East:
        Bearing = Bearing.South;
        break;
      case Bearing.South:
        Bearing = Bearing.West;
        break;
      case Bearing.West:
        Bearing = Bearing.North;
        break;
    }
  }

  public void Simulate(string commands)
  {
    foreach (var c in commands)
    {
      switch(c)
      {
        case 'R':
          TurnRight();
          break;
        case 'L':
          TurnLeft();
          break;
        case 'A':
          Coordinate.Adjust(Bearing);
          break;
      }
    }
  }

  public Bearing Bearing { get; set; }
  public Coordinate Coordinate { get; set; }
}
