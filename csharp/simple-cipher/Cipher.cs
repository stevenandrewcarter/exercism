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