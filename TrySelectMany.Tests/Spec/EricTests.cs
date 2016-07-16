using System;
using System.Linq;
using System.Collections.Generic;
using FluentAssertions;

namespace TrySelectMany.Tests {

	public class SubItem {
		public string SubItemName { set; get; }
	}

	public class Item {
		public string ItemName { set; get; }
		public List<SubItem> SubItems { set; get; } = new List<SubItem>();
	}

	public class EricTests {

		private IEnumerable<Item> CreatItems() {

			var item = new Item();
			item.ItemName = "Item1";
			item.SubItems.Add(new SubItem { SubItemName = "SubItem1" });
			item.SubItems.Add(new SubItem { SubItemName = "SubItem2" });

			var items = new List<Item> { item, item, item };
			return items;
		}

		public void WhenYouSay() {
			var query =
				from item in CreatItems()
				from inner in item.SubItems
				select item.ItemName + inner.SubItemName;
			query.Count().Should().Be(6);
		}
	}

	// No idea
}

