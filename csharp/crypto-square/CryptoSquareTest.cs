using NUnit.Framework;
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

[TestFixture]
public class CryptoSquareTest
{
  [Test]
  public void Strange_characters_are_stripped_during_normalization()
  {
    var crypto = new Crypto("s#$%^&plunk");
    Assert.That(crypto.NormalizePlaintext, Is.EqualTo("splunk"));
  }

  [Test]
  public void Letters_are_lowercased_during_normalization()
  {
    var crypto = new Crypto("WHOA HEY!");
    Assert.That(crypto.NormalizePlaintext, Is.EqualTo("whoahey"));
  }

  [Test]
  public void Numbers_are_kept_during_normalization()
  {
    var crypto = new Crypto("1, 2, 3, GO!");
    Assert.That(crypto.NormalizePlaintext, Is.EqualTo("123go"));
  }

  [Test]
  public void Smallest_square_size_is_2()
  {
    var crypto = new Crypto("1234");
    Assert.That(crypto.Size, Is.EqualTo(2));
  }

  [Test]
  public void Size_of_text_whose_length_is_a_perfect_square_is_its_square_root()
  {
    var crypto = new Crypto("123456789");
    Assert.That(crypto.Size, Is.EqualTo(3));
  }

  [Test]
  public void Size_of_text_whose_length_is_not_a_perfect_square_is_next_biggest_square_root()
  {
    var crypto = new Crypto("123456789abc");
    Assert.That(crypto.Size, Is.EqualTo(4));
  }

  [Test]
  public void Size_is_determined_by_normalized_text()
  {
    var crypto = new Crypto("Oh hey, this is nuts!");
    Assert.That(crypto.Size, Is.EqualTo(4));
  }

  [Test]
  public void Segments_are_split_by_square_size()
  {
    var crypto = new Crypto("Never vex thine heart with idle woes");
    Assert.That(crypto.PlaintextSegments(), Is.EqualTo(new[] { "neverv", "exthin", "eheart", "withid", "lewoes" }));
  }

  [Test]
  public void Segments_are_split_by_square_size_until_text_runs_out()
  {
    var crypto = new Crypto("ZOMG! ZOMBIES!!!");
    Assert.That(crypto.PlaintextSegments(), Is.EqualTo(new[] { "zomg", "zomb", "ies" }));
  }

  [Test]
  public void Ciphertext_combines_text_by_column()
  {
    var crypto = new Crypto("First, solve the problem. Then, write the code.");
    Assert.That(crypto.Ciphertext(), Is.EqualTo("foeewhilpmrervrticseohtottbeedshlnte"));
  }

  [Test]
  public void Ciphertext_skips_cells_with_no_text()
  {
    var crypto = new Crypto("Time is an illusion. Lunchtime doubly so.");
    Assert.That(crypto.Ciphertext(), Is.EqualTo("tasneyinicdsmiohooelntuillibsuuml"));
  }
  
  [Test]
  public void Normalized_ciphertext_is_split_by_height_of_square()
  {
    var crypto = new Crypto("Vampires are people too!");
    Assert.That(crypto.NormalizeCiphertext(), Is.EqualTo("vrel aepe mset paoo irpo"));
  }

  [Test]
  public void Normalized_ciphertext_not_exactly_divisible_by_5_spills_into_a_smaller_segment()
  {
    var crypto = new Crypto("Madness, and then illumination.");
    Assert.That(crypto.NormalizeCiphertext(), Is.EqualTo("msemo aanin dnin ndla etlt shui"));
  }
  
  [Test]
  public void Normalized_ciphertext_is_split_into_segements_of_correct_size()
  {
    var crypto = new Crypto("If man was meant to stay on the ground god would have given us roots");
    Assert.That(crypto.NormalizeCiphertext(), Is.EqualTo("imtgdvs fearwer mayoogo anouuio ntnnlvt wttddes aohghn sseoau"));
  }
  
  [Test]
  public void Normalized_ciphertext_is_split_into_segements_of_correct_size_with_punctuation()
  {
    var crypto = new Crypto("Have a nice day. Feed the dog & chill out!");
    Assert.That(crypto.NormalizeCiphertext(), Is.EqualTo("hifei acedl veeol eddgo aatcu nyhht"));
  }

  [Test]
  public void Normalized_ciphertext_is_split_into_segements_of_correct_size_when_just_less_than_full_square()
  {
    var crypto = new Crypto("I am");
    Assert.That(crypto.NormalizeCiphertext(), Is.EqualTo("im a"));
  }
}