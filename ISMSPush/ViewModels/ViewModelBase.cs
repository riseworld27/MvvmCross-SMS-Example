using Cirrious.MvvmCross.ViewModels;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ISMSPush
{
	public abstract class ViewModelBase : MvxViewModel
	{
		//		protected void Set<T> (Expression<Func<T>> propertyExpression, T field, T newValue)
		//		{
		//
		//		}

		protected bool Set<T> (string propertyName, ref T field, T newValue)
		{
			if (EqualityComparer<T>.Default.Equals (field, newValue)) {
				return false;
			}

			field = newValue;
			RaisePropertyChanged (propertyName);
			return true;
		}

		//		protected void Set<T> (T field, T newValue, string propertyName = null)
		//		{
		//
		//		}
		//
		//		protected void Set<T> (Expression<Func<T>> propertyExpression, T field, T newValue, bool broadcast)
		//		{
		//
		//		}
		//
		//		protected void Set<T> (string propertyName, T field, T newValue, bool broadcast)
		//		{
		//
		//		}
		//
		//		protected void Set<T> (T field, T newValue, bool broadcast, string propertyName)
		//		{
		//
		//		}
	}
}

