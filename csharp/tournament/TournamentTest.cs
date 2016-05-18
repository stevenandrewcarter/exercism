using System;
using System.Linq;
using System.IO;
using System.Text;
using NUnit.Framework;
using System.Collections.Generic;

class Team
{
  public Team(string name)
  {
    Name = name;
    Played = 0;
    Won = 0;
    Lost = 0;
    Draw = 0;
    Points = 0;
  }

  public void AddResult(string result)
  {
    if (result == "win")
    {
      Won++;
      Points += 3;
    }
    if (result == "draw")
    {
      Draw++;
      Points += 1;
    }
    if (result == "loss")
    {
      Lost++;
    }
    Played++;
  }

  public string Name { get; }
  public int Played { get; private set; }
  public int Won { get; private set; }
  public int Lost { get; private set; }
  public int Draw { get; private set; }
  public int Points { get; private set; }
}

class Tournament
{
  public static void Tally(MemoryStream inStream, MemoryStream outStream)
  {
    var table = new Dictionary<string, Team>();
    var reader = new StreamReader(inStream);
    while (!reader.EndOfStream)
    {
      var line = reader.ReadLine();
      var splitLine = line.Split(';');
      if (splitLine.Length == 3)
      {
        var teamOne = splitLine[0];
        var teamTwo = splitLine[1];
        var result = splitLine[2];
        if (result == "win" || result == "loss" || result == "draw")
        {
          if (!table.ContainsKey(teamOne))
            table.Add(teamOne, new Team(teamOne));
          if (!table.ContainsKey(teamTwo))
            table.Add(teamTwo, new Team(teamTwo));
          table[teamOne].AddResult(result);
          if (result == "win")
            table[teamTwo].AddResult("loss");
          else if (result == "loss")
            table[teamTwo].AddResult("win");
          else
            table[teamTwo].AddResult("draw");
        }
      }
    }
    var writer = new StreamWriter(outStream);
    writer.WriteLine("Team                           | MP |  W |  D |  L |  P");
    var orderedTable = from entry in table orderby entry.Value.Points descending select entry;
    foreach (var team in orderedTable)
    {
      writer.WriteLine(team.Value.Name.PadRight(31) + "|" +
                       team.Value.Played.ToString().PadLeft(3) + " |" +
                       team.Value.Won.ToString().PadLeft(3) + " |" +
                       team.Value.Draw.ToString().PadLeft(3) + " |" +
                       team.Value.Lost.ToString().PadLeft(3) + " |" +
                       team.Value.Points.ToString().PadLeft(3));      
    }
    writer.Flush();
  }
}

[TestFixture]
public class TournamentTest
{
  readonly string input1 = @"
Αllegoric Alaskians;Blithering Badgers;win
Devastating Donkeys;Courageous Californians;draw
Devastating Donkeys;Αllegoric Alaskians;win
Courageous Californians;Blithering Badgers;loss
Blithering Badgers;Devastating Donkeys;loss
Αllegoric Alaskians;Courageous Californians;win
".Trim();

  readonly string input2 = @"
Allegoric Alaskians;Blithering Badgers;win
Devastating Donkeys_Courageous Californians;draw
Devastating Donkeys;Allegoric Alaskians;win

Courageous Californians;Blithering Badgers;loss
Bla;Bla;Bla
Blithering Badgers;Devastating Donkeys;loss
# Yackity yackity yack
Allegoric Alaskians;Courageous Californians;win
Devastating Donkeys;Courageous Californians;draw
Devastating Donkeys@Courageous Californians;draw
"; // Trim() omitted by design

  readonly string input3 = @"
Allegoric Alaskians;Blithering Badgers;win
Devastating Donkeys;Allegoric Alaskians;win
Courageous Californians;Blithering Badgers;loss
Allegoric Alaskians;Courageous Californians;win
".Trim();

  readonly string expected1 = @"
Team                           | MP |  W |  D |  L |  P
Devastating Donkeys            |  3 |  2 |  1 |  0 |  7
Αllegoric Alaskians            |  3 |  2 |  0 |  1 |  6
Blithering Badgers             |  3 |  1 |  0 |  2 |  3
Courageous Californians        |  3 |  0 |  1 |  2 |  1
".Trim();

  readonly string expected2 = @"
Team                           | MP |  W |  D |  L |  P
Devastating Donkeys            |  3 |  2 |  1 |  0 |  7
Allegoric Alaskians            |  3 |  2 |  0 |  1 |  6
Blithering Badgers             |  3 |  1 |  0 |  2 |  3
Courageous Californians        |  3 |  0 |  1 |  2 |  1
".Trim();

  readonly string expected3 = @"
Team                           | MP |  W |  D |  L |  P
Allegoric Alaskians            |  3 |  2 |  0 |  1 |  6
Blithering Badgers             |  2 |  1 |  0 |  1 |  3
Devastating Donkeys            |  1 |  1 |  0 |  0 |  3
Courageous Californians        |  2 |  0 |  0 |  2 |  0
".Trim();

  private string RunTally(string input)
  {
    var encoding = new UTF8Encoding();

    using (var inStream = new MemoryStream(encoding.GetBytes(input)))
    {
      using (var outStream = new MemoryStream())
      {
        Tournament.Tally(inStream, outStream);
        return encoding.GetString(outStream.GetBuffer());
      }
    }
  }

  [Test]
  public void Test_good()
  {
    Assert.That(RunTally(input1).Trim(), Is.EqualTo(expected1));
  }

  [Test]  
  public void Test_ignore_bad_lines()
  {
    Assert.That(RunTally(input2).Trim(), Is.EqualTo(expected2));
  }

  [Test]  
  public void Test_incomplete_competition()
  {
    Assert.That(RunTally(input3).Trim(), Is.EqualTo(expected3));
  }
}
