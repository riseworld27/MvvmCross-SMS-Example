using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.Specialized;

namespace ISMSPush
{
	public class RangeObservableCollection<T> : ObservableCollection<T>
	{
		public RangeObservableCollection () : base ()
		{
		}

		public RangeObservableCollection (IEnumerable<T> collection) : base (collection)
		{
		}

		public RangeObservableCollection (List<T> list) : base (list)
		{
		}

		public void AddRange (IEnumerable<T> range)
		{
			foreach (var item in range) {
				Items.Add (item);
			}

			this.OnPropertyChanged (new PropertyChangedEventArgs ("Count"));
			this.OnPropertyChanged (new PropertyChangedEventArgs ("Item[]"));
			this.OnCollectionChanged (new NotifyCollectionChangedEventArgs (NotifyCollectionChangedAction.Reset));
		}

		public void Reset (IEnumerable<T> range)
		{
			this.Items.Clear ();

			AddRange (range);
		}
	}
}

