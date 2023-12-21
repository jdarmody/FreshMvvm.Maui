using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace FreshMvvm.Maui
{
    public interface IPageModelCoreMethods
    {
        Task DisplayAlert (string title, string message, string cancel);

        Task<string> DisplayActionSheet (string title, string cancel, string destruction, params string[] buttons);

        Task<bool> DisplayAlert (string title, string message, string accept, string cancel);

        Task PushPageModel<T> (object data, bool modal = false, bool animate = true) where T : class, IFreshPageModel;

        Task PushPageModel<T, TPage> (object data, bool modal = false, bool animate = true) where T : class, IFreshPageModel where TPage : Page;

        Task PopPageModel (bool modal = false, bool animate = true);

        Task PopPageModel (object data, bool modal = false, bool animate = true);

        Task PushPageModel<T> (bool animate = true) where T : class, IFreshPageModel;

        Task PushPageModel<T, TPage> (bool animate = true) where T : class, IFreshPageModel where TPage : Page;

        Task PushPageModel (Type pageModelType, bool animate = true);

        Task PushPageModel (Type pageModelType, object data, bool modal = false, bool animate = true);

        /// <summary>
        /// Removes current page/pagemodel from navigation
        /// </summary>
        void RemoveFromNavigation ();

        /// <summary>
        /// Removes specific page/pagemodel from navigation
        /// </summary>
        /// <param name="removeAll">Will remove all, otherwise it will just remove first on from the top of the stack</param>
        /// <typeparam name="TPageModel">The 1st type parameter.</typeparam>
        void RemoveFromNavigation<TPageModel> (bool removeAll = false) where TPageModel : class, IFreshPageModel;

        /// <summary>
        /// Removes specific page/pagemodel from navigation
        /// </summary>
        /// <param name="removeAll">Will remove all, otherwise it will just remove first on from the top of the stack</param>
        /// <param name="type">The 1st type parameter</param>
        void RemoveFromNavigation (Type type, bool removeAll = false);

        /// <summary>
        /// This method pushes a new PageModel modally with a new NavigationContainer
        /// </summary>
        /// <returns>Returns the name of the new service</returns>
        Task<FreshNavigationContainer> PushPageModelWithNewNavigation<T> (object data, bool animate = true) where T : class, IFreshPageModel;

        Task PushNewNavigationServiceModal (IFreshNavigationService newNavigationService, IFreshPageModel[] basePageModels, bool animate = true);

        Task PushNewNavigationServiceModal (FreshTabbedNavigationContainer tabbedNavigationContainer, IFreshPageModel basePageModel = null, bool animate = true);

        Task PushNewNavigationServiceModal (FreshMasterDetailNavigationContainer masterDetailContainer, IFreshPageModel basePageModel = null, bool animate = true);

        Task PushNewNavigationServiceModal (IFreshNavigationService newNavigationService, IFreshPageModel basePageModels, bool animate = true);

        Task PopModalNavigationService(bool animate = true);

        void SwitchOutRootNavigation(string navigationServiceName);

        /// <summary>
        /// This method switches the selected main page, TabbedPage the selected tab or if MasterDetail, works with custom pages also
        /// </summary>
        /// <returns>The BagePageModel, allows you to PopToRoot, Pass Data</returns>
        /// <param name="newSelected">The pagemodel of the root you want to change</param>
        Task<IFreshPageModel> SwitchSelectedRootPageModel<T>() where T : class, IFreshPageModel;

        /// <summary>
        /// This method is used when you want to switch the selected page, 
        /// </summary>
        /// <returns>The BagePageModel, allows you to PopToRoot, Pass Data</returns>
        /// <param name="newSelectedTab">The pagemodel of the root you want to change</param>
        Task<IFreshPageModel> SwitchSelectedTab<T>() where T : class, IFreshPageModel;

        /// <summary>
        /// This method is used when you want to switch the selected page, 
        /// </summary>
        /// <returns>The BagePageModel, allows you to PopToRoot, Pass Data</returns>
        /// <param name="newSelectedMaster">The pagemodel of the root you want to change</param>
        Task<IFreshPageModel> SwitchSelectedMaster<T>()where T : class, IFreshPageModel;

        Task PopToRoot(bool animate);

		void BatchBegin();

		void BatchCommit();
        Task PushPageModel<T>(Action<T> setPageModel, bool modal = false, bool animate = true) where T : class, IFreshPageModel;
    }
}

