
class Node<T>
{
  public Node()
  {
    Previous = null;
    Next = null;
  }

  public Node(T value) : this()
  {
    Value = value;
  }

  public Node<T> Previous { get; set; }
  public Node<T> Next { get; set; }
  public T Value { get; set; }
}

class Deque<T>
{
  public Deque()
  {
    begin = new Node<T>();
    end = new Node<T>();
    begin.Next = end;
    end.Previous = begin;
  }

  public void Push(T value)
  {
    var node = new Node<T>(value);
    var previous = end.Previous;
    previous.Next = node;
    node.Previous = previous;
    node.Next = end;
    end.Previous = node;
  }

  public T Pop()
  {
    var node = end.Previous;
    end.Previous = node.Previous;
    node.Previous.Next = end;
    return node.Value;
  }

  public T Shift()
  {
    var next = begin.Next;
    next.Next.Previous = begin;
    begin.Next = next.Next;
    return next.Value;
  }

  public void Unshift(T value)
  {
    var node = new Node<T>(value);
    var next = begin.Next;
    next.Previous = node;
    begin.Next = node;
    node.Previous = begin;
    node.Next = next;
  }

  private Node<T> begin;
  private Node<T> end;
}