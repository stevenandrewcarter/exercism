using NUnit.Framework;
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

[TestFixture]
public class ComplementTest
{
  [Test]
  public void Rna_complement_of_cytosine_is_guanine()
  {
    Assert.That(Complement.OfDna("C"), Is.EqualTo("G"));
  }
  
  [Test]
  public void Rna_complement_of_guanine_is_cytosine()
  {
    Assert.That(Complement.OfDna("G"), Is.EqualTo("C"));
  }
  
  [Test]
  public void Rna_complement_of_thymine_is_adenine()
  {
    Assert.That(Complement.OfDna("T"), Is.EqualTo("A"));
  }

  [Test]
  public void Rna_complement_of_adenine_is_uracil()
  {
    Assert.That(Complement.OfDna("A"), Is.EqualTo("U"));
  }

  [Test]
  public void Rna_complement()
  {
    Assert.That(Complement.OfDna("ACGTGGTCTTAA"), Is.EqualTo("UGCACCAGAAUU"));
  }
}