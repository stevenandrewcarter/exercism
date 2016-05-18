using NUnit.Framework;
using System;
using System.Text;

class Cipher
{
  public Cipher()
  {
    var newKey = new StringBuilder();
    var random = new Random(Guid.NewGuid().GetHashCode());
    for (var i = 0; i < 100; i++)
    {
      newKey.Append((char)random.Next(97, 121));
    }
    Key = newKey.ToString();
  }

  public Cipher(string a_key)
  {
    if (a_key.Length == 0) throw new ArgumentException();
    foreach (var c in a_key)
    {
      if (char.IsUpper(c) || char.IsDigit(c))
      {
        throw new ArgumentException();
      }
    }
    Key = a_key;
  }

  public string Key { get; }

  public string Encode(string message)
  {
    var cipher = "";
    for (var i = 0; i < message.Length; i++)
    {
      var charIndex = ((message[i] - 97) + (Key[i] - 97));
      while (charIndex >= 26)
      {
        charIndex -= 26;
      }
      cipher += (char)(97 + Math.Abs(charIndex));
    }
    return cipher;
  }

  public string Decode(string cipher)
  {
    var message = "";
    for (var i = 0; i < cipher.Length; i++)
    {
      var charIndex = ((cipher[i] - 97) - (Key[i] - 97));
      while (charIndex < 0)
      {
        charIndex += 26;
      }
      message += (char)(97 + Math.Abs(charIndex));
    }
    return message;
  }
}

[TestFixture]
public class RandomKeyCipherTest
{
  private Cipher cipher;

  [SetUp]
  public void Setup()
  {
    cipher = new Cipher();
  }

  [Test]
  public void Cipher_key_is_made_of_letters()
  {
    Assert.That(cipher.Key, Is.StringMatching("[a-z]+"));
  }

  [Test]
  public void Default_cipher_key_is_100_characters()
  {
    Assert.That(cipher.Key, Has.Length.EqualTo(100));
  }

  [Test]
  public void Cipher_keys_are_randomly_generated()
  {
    Assert.That(cipher.Key, Is.Not.EqualTo(new Cipher().Key));
  }

  // Here we take advantage of the fact that plaintext of "aaa..." doesn't output
  // the key. This is a critical problem with shift ciphers, some characters
  // will always output the key verbatim.  
  [Test]
  public void Cipher_can_encode()
  {
    Assert.That(cipher.Encode("aaaaaaaaaa"), Is.EqualTo(cipher.Key.Substring(0, 10)));
  }

  [Test]
  public void Cipher_can_decode()
  {
    Assert.That(cipher.Decode(cipher.Key.Substring(0, 10)), Is.EqualTo("aaaaaaaaaa"));
  }

  [Test]
  public void Cipher_is_reversible()
  {
    const string PLAINTEXT = "abcdefghij";
    Assert.That(cipher.Decode(cipher.Encode(PLAINTEXT)), Is.EqualTo(PLAINTEXT));
  }
}

[TestFixture]
public class IncorrectKeyCipherTest
{
  [Test]
  public void Cipher_throws_with_an_all_caps_key()
  {
    Assert.That(() => new Cipher("ABCDEF"), Throws.ArgumentException);
  }

  [Test]
  public void Cipher_throws_with_any_caps_key()
  {
    Assert.That(() => new Cipher("abcdEFg"), Throws.ArgumentException);
  }

  [Test]
  public void Cipher_throws_with_numeric_key()
  {
    Assert.That(() => new Cipher("12345"), Throws.ArgumentException);
  }

  [Test]
  public void Cipher_throws_with_any_numeric_key()
  {
    Assert.That(() => new Cipher("abcd345ef"), Throws.ArgumentException);
  }

  [Test]
  public void Cipher_throws_with_empty_key()
  {
    Assert.That(() => new Cipher(""), Throws.ArgumentException);
  }
}

[TestFixture]
public class SubstitutionCipherTest
{
  private const string KEY = "abcdefghij";
  private Cipher cipher;

  [SetUp]
  public void Setup()
  {
    cipher = new Cipher(KEY);
  }

  [Test]
  public void Cipher_keeps_the_submitted_key()
  {
    Assert.That(cipher.Key, Is.EqualTo(KEY));
  }

  [Test]
  public void Cipher_can_encode_with_given_key()
  {
    Assert.That(cipher.Encode("aaaaaaaaaa"), Is.EqualTo("abcdefghij"));
  }

  [Test]
  public void Cipher_can_decode_with_given_key()
  {
    Assert.That(cipher.Decode("abcdefghij"), Is.EqualTo("aaaaaaaaaa"));
  }

  [Test]
  public void Cipher_is_reversible_given_key()
  {
    const string PLAINTEXT = "abcdefghij";
    Assert.That(cipher.Decode(cipher.Encode(PLAINTEXT)), Is.EqualTo(PLAINTEXT));
  }

  [Test]
  public void Cipher_can_double_shift_encode()
  {
    const string PLAINTEXT = "iamapandabear";
    Assert.That(new Cipher(PLAINTEXT).Encode(PLAINTEXT), Is.EqualTo("qayaeaagaciai"));
  }
  
  [Test]
  public void Cipher_can_wrap_encode()
  {
    Assert.That(cipher.Encode("zzzzzzzzzz"), Is.EqualTo("zabcdefghi"));
  }
  
  [Test]
  public void Cipher_can_encode_a_message_that_is_shorter_than_the_key()
  {
    Assert.That(cipher.Encode("aaaaa"), Is.EqualTo("abcde"));
  }
  
  [Test]
  public void Cipher_can_decode_a_message_that_is_shorter_than_the_key()
  {
    Assert.That(cipher.Decode("abcde"), Is.EqualTo("aaaaa"));
  }
}