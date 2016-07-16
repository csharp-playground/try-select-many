using System;
using System.Linq;
using FluentAssertions;

namespace TrySelectMany.Tests {
	public class SelectManyEnumerableTests : TestBase {

		public void Where() {
			var data = GetData();
			var expected = Enumerable.Where(data, x => (x % 2) == 0);
			var current = SelectManyEnumerable.Where(data, x => (x % 2) == 0);

			current.Should().Equal(expected);
		}
	}
}

