﻿using System;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace FreshMvvm.Maui
{
    /// <summary>
    /// This Tabbed navigation container for when you only want the tabs to appear on the first page and then push to a second page without tabs
    /// </summary>
    public class FreshTabbedFONavigationContainer : NavigationPage, IFreshNavigationService
    {
        TabbedPage _innerTabbedPage;
        public TabbedPage FirstTabbedPage { get { return _innerTabbedPage; } }
        List<Page> _tabs = new List<Page>();
        public IEnumerable<Page> TabbedPages { get { return _tabs; } }

        public FreshTabbedFONavigationContainer(string titleOfFirstTab) : base(new TabbedPage())
        {
            _innerTabbedPage = (TabbedPage)this.CurrentPage;
            _innerTabbedPage.Title = titleOfFirstTab;
        }

        public virtual Page AddTab<T> (string title, string icon, object data = null) where T : class, IFreshPageModel
        {
            var page = FreshPageModelResolver.ResolvePageModel<T> (data);
            page.GetPageModel ().SetCurrentNavigationService (this);
            _tabs.Add (page);
            var container = CreateContainerPageSafe (page);
            container.Title = title;
            if (!string.IsNullOrWhiteSpace(icon))
                container.IconImageSource = icon;
            _innerTabbedPage.Children.Add (container);
            return container;
        }

        internal Page CreateContainerPageSafe (Page page)
        {
            if (page is NavigationPage || page is FlyoutPage || page is TabbedPage)
                return page;

            return CreateContainerPage(page);
        }

        protected virtual Page CreateContainerPage (Page page)
        {
            return page;
        }

        public System.Threading.Tasks.Task PushPage (Page page, IFreshPageModel model, bool modal = false, bool animate = true)
        {
            if (modal)
                return this.Navigation.PushModalAsync (CreateContainerPageSafe (page));
            return this.Navigation.PushAsync (page);
        }

        public System.Threading.Tasks.Task PopPage (bool modal = false, bool animate = true)
        {
            if (modal)
                return this.Navigation.PopModalAsync (animate);
            return this.Navigation.PopAsync (animate);
        }

        public Task PopToRoot (bool animate = true)
        {
            return this.Navigation.PopToRootAsync (animate);
        }

        public string NavigationServiceName { get; private set; }

        public void NotifyChildrenPageWasPopped()
        {
            foreach (var page in _innerTabbedPage.Children)
            {
                if (page is NavigationPage)
                    ((NavigationPage)page).NotifyAllChildrenPopped();
            }
        }

        public Task<IFreshPageModel> SwitchSelectedRootPageModel<T>() where T : class, IFreshPageModel
        {
            if (this.CurrentPage == _innerTabbedPage)
            {
                var page = _tabs.FindIndex(o => o.GetPageModel().GetType().FullName == typeof(T).FullName);
                if (page > -1)
                {
                    _innerTabbedPage.CurrentPage = this._innerTabbedPage.Children[page];
                    return Task.FromResult(_innerTabbedPage.CurrentPage.GetPageModel());
                }
            }
            else
            {
                throw new Exception("Cannot switch tabs when the tab screen is not visible");
            }

            return null;
        }
    }
}

