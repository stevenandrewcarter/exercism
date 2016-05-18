using NUnit.Framework;

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

[TestFixture]
public class DequeTest
{
  private Deque<int> deque;

  [SetUp]
  public void Setup()
  {
    deque = new Deque<int>();
  }

  [Test]
  public void Push_and_pop_are_first_in_last_out_order()
  {
    deque.Push(10);
    deque.Push(20);
    Assert.That(deque.Pop(), Is.EqualTo(20));
    Assert.That(deque.Pop(), Is.EqualTo(10));
  }
  
  [Test]
  public void Push_and_shift_are_first_in_first_out_order()
  {
    deque.Push(10);
    deque.Push(20);
    Assert.That(deque.Shift(), Is.EqualTo(10));
    Assert.That(deque.Shift(), Is.EqualTo(20));
  }
  
  [Test]
  public void Unshift_and_shift_are_last_in_first_out_order()
  {
    deque.Unshift(10);
    deque.Unshift(20);
    Assert.That(deque.Shift(), Is.EqualTo(20));
    Assert.That(deque.Shift(), Is.EqualTo(10));
  }
  
  [Test]
  public void Unshift_and_pop_are_last_in_last_out_order()
  {
    deque.Unshift(10);
    deque.Unshift(20);
    Assert.That(deque.Pop(), Is.EqualTo(10));
    Assert.That(deque.Pop(), Is.EqualTo(20));
  }
  
  [Test]
  public void Push_and_pop_can_handle_multiple_values()
  {
    deque.Push(10);
    deque.Push(20);
    deque.Push(30);
    Assert.That(deque.Pop(), Is.EqualTo(30));
    Assert.That(deque.Pop(), Is.EqualTo(20));
    Assert.That(deque.Pop(), Is.EqualTo(10));
  }
  
  [Test]
  public void Unshift_and_shift_can_handle_multiple_values()
  {
    deque.Unshift(10);
    deque.Unshift(20);
    deque.Unshift(30);
    Assert.That(deque.Shift(), Is.EqualTo(30));
    Assert.That(deque.Shift(), Is.EqualTo(20));
    Assert.That(deque.Shift(), Is.EqualTo(10));
  }

  [Test]
  public void All_methods_of_manipulating_the_deque_can_be_used_together()
  {
    deque.Push(10);
    deque.Push(20);
    Assert.That(deque.Pop(), Is.EqualTo(20));

    deque.Push(30);
    Assert.That(deque.Shift(), Is.EqualTo(10));

    deque.Unshift(40);
    deque.Push(50);
    Assert.That(deque.Shift(), Is.EqualTo(40));
    Assert.That(deque.Pop(), Is.EqualTo(50));
    Assert.That(deque.Shift(), Is.EqualTo(30));
  }
}