using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Crypto
{
  public Crypto(string message)
  {
    var charArray = message.ToCharArray();
    NormalizePlaintext = new string(charArray.Where(c => char.IsLetterOrDigit(c)).ToArray());
    NormalizePlaintext = NormalizePlaintext.ToLower();
  }

  public string NormalizePlaintext { get; }
  public int Size
  {
    get
    {
      var square = Math.Sqrt(NormalizePlaintext.Length);
      return square % 1 == 0 ? (int)square : (int)square + 1;
    }
  }

  public string[] PlaintextSegments()
  {
    var segments = new List<string>();
    var segment = "";
    var count = 0;
    for (var i = 0; i < NormalizePlaintext.Length; i++)
    {
      segment += NormalizePlaintext[i];
      count++;
      if (count == Size)
      {
        segments.Add(segment);
        segment = "";
        count = 0;
      }
    }
    if (count > 0)
    {
      segments.Add(segment);
      segment = "";
      count = 0;
    }
    return segments.ToArray();
  }

  public string Ciphertext()
  {
    var ciperText = new StringBuilder();
    var segments = PlaintextSegments();
    for (var i = 0; i < Size; i++)
    {
      for (var j = 0; j < segments.Length; j++)
      {
        if (i < segments[j].Length)
          ciperText.Append(segments[j][i]);
      }
    }
    return ciperText.ToString();
  }

  public string NormalizeCiphertext()
  {
    var ciperSegments = new List<string>();
    var segments = PlaintextSegments();
    for (var i = 0; i < Size; i++)
    {
      var ciperSegment = "";
      for (var j = 0; j < segments.Length; j++)
      {
        if (i < segments[j].Length)
          ciperSegment += segments[j][i];
      }
      ciperSegments.Add(ciperSegment);
    }
    return string.Join(" ", ciperSegments.ToArray());
  }
}