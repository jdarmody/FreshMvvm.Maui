using System;
using System.ComponentModel;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace FreshMvvm.Maui;

public interface IFreshPageModel : INotifyPropertyChanged
{
    /// <summary>
    /// This event is raise when a page is Popped, this might not be raise everytime a page is Popped. 
    /// Note* this might be raised multiple times. 
    /// </summary>
    event EventHandler PageWasPopped;
    /// <summary>
    /// This property is used by the FreshBaseContentPage and allows you to set the toolbar items on the page.
    /// </summary>
    ObservableCollection<ToolbarItem> ToolbarItems { get; set; }
    /// <summary>
    /// The previous page model, that's automatically filled, on push
    /// </summary>
    IFreshPageModel PreviousPageModel { get; set; }
    /// <summary>
    /// A reference to the current page, that's automatically filled, on push
    /// </summary>
    Page CurrentPage { get; set; }
    void SetCurrentPage(Page page);
    /// <summary>
    /// Core methods are basic built in methods for the App including Pushing, Pop and Alert
    /// </summary>
    IPageModelCoreMethods CoreMethods { get; set; }
    /// <summary>
    /// This method is called when a page is Pop'd, it also allows for data to be returned.
    /// </summary>
    /// <param name="returnedData">This data that's returned from </param>
    void ReverseInit(object returnedData);
    /// <summary>
    /// This method is called when the PageModel is loaded, the initData is the data that's sent from pagemodel before
    /// </summary>
    /// <param name="initData">Data that's sent to this PageModel from the pusher</param>
    void Init(object initData);
    /// <summary>
    /// Is true when this model is the first of a new navigation stack
    /// </summary>
    public bool IsModalFirstChild { get; set; }
    /// <summary>
    /// Used when a page is shown modal and wants a new Navigation Stack
    /// </summary>
    public IFreshNavigationService PreviousNavigationService { get; }
    /// <summary>
    /// Used when a page is shown modal and wants a new Navigation Stack
    /// </summary>
    public IFreshNavigationService CurrentNavigationService { get; }
    
    public void SetPreviousNavigationService(IFreshNavigationService freshNavigationService);
    /// <summary>
    /// To be used only when creating your own navigation container
    /// </summary>
    public void SetCurrentNavigationService(IFreshNavigationService freshNavigationService);
    /// <summary>
    /// This means the current PageModel is shown modally and can be pop'd modally
    /// </summary>
    bool IsModalAndHasPreviousNavigationStack();
    public void RaisePageWasPopped();
}
