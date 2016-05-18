using NUnit.Framework;

class Raindrops
{
  public static string Convert(int number)
  {
    var result = "";
    if (number % 3 == 0)
    {
      result += "Pling";
    }
    if (number % 5 == 0)
    {
      result += "Plang";
    }
    if (number % 7 == 0)
    {
      result += "Plong";
    }
    if (result == string.Empty)
    {
      result = number.ToString();
    }
    return result;
  }
}

[TestFixture]
public class RaindropsTest
{
    [TestCase(1, ExpectedResult = "1")]
    [TestCase(52, ExpectedResult = "52")]
    [TestCase(12121, ExpectedResult = "12121")]
    public string Non_primes_pass_through(int number)
    {
        return Raindrops.Convert(number);
    }
    
    [TestCase(3)]
    [TestCase(6)]
    [TestCase(9)]
    public void Numbers_containing_3_as_a_prime_factor_give_pling(int number)
    {
        Assert.That(Raindrops.Convert(number), Is.EqualTo("Pling"));
    }

    [TestCase(5)]
    [TestCase(10)]
    [TestCase(25)]
    public void Numbers_containing_5_as_a_prime_factor_give_plang(int number)
    {
        Assert.That(Raindrops.Convert(number), Is.EqualTo("Plang"));
    }
    
    [TestCase(7)]
    [TestCase(14)]
    [TestCase(49)]
    public void Numbers_containing_7_as_a_prime_factor_give_plong(int number)
    {
        Assert.That(Raindrops.Convert(number), Is.EqualTo("Plong"));
    }
  
    [TestCase(15, ExpectedResult = "PlingPlang")]
    [TestCase(21, ExpectedResult = "PlingPlong")]
    [TestCase(35, ExpectedResult = "PlangPlong")]
    [TestCase(105, ExpectedResult = "PlingPlangPlong")]
    public string Numbers_containing_multiple_prime_factors_give_all_results_concatenated(int number)
    {
        return Raindrops.Convert(number);
    }
}