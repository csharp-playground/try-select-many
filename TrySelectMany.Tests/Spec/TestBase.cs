using System.Linq;

namespace TrySelectMany.Tests {
	public class TestBase {
		protected static int[] GetData(int count = 128) {
			return Enumerable.Range(1, count).ToArray();
		}
	}
}

