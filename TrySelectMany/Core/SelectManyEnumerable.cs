using System;
using System.Linq;
using System.Collections.Generic;

namespace TrySelectMany {
	public static class SelectManyEnumerable {
		public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source,
														  Func<TSource, bool> predicate) {
			return Where(source, (x, _) => predicate(x));
		}
		public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source,
														  Func<TSource, int, bool> predicate) {

			return source.SelectMany((x, i) => predicate(x, i) ? new[] { x } : new TSource[] { });
		}

	}
}

