using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace TrySelectMany.Tests {

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
	public class SelectManyEnumerableTests : TestBase {

		[Test]
		public void Where() {
			var data = GetData();
			var expected = Enumerable.Where(data, x => (x % 2) == 0);
			var current = SelectManyEnumerable.Where(data, x => (x % 2) == 0);
			current.Should().Equal(expected);
		}
	}
}

