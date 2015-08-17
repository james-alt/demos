using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace SQLSaturday.Data
{
	public class Grouping<K, T> : ObservableCollection<T>
	{
		public K Key { get; private set; }
		public IEnumerable<T> GroupedItems {
			get {
				return Items;
			}
		}

		public Grouping (K key, IEnumerable<T> items)
		{
			Key = key;
			foreach (var item in items) {
				Items.Add (item);
			}
		}
	}
}

