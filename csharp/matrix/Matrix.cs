using System.Collections.Generic;

class Matrix
{
  public Matrix(string definition)
  {
    var rows = definition.Split('\n');    
    Rows = rows.Length;
    for (var i = 0; i < Rows; i++)
    {
      var row = rows[i].Split(' ');
      Cols = row.Length;
      if (matrix == null)
        matrix = new int[Rows, Cols];
      for (var j = 0; j < Cols; j++)
      {
        matrix[i, j] = int.Parse(row[j]);
      }
    }
  }

  public int[] Row(int rowNumber)
  {
    var row = new List<int>();
    for (var j = 0; j < Cols; j++)
    {
      row.Add(matrix[rowNumber, j]);
    }
    return row.ToArray();
  }

  public int[] Col(int columnNumber)
  {
    var column = new List<int>();
    for (var j = 0; j < Rows; j++)
    {
      column.Add(matrix[j, columnNumber]);
    }
    return column.ToArray();
  }

  public int Rows { get; set; }
  public int Cols { get; set; }

  private int[,] matrix;
}
