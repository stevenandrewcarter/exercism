using System;
using System.Collections.Generic;
using System.Linq;

enum Plant
{
  Radishes, Clover, Grass, Violets
}

class Garden
{
  public Garden(string[] names, string layout)
  {
    Layout = layout;
    Names = names.OrderBy(o => o).ToArray();
  }

  public static Garden DefaultGarden(string layout)
  {
    return new Garden(new string[] { "Alice", "Bob", "Charlie", "David", "Eve", "Fred", "Ginny", "Harriet", "Ileana", "Joseph", "Kincaid", "Larry" }, layout);
  }

  public Plant[] GetPlants(string name)
  {
    var index = Array.IndexOf(Names, name);
    if (index >= 0)
    {
      var rows = Layout.Split('\n');
      var plants = new List<Plant>();
      foreach (var row in rows)
      {
        for (var c = index * 2; c < index * 2 + 2; c++)
        {
          plants.Add(GetPlantFromChar(row[c]));
        }
      }
      return plants.ToArray();
    }
    return new Plant[] { };
  }

  private Plant GetPlantFromChar(char plant)
  {
    switch (plant)
    {
      case 'R':
        return Plant.Radishes;
      case 'C':
        return Plant.Clover;
      case 'G':
        return Plant.Grass;
      case 'V':
        return Plant.Violets;
    }
    return Plant.Clover;
  }

  private string Layout { get; }
  private string[] Names { get; }
}