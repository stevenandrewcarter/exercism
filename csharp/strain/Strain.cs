using System;
using System.Collections.Generic;
using System.Linq;

namespace Strain
{
  public static class ExtensionMethods
  {
    public static IEnumerable<T> Keep<T>(this IEnumerable<T> strain, Func<T, bool> predicate)
    {
      return strain.Where(x => predicate(x));
    }

    public static IEnumerable<T> Discard<T>(this IEnumerable<T> strain, Func<T, bool> predicate)
    {
      return strain.Where(x => !predicate(x));
    }
  }
}