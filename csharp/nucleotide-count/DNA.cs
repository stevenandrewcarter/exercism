using System.Collections.Generic;

class InvalidNucleotideException : System.Exception
{

}

class DNA
{
  public DNA(string aSequence)
  {
    nucleotides = new Dictionary<char, int>();
    nucleotides.Add('A', 0);
    nucleotides.Add('T', 0);
    nucleotides.Add('C', 0);
    nucleotides.Add('G', 0);
    foreach (var n in aSequence)
    {
      nucleotides[n]++;
    }
  }

  public Dictionary<char, int> NucleotideCounts
  {
    get
    {
      return nucleotides;
    }
  }

  public int Count(char nucleotide)
  {
    if (nucleotide != 'A' && nucleotide != 'T' && nucleotide != 'C' && nucleotide != 'G')
      throw new InvalidNucleotideException();
    return nucleotides[nucleotide];
  }

  private Dictionary<char, int> nucleotides;
}