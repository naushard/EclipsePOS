using System;
using System.Collections;

using EclipsePos.Apps.EJournal;

namespace EclipsePos.Apps.Operators
{
	/// <summary>
	/// Summary description for ItemList.
	/// </summary>
	public class ItemList:IList
	{
		private bool nextitem=false;
		private int itemIndex = -1;

		private object[] _contents = new object[10];
		private int _count;


		public ItemList(EjItem ejItem, Ej ej)
		{
			_count = 0;

			foreach( Object obj in ej.EjArrayList)
			{
				EjLine ejLine = obj as EjLine;
                if ((ejLine is EjItem) && ejLine.Equals(ejItem))
                {
                    if (nextitem) break;
                    nextitem = true;

                    this.Add(ejLine);
                    continue; // Get the next ejLine
                }

                // Ignore other EjItems in the array list
                if (!nextitem)
                {
                    continue;
                }

				if (ejLine is EjPromotion)
				{
					this.Add(ejLine);
				}

				if (ejLine is EjTax)
				{
					this.Add(ejLine);
				}

			}
		}
		#region IList Members

		public bool IsReadOnly
		{
			get
			{
				// TODO:  Add ItemList.IsReadOnly getter implementation
				return false;
			}
		}

		public object this[int index]
		{
			get
			{
				return _contents[index];
			}
			set
			{
				_contents[index] = value;
			}

		}

		public void RemoveAt(int index)
		{
			if ((index >= 0) && (index < Count))
			{
				for (int i = index; i < Count - 1; i++)
				{
					_contents[i] = _contents[i + 1];
				}
				_count--;
			}

		}

		public void Insert(int index, object value)
		{
			if ((_count + 1 <= _contents.Length) && (index < Count) && (index >= 0))
			{
				_count++;

				for (int i = Count - 1; i > index; i--)
				{
					_contents[i] = _contents[i - 1];
				}
				_contents[index] = value;
			}

		}

		public void Remove(object value)
		{
			RemoveAt(IndexOf(value));

		}

		public bool Contains(object value)
		{
			bool inList = false;
			for (int i = 0; i < Count; i++)
			{
				if (_contents[i] == value)
				{
					inList = true;
					break;
				}
			}
			return inList;

		}

		public void Clear()
		{
			_count = 0;

		}

		public int IndexOf(object value)
		{
			int itemIndex = -1;
			for (int i = 0; i < Count; i++)
			{
				if (_contents[i] == value)
				{
					itemIndex = i;
					break;
				}
			}
			return itemIndex;

		}

		public int Add(object value)
		{

			if (_count < _contents.Length)
			{
				_contents[_count] = value;
				_count++;

				return (_count - 1);
			}
			else
			{
				return -1;
			}

		}

		public bool IsFixedSize
		{
			get
			{
				return true;
			}
		}

		#endregion

		#region ICollection Members

		public bool IsSynchronized
		{
			get
			{
				return false;
			}
		}

		public int Count
		{
			get
			{
				return _count;

			}
		}

		public void CopyTo(Array array, int index)
		{
			int j = index;
			for (int i = 0; i < Count; i++)
			{
				array.SetValue(_contents[i], j);
				j++;
			}


		}

		public object SyncRoot
		{
			get
			{
				return this;
			}
		}

		#endregion

		#region IEnumerable Members

		public IEnumerator GetEnumerator()
		{
			// Refer to the IEnumerator documentation for an example of
			// implementing an enumerator.
			//throw new Exception("The method or operation is not implemented.");
			return null;
		}

		#endregion
	}
}
