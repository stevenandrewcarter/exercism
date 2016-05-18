using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

public enum Operation
{
  plus, minus, multiple, divide
}

public class WordNode
{
  public virtual int Calculate()
  {
    if (root == null)
      throw new System.ArgumentException();
    return root.Calculate();
  }

  public void Add(string aWords)
  {
    var words = aWords.Split(' ');        
    for (var i = 0; i < words.Length; i++)
    {
      var word = words[i];
      if (word.Contains("plus") || word.Contains("minus") || word.Contains("multiplied") || word.Contains("divided"))
      {
        if (root == null)
        {
          var leftNumber = ParseNumber(words[i - 1]);
          root = new WordNumber(leftNumber);
        }
        var rightWord = word.Contains("multiplied") || word.Contains("divided") ? i + 2 : i + 1;
        var rightNumber = ParseNumber(words[rightWord]);
        var rightWordNode = new WordNumber(rightNumber);
        var operation = new WordOperation(root, rightWordNode, word);
        root = operation;
      }
    }
  }

  private int ParseNumber(string word)
  {
    var result = 0;
    var number = "";
    foreach (var c in word)
    {
      if (char.IsDigit(c) || c == '-')
        number += c;      
    }
    if (number.Length > 0)    
      result = int.Parse(number);    
    return result;
  }

  private WordNode root;
}

public class WordNumber : WordNode
{
  public WordNumber(int aValue)
  {
    value = aValue;
  }

  public override int Calculate()
  {
    return value;
  }

  private int value;
}

public class WordOperation : WordNode
{
  public WordOperation(WordNode aLeft, WordNode aRight, string aOperation)
  {
    left = aLeft;
    right = aRight;    
    switch (aOperation)
    {
      case "plus":
        operation = Operation.plus;
        break;
      case "minus":
        operation = Operation.minus;
        break;
      case "multiplied":
        operation = Operation.multiple;
        break;
      case "divided":
        operation = Operation.divide;
        break;
    }
  }

  public override int Calculate()
  {
    var result = 0;
    switch (operation)
    {
      case Operation.plus:
        result = left.Calculate() + right.Calculate();
        break;
      case Operation.minus:
        result = left.Calculate() - right.Calculate();
        break;
      case Operation.multiple:
        result = left.Calculate() * right.Calculate();
        break;
      case Operation.divide:
        result = left.Calculate() / right.Calculate();
        break;
    }
    return result;
  }

  private Operation operation;
  private WordNode left;
  private WordNode right;
}

public class WordProblem
{  
  public static int Solve(string aWords)
  {
    var root = new WordNode();
    root.Add(aWords);
    return root.Calculate();
  }
}

[TestFixture]
public class WordProblemTest
{
  [Test]
  public void Can_parse_and_solve_addition_problems()
  {
    Assert.That(WordProblem.Solve("What is 1 plus 1?"), Is.EqualTo(2));
  }

  [Test]
  public void Can_add_double_digit_numbers()
  {
    Assert.That(WordProblem.Solve("What is 53 plus 2?"), Is.EqualTo(55));
  }

  [Test]
  public void Can_add_negative_numbers()
  {
    Assert.That(WordProblem.Solve("What is -1 plus -10?"), Is.EqualTo(-11));
  }

  [Test]
  public void Can_add_large_numbers()
  {
    Assert.That(WordProblem.Solve("What is 123 plus 45678?"), Is.EqualTo(45801));
  }

  [Test]
  public void Can_parse_and_solve_subtraction_problems()
  {
    Assert.That(WordProblem.Solve("What is 4 minus -12"), Is.EqualTo(16));
  }

  [Test]
  public void Can_parse_and_solve_multiplication_problems()
  {
    Assert.That(WordProblem.Solve("What is -3 multiplied by 25?"), Is.EqualTo(-75));
  }
  
  [Test]
  public void Can_parse_and_solve_division_problems()
  {
    Assert.That(WordProblem.Solve("What is 33 divided by -3?"), Is.EqualTo(-11));
  }
  
  [Test]
  public void Can_add_twice()
  {
    Assert.That(WordProblem.Solve("What is 1 plus 1 plus 1?"), Is.EqualTo(3));
  }
  
  [Test]
  public void Can_add_then_subtract()
  {
    Assert.That(WordProblem.Solve("What is 1 plus 5 minus -2?"), Is.EqualTo(8));
  }
  
  [Test]
  public void Can_subtract_twice()
  {
    Assert.That(WordProblem.Solve("What is 20 minus 4 minus 13?"), Is.EqualTo(3));
  }

  [Test]
  public void Can_subtract_then_add()
  {
    Assert.That(WordProblem.Solve("What is 17 minus 6 plus 3?"), Is.EqualTo(14));
  }
  
  [Test]
  public void Can_multiply_twice()
  {
    Assert.That(WordProblem.Solve("What is 2 multiplied by -2 multiplied by 3?"), Is.EqualTo(-12));
  }
  
  [Test]
  public void Can_add_then_multiply()
  {
    Assert.That(WordProblem.Solve("What is -3 plus 7 multiplied by -2?"), Is.EqualTo(-8));
  }
  
  [Test]
  public void Can_divide_twice()
  {
    Assert.That(WordProblem.Solve("What is -12 divided by 2 divided by -3?"), Is.EqualTo(2));
  }
  
  [Test]
  public void Cubed_is_too_advanced()
  {
    Assert.That(() => WordProblem.Solve("What is 53 cubed?"), Throws.ArgumentException);
  }

  [Test]
  public void Irrelevent_problems_are_not_valid()
  {
    Assert.That(() => WordProblem.Solve("Who is the president of the United States?"), Throws.ArgumentException);
  }
}