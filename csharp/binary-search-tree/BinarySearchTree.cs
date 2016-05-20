using System;
using System.Collections.Generic;
using System.Linq;

class BinarySearchTree
{
  public BinarySearchTree(int value)
  {
    Left = null;
    Right = null;
    Value = value;
  }

  public BinarySearchTree(int[] tree)
  {
    Value = tree[0];
    for (var i = 1; i < tree.Length; i++)
    {
      Add(tree[i]);
    }
  }

  public BinarySearchTree Add(int value)
  {
    if (value <= Value)
    {
      if (Left == null)
      {
        Left = new BinarySearchTree(value);
      }
      else
      {
        Left.Add(value);
      }
      return this;
    }
    if (value > Value)
    {
      if (Right == null)
      {
        Right = new BinarySearchTree(value);
      }
      else
      {
        Right.Add(value);
      }
      return this;
    }
    return null;
  }

  public BinarySearchTree Left { get; private set; }
  public BinarySearchTree Right { get; private set; }
  public int Value { get; set; }

  internal object AsEnumerable()
  {
    var result = new List<int>();    
    if (Left != null)
    {
      var node = new List<int>((int[])Left.AsEnumerable());
      result = result.Concat(node).ToList();
    }
    result.Add(Value);
    if (Right != null)
    {
      var node = new List<int>((int[])Right.AsEnumerable());
      result = result.Concat(node).ToList();
    }
    return result.ToArray();
  }
}
