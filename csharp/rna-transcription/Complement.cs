using System.Text;

class Complement
{
  public static string OfDna(string dna)
  {
    var rna = new StringBuilder();
    foreach (var c in dna)
    {
      switch (c)
      {
        case 'C':
          rna.Append("G");
          break;
        case 'G':
          rna.Append("C");
          break;
        case 'T':
          rna.Append("A");
          break;
        case 'A':
          rna.Append("U");
          break;
      }
    }
    return rna.ToString();
  }
}