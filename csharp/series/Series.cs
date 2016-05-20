using System.Collections.Generic;

public class Series
{
  public Series(string input)
  {
    series = input;
  }

  public int[][] Slices(int slice)
  {
    if (slice > series.Length) throw new System.ArgumentException();
    var slices = new Dictionary<int, List<int>>();
    var pos = 0;
    try
    {
      while (pos < series.Length)
      {
        var newSlice = series.Substring(pos, slice);
        var listValues = new List<int>();
        foreach (var c in newSlice)
        {
          listValues.Add((int)char.GetNumericValue(c));
        }
        slices.Add(pos, listValues);
        pos++;
      }
    }
    catch (System.ArgumentOutOfRangeException)
    {

    }
    int[][] result = new int[slices.Count][];
    foreach (var s in slices)
    {
      result[s.Key] = s.Value.ToArray();
    }
    return result;
  }

  private string series;
}