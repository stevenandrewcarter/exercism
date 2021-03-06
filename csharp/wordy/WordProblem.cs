﻿public enum Operation
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