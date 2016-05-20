using System.Collections.Generic;

class PascalsTriangle
{
  public static int[][] Calculate(int rows)
  {
    var triangle = new List<int[]>();
    for (var i = 0; i < rows; i++)
    {
      int c = 1;
      var row = new List<int>();
      for (int x = 0; x <= i; x++)
      {
        row.Add(c);
        c = c * (i - x) / (x + 1);
      }
      triangle.Add(row.ToArray());
    }
    return triangle.ToArray();
  }
}