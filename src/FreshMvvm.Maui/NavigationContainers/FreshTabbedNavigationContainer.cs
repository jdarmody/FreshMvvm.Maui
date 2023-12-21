﻿using System;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace FreshMvvm.Maui
{
    public class FreshTabbedNavigationContainer : TabbedPage, IFreshNavigationService
    {
        List<Page> _tabs = new List<Page>();
        public IEnumerable<Page> TabbedPages { get { return _tabs; } }

        public virtual Page AddTab<T> (string title, string icon, object data = null) where T : class, IFreshPageModel
        {
            var page = FreshPageModelResolver.ResolvePageModel<T> (data);
            page.GetPageModel ().SetCurrentNavigationService (this);
            _tabs.Add (page);
            var navigationContainer = CreateContainerPageSafe (page);
            navigationContainer.Title = title;
            if (!string.IsNullOrWhiteSpace(icon))
                navigationContainer.IconImageSource = icon;
            Children.Add (navigationContainer);
            return navigationContainer;
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

		public System.Threading.Tasks.Task PushPage (Page page, IFreshPageModel model, bool modal = false, bool animate = true)
        {
            if (modal)
                return this.CurrentPage.Navigation.PushModalAsync (CreateContainerPageSafe (page));
            return this.CurrentPage.Navigation.PushAsync (page);
        }

		public System.Threading.Tasks.Task PopPage (bool modal = false, bool animate = true)
        {
            if (modal)
                return this.CurrentPage.Navigation.PopModalAsync (animate);
            return this.CurrentPage.Navigation.PopAsync (animate);
        }

        public Task PopToRoot (bool animate = true)
        {
            return this.CurrentPage.Navigation.PopToRootAsync (animate);
        }

        public string NavigationServiceName { get; private set; }

        public void NotifyChildrenPageWasPopped()
        {
            foreach (var page in this.Children)
            {
                if (page is NavigationPage)
                    ((NavigationPage)page).NotifyAllChildrenPopped();
            }
        }
            
        public Task<IFreshPageModel> SwitchSelectedRootPageModel<T>() where T : class, IFreshPageModel
        {
            var page = _tabs.FindIndex(o => o.GetPageModel().GetType().FullName == typeof(T).FullName);

            if (page > -1)
            {
                CurrentPage = this.Children[page];
                var topOfStack = CurrentPage.Navigation.NavigationStack.LastOrDefault();
                if (topOfStack != null)
                    return Task.FromResult(topOfStack.GetPageModel());

            }
            return null;
        }
    }
}

