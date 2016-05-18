using NUnit.Framework;
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

public class KinderGartenGardenTest
{
  [Test]
  public void Missing_child()
  {
    var actual = Garden.DefaultGarden("RC\nGG").GetPlants("Potter");
    Assert.That(actual, Is.Empty);
  }
  
  [Test]
  public void Alice()
  {
    Assert.That(Garden.DefaultGarden("RC\nGG").GetPlants("Alice"), Is.EqualTo(new[] { Plant.Radishes, Plant.Clover, Plant.Grass, Plant.Grass }));
    Assert.That(Garden.DefaultGarden("VC\nRC").GetPlants("Alice"), Is.EqualTo(new[] { Plant.Violets, Plant.Clover, Plant.Radishes, Plant.Clover }));
  }

  [Test]
  public void Small_garden()
  {
    var actual = Garden.DefaultGarden("VVCG\nVVRC").GetPlants("Bob");
    Assert.That(actual, Is.EqualTo(new[] { Plant.Clover, Plant.Grass, Plant.Radishes, Plant.Clover }));
  }
  
  [Test]
  public void Medium_garden()
  {
    var garden = Garden.DefaultGarden("VVCCGG\nVVCCGG");
    Assert.That(garden.GetPlants("Bob"), Is.EqualTo(new[] { Plant.Clover, Plant.Clover, Plant.Clover, Plant.Clover }));
    Assert.That(garden.GetPlants("Charlie"), Is.EqualTo(new[] { Plant.Grass, Plant.Grass, Plant.Grass, Plant.Grass }));
  }
  
  [Test]
  public void Full_garden()
  {
    var garden = Garden.DefaultGarden("VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV");
    Assert.That(garden.GetPlants("Alice"), Is.EqualTo(new[] { Plant.Violets, Plant.Radishes, Plant.Violets, Plant.Radishes }));
    Assert.That(garden.GetPlants("Bob"), Is.EqualTo(new[] { Plant.Clover, Plant.Grass, Plant.Clover, Plant.Clover }));
    Assert.That(garden.GetPlants("David"), Is.EqualTo(new[] { Plant.Radishes, Plant.Violets, Plant.Clover, Plant.Radishes }));
    Assert.That(garden.GetPlants("Eve"), Is.EqualTo(new[] { Plant.Clover, Plant.Grass, Plant.Radishes, Plant.Grass }));
    Assert.That(garden.GetPlants("Fred"), Is.EqualTo(new[] { Plant.Grass, Plant.Clover, Plant.Violets, Plant.Clover }));
    Assert.That(garden.GetPlants("Ginny"), Is.EqualTo(new[] { Plant.Clover, Plant.Grass, Plant.Grass, Plant.Clover }));
    Assert.That(garden.GetPlants("Harriet"), Is.EqualTo(new[] { Plant.Violets, Plant.Radishes, Plant.Radishes, Plant.Violets }));
    Assert.That(garden.GetPlants("Ileana"), Is.EqualTo(new[] { Plant.Grass, Plant.Clover, Plant.Violets, Plant.Clover }));
    Assert.That(garden.GetPlants("Joseph"), Is.EqualTo(new[] { Plant.Violets, Plant.Clover, Plant.Violets, Plant.Grass }));
    Assert.That(garden.GetPlants("Kincaid"), Is.EqualTo(new[] { Plant.Grass, Plant.Clover, Plant.Clover, Plant.Grass }));
    Assert.That(garden.GetPlants("Larry"), Is.EqualTo(new[] { Plant.Grass, Plant.Violets, Plant.Clover, Plant.Violets }));
  }
  
  [Test]
  public void Surprise_garden()
  {
    var garden = new Garden(new[] { "Samantha", "Patricia", "Xander", "Roger" }, "VCRRGVRG\nRVGCCGCV");
    Assert.That(garden.GetPlants("Patricia"), Is.EqualTo(new[] { Plant.Violets, Plant.Clover, Plant.Radishes, Plant.Violets }));
    Assert.That(garden.GetPlants("Roger"), Is.EqualTo(new[] { Plant.Radishes, Plant.Radishes, Plant.Grass, Plant.Clover }));
    Assert.That(garden.GetPlants("Samantha"), Is.EqualTo(new[] { Plant.Grass, Plant.Violets, Plant.Clover, Plant.Grass }));
    Assert.That(garden.GetPlants("Xander"), Is.EqualTo(new[] { Plant.Radishes, Plant.Grass, Plant.Clover, Plant.Violets }));
  }
}