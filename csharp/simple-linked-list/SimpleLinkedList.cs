using System.Collections;
using System.Collections.Generic;

class SimpleLinkedList<T> : IEnumerable<T>
{
  public SimpleLinkedList(T[] values)
  {
    Value = values[0];
    var nextNode = this;    
    for (var i = 1; i < values.Length; i++)
    {
      nextNode.Next = new SimpleLinkedList<T>(values[i]);
      nextNode = nextNode.Next;
    }
  }

  public SimpleLinkedList(IEnumerable<T> values)
  {
    var list = new List<T>();    
    foreach (var i in values)
    {
      list.Add(i);
    }
    Value = list[0];
    var nextNode = this;
    for (var i = 1; i < list.Count; i++)
    {
      nextNode.Next = new SimpleLinkedList<T>(list[i]);
      nextNode = nextNode.Next;
    }    
  }

  public SimpleLinkedList(T value)
  {
    Value = value;
    Next = null;
  }

  public SimpleLinkedList<T> Add(T newValue)
  {
    Next = new SimpleLinkedList<T>(newValue);
    return this;
  }

  public SimpleLinkedList<T> Reverse()
  {
    var reverseNode = new SimpleLinkedList<T>(Value);
    var cheat = new List<T>();
    cheat.Add(Value);
    var nextNode = Next;
    while (nextNode != null)
    {
      cheat.Add(nextNode.Value);
      nextNode = nextNode.Next;      
    }
    cheat.Reverse();
    return new SimpleLinkedList<T>(cheat.ToArray());
  }

  IEnumerator IEnumerable.GetEnumerator()
  {
    return new LinkedListEnumerator<T>(this);
  }

  public IEnumerator<T> GetEnumerator()
  {
    return new LinkedListEnumerator<T>(this);
  }

  public T Value { get; set; }
  public SimpleLinkedList<T> Next { get; set; }
}

class LinkedListEnumerator<T> : IEnumerator<T>
{
  public LinkedListEnumerator(SimpleLinkedList<T> startNode)
  {
    StartNode = startNode;
    Node = null;
  }

  public bool MoveNext()
  {
    if (Node == null)
    {
      Node = StartNode;
      return true;
    }
    if (Node.Next != null)
    {
      Node = Node.Next;
      return true;
    }
    return false;
  }

  public void Reset()
  {
    Node = null;
  }

  public void Dispose()
  {
    
  }

  public SimpleLinkedList<T> StartNode { get; set; }
  public SimpleLinkedList<T> Node { get; set; }

  T IEnumerator<T>.Current
  {
    get
    {
      return Node.Value;
    }
  }

  public object Current
  {
    get
    {
      return Node.Value;
    }
  }
}
