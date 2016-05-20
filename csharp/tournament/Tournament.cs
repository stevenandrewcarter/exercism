using System.Collections.Generic;
using System.IO;
using System.Linq;

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