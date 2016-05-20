using System;
using System.Collections.Generic;

class SecretHandshake
{
  public static string[] Commands(int command)
  {
    var result = Convert.ToString(command, 2);
    var commands = new List<string>();
    for (var c = result.Length - 1; c >= 0; c--)
    {
      var current = char.GetNumericValue(result[c]).ToString().PadRight(result.Length - c, '0');
      switch (current)
      {
        case "1":
          commands.Add("wink");
          break;
        case "10":
          commands.Add("double blink");
          break;
        case "100":
          commands.Add("close your eyes");
          break;
        case "1000":
          commands.Add("jump");
          break;
        case "10000":
          commands.Reverse();
          break;
      }
    }
    return commands.ToArray();
  }
}