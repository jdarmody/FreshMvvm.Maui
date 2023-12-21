using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace FreshMvvm.Maui
{
    public class FreshNavigationContainer : NavigationPage, IFreshNavigationService
    {
        public FreshNavigationContainer (Page page) : base(page)
        {
            var pageModel = page.GetPageModel ();
            if (pageModel == null)
                throw new InvalidCastException("BindingContext was not a IFreshPageModel on this Page");

            pageModel.SetCurrentNavigationService (this);
        }

        internal Page CreateContainerPageSafe (Page page)
        {
            if (page is NavigationPage || page is FlyoutPage || page is TabbedPage)
                return page;

            return CreateContainerPage(page);
        }

        protected virtual Page CreateContainerPage (Page page)
        {
            return new NavigationPage (page);
        }

		public virtual Task PushPage (Page page, IFreshPageModel model, bool modal = false, bool animate = true)
        {
            if (modal)
                return Navigation.PushModalAsync (CreateContainerPageSafe (page), animate);
            return Navigation.PushAsync (page, animate);
        }

		public virtual Task PopPage (bool modal = false, bool animate = true)
        {
            if (modal)
                return Navigation.PopModalAsync (animate);
            return Navigation.PopAsync (animate);
        }

        public Task PopToRoot (bool animate = true)
        {
            return Navigation.PopToRootAsync (animate); 
        }

        public void NotifyChildrenPageWasPopped()
        {
            this.NotifyAllChildrenPopped();
        }

        public Task<IFreshPageModel> SwitchSelectedRootPageModel<T>() where T : class, IFreshPageModel
        {
            throw new Exception("This navigation container has no selected roots, just a single root");
        }
    }
}

