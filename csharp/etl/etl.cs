using System.Collections.Generic;

class ETL
{
  public static Dictionary<string, int> Transform(Dictionary<int, IList<string>> data)
  {
    var transformed = new Dictionary<string, int>();
    foreach (var kv in data)
    {
      foreach (var letter in kv.Value)
      {
        transformed.Add(letter.ToLower(), kv.Key);
      }
    }
    return transformed;
  }
}