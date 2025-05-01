using FreshMvvm.Maui;
using System;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Threading.Tasks;

namespace FreshMvvmApp
{
    public partial class ContactPageModel : FreshBasePageModel
    {
        IDatabaseService _dataService;

        public ContactPageModel (IDatabaseService dataService)
        {
            _dataService = dataService;

            this.WhenAny(HandleContactChanged, o => o.Contact);
        }

        void HandleContactChanged(string propertyName)
        {
            //handle the property changed, nice
        }

        [ObservableProperty]
        Contact _contact;

        public override void Init (object initData)
        {
            if (initData != null) {
                Contact = (Contact)initData;
            } else {
                Contact = new Contact ();
            }
        }

        [RelayCommand]
        private void Save()
        {
            _dataService.UpdateContact(Contact);
            CoreMethods.PopPageModel(Contact);
        }

        [RelayCommand]
        private Task TestModal()
        {
            return CoreMethods.PushPageModel<ModalPageModel>(null, true);
        }

        [RelayCommand]
        private Task TestModalNavigationBasic()
        {
            var page = FreshPageModelResolver.ResolvePageModel<MainMenuPageModel>();
            var basicNavContainer = new FreshNavigationContainer(page);
            return CoreMethods.PushNewNavigationServiceModal(basicNavContainer, new FreshBasePageModel[] { page.GetModel() });
        }

        [RelayCommand]
        private Task TestModalNavigationTabbed()
        {
            var tabbedNavigation = new FreshTabbedNavigationContainer();
            tabbedNavigation.AddTab<ContactListPageModel>("Contacts", "contacts", null);
            tabbedNavigation.AddTab<QuoteListPageModel>("Quotes", "document", null);
            return CoreMethods.PushNewNavigationServiceModal(tabbedNavigation);
        }

        [RelayCommand]
        private Task TestModalNavigationMasterDetail()
        {
            var masterDetailNav = new FreshMasterDetailNavigationContainer();
            masterDetailNav.Init("Menu", "menu");
            masterDetailNav.AddPage<ContactListPageModel>("Contacts", null);
            masterDetailNav.AddPage<QuoteListPageModel>("Quotes", null);
            return CoreMethods.PushNewNavigationServiceModal(masterDetailNav);
        }
    }
}
