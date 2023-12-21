using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using FreshMvvm.Maui;

namespace FreshMvvm.Tests.Mocks
{
    class MockPageModelCoreMethods : IPageModelCoreMethods
	{
        public void SwitchOutRootNavigation(string navigationServiceName)
        {
            throw new NotImplementedException();
        }

		public void BatchBegin()
		{
			throw new NotImplementedException();
		}

		public void BatchCommit()
		{
			throw new NotImplementedException();
		}

	    public Task PushPageModel<T>(Action<T> setPageModel, bool modal = false, bool animate = true) where T : class, IFreshPageModel
	    {
	        throw new NotImplementedException();
	    }

	    public Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons)
		{
			throw new NotImplementedException();
		}

		public Task DisplayAlert(string title, string message, string cancel)
		{
			throw new NotImplementedException();
		}

		public Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
		{
			throw new NotImplementedException();
		}

        public Task PushPageModel<T, TPage>(object data, bool modal = false) where T : class, IFreshPageModel where TPage : Page
        {
            throw new NotImplementedException();
        }

        public Task PushPageModel<T, TPage>() where T : IFreshPageModel where TPage : Page
        {
            throw new NotImplementedException();
        }

        public Task PushNewNavigationServiceModal(FreshTabbedNavigationContainer tabbedNavigationContainer, IFreshPageModel basePageModel = null)
        {
            throw new NotImplementedException();
        }

        public Task PushNewNavigationServiceModal(FreshMasterDetailNavigationContainer masterDetailContainer, IFreshPageModel basePageModel = null)
        {
            throw new NotImplementedException();
        }

		public Task PopPageModel(bool modal = false)
		{
			throw new NotImplementedException();
		}

		public Task PopPageModel(object data, bool modal = false)
		{
			throw new NotImplementedException();
		}

		public Task PopToRoot(bool animate)
		{
			throw new NotImplementedException();
		}

		public Task PushPageModel(Type pageModelType)
		{
			throw new NotImplementedException();
		}

		public Task PushPageModel(Type pageModelType, object data, bool modal = false)
		{
			throw new NotImplementedException();
		}

		public Task PushPageModel<T>() where T : IFreshPageModel
		{
			throw new NotImplementedException();
		}

		public Task PushPageModel<T>(object data, bool modal = false) where T : IFreshPageModel
		{
			throw new NotImplementedException();
		}

        public Task PushNewNavigationServiceModal (IFreshNavigationService newNavigationService, IFreshPageModel[] basePageModels)
        {
            throw new NotImplementedException ();
        }

        public Task PopModalNavigationService ()
        {
            throw new NotImplementedException ();
        }

        public Task PushNewNavigationServiceModal (FreshTabbedNavigationContainer tabbedNavigationContainer)
        {
            throw new NotImplementedException ();
        }

        public Task PushNewNavigationServiceModal (FreshMasterDetailNavigationContainer masterDetailContainer)
        {
            throw new NotImplementedException ();
        }

        public Task PushNewNavigationServiceModal (IFreshNavigationService newNavigationService, IFreshPageModel basePageModels)
        {
            throw new NotImplementedException ();
        }

        public Task PushPageModel<T>(object data, bool modal = false, bool animate = true) where T : class, IFreshPageModel
        {
            throw new NotImplementedException();
        }

        public Task PushPageModel<T, TPage>(object data, bool modal = false, bool animate = true)
            where T : class, IFreshPageModel
            where TPage : Page
        {
            throw new NotImplementedException();
        }

        public Task PopPageModel(bool modal = false, bool animate = true)
        {
            throw new NotImplementedException();
        }

        public Task PopPageModel(object data, bool modal = false, bool animate = true)
        {
            throw new NotImplementedException();
        }

        public Task PushPageModel<T>(bool animate = true) where T : class, IFreshPageModel
        {
            throw new NotImplementedException();
        }

        public Task PushPageModel<T, TPage>(bool animate = true)
            where T : class, IFreshPageModel
            where TPage : Page
        {
            throw new NotImplementedException();
        }

        public Task PushPageModel(Type pageModelType, bool animate = true)
        {
            throw new NotImplementedException();
        }

        public void RemoveFromNavigation()
        {
            throw new NotImplementedException();
        }

        public void RemoveFromNavigation<TPageModel>(bool removeAll = false) where TPageModel : class, IFreshPageModel
        {
            throw new NotImplementedException();
        }

        public Task<string> PushPageModelWithNewNavigation<T>(object data, bool animate = true) where T : IFreshPageModel
        {
            throw new NotImplementedException();
        }

        public Task PushNewNavigationServiceModal(IFreshNavigationService newNavigationService, IFreshPageModel[] basePageModels, bool animate = true)
        {
            throw new NotImplementedException();
        }

        public Task PushNewNavigationServiceModal(FreshTabbedNavigationContainer tabbedNavigationContainer, IFreshPageModel basePageModel = null, bool animate = true)
        {
            throw new NotImplementedException();
        }

        public Task PushNewNavigationServiceModal(FreshMasterDetailNavigationContainer masterDetailContainer, IFreshPageModel basePageModel = null, bool animate = true)
        {
            throw new NotImplementedException();
        }

        public Task PushNewNavigationServiceModal(IFreshNavigationService newNavigationService, IFreshPageModel basePageModels, bool animate = true)
        {
            throw new NotImplementedException();
        }

        public Task PopModalNavigationService(bool animate = true)
        {
            throw new NotImplementedException();
        }

        public Task<IFreshPageModel> SwitchSelectedRootPageModel<T>() where T : class, IFreshPageModel
        {
            throw new NotImplementedException();
        }

        public Task<IFreshPageModel> SwitchSelectedTab<T>() where T : class, IFreshPageModel
        {
            throw new NotImplementedException();
        }

        public Task<IFreshPageModel> SwitchSelectedMaster<T>() where T : class, IFreshPageModel
        {
            throw new NotImplementedException();
        }

        public Task PushPageModel(Type pageModelType, object data, bool modal = false, bool animate = true)
        {
            //TODO
            throw new NotImplementedException();
        }

        public void RemoveFromNavigation(Type type, bool removeAll = false)
        {
            //TODO
            throw new NotImplementedException();
        }

        Task<FreshNavigationContainer> IPageModelCoreMethods.PushPageModelWithNewNavigation<T>(object data, bool animate)
        {
            throw new NotImplementedException();
        }
    }
}
