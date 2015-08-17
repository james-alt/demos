using System;
using Xamarin.Forms;
using Autofac;

namespace SQLSaturday
{
	public class TabbedViewPage<T> : TabbedPage where T:IViewModel
	{
		readonly T _viewModel;
		public T ViewModel { get { return _viewModel; } }

		public TabbedViewPage ()
		{
			using (var scope = AppContainer.Container.BeginLifetimeScope ()) {
				_viewModel = AppContainer.Container.Resolve<T> ();
			}
			BindingContext = _viewModel;
		}
	}
}

