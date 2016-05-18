using NUnit.Framework;
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

[TestFixture]
public class SecretHandshakeTests
{
  [Test]
  public void Test_1_handshake_to_wink()
  {
    Assert.That(SecretHandshake.Commands(1), Is.EqualTo(new[] { "wink" }));
  }
  
  [Test]
  public void Test_10_handshake_to_double_blink()
  {
    Assert.That(SecretHandshake.Commands(2), Is.EqualTo(new[] { "double blink" }));
  }
  
  [Test]
  public void Test_100_handshake_to_close_your_eyes()
  {
    Assert.That(SecretHandshake.Commands(4), Is.EqualTo(new[] { "close your eyes" }));
  }
  
  [Test]
  public void Test_1000_handshake_to_close_your_eyes()
  {
    Assert.That(SecretHandshake.Commands(8), Is.EqualTo(new[] { "jump" }));
  }

  [Test]
  public void Test_handshake_11_to_wink_and_double_blink()
  {
    Assert.That(SecretHandshake.Commands(3), Is.EqualTo(new[] { "wink", "double blink" }));
  }

  [Test]
  public void Test_handshake_10011_to_double_blink_and_wink()
  {
    Assert.That(SecretHandshake.Commands(19), Is.EqualTo(new[] { "double blink", "wink" }));
  }

  [Test]
  public void Test_handshake_11111_to_all_commands_reversed()
  {
    Assert.That(SecretHandshake.Commands(31), Is.EqualTo(new[] { "jump", "close your eyes", "double blink", "wink" }));
  }
}
