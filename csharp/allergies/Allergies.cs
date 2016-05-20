using System.Collections.Generic;

class Allergies
{
  private void AddAllergy(string allergy, ref int currentIndex, int index)
  {
    if (currentIndex >= index)
    {
      if (!AllergicTo(allergy))
        allergies.Add(allergy);
      while (currentIndex >= index)
        currentIndex -= index;
    }
  }

  public Allergies(int index)
  {
    allergies = new List<string>();
    AddAllergy("cats", ref index, 128);
    AddAllergy("pollen", ref index, 64);
    AddAllergy("chocolate", ref index, 32);
    AddAllergy("tomatoes", ref index, 16);
    AddAllergy("strawberries", ref index, 8);
    AddAllergy("shellfish", ref index, 4);
    AddAllergy("peanuts", ref index, 2);
    AddAllergy("eggs", ref index, 1);
  }

  public bool AllergicTo(string a_allergy)
  {
    return allergies.Exists(x => x == a_allergy);
  }

  public List<string> List()
  {
    var reverseList = allergies;
    reverseList.Reverse();
    return reverseList;
  }

  private List<string> allergies;
}