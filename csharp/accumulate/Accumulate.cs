using System;
using System.Collections.Generic;
using System.Linq;

namespace Accumulate
{
  public static class ExtensionMethods
  {
    public static IEnumerable<T> Accumulate<T>(this IEnumerable<T> accumulate, Func<T, T> predicate)
    {
      return accumulate.Select(x => predicate(x));
    }
  }
}