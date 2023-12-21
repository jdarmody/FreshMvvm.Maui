﻿using System;
using FreshMvvm.Maui.IOC;
using Microsoft.Maui.Controls;

namespace FreshMvvm.Maui
{
    public static class FreshPageModelResolver
    {
        public static IFreshPageModelMapper PageModelMapper { get; set; } = new FreshPageModelMapper();

        public static Page ResolvePageModel<T> () where T : class, IFreshPageModel
        {
            return ResolvePageModel<T> (null);
        }

        public static Page ResolvePageModel<T> (object initData) where T : class, IFreshPageModel
        {
            var pageModel = DependancyService.Resolve<T> ();

            return ResolvePageModel<T> (initData, pageModel);
        }

        public static Page ResolvePageModel<T> (object data, T pageModel) where T : class, IFreshPageModel
        {
            var type = pageModel.GetType ();
            return ResolvePageModel (type, data, pageModel);
        }

        public static Page ResolvePageModel (Type type, object data) 
        {
            var pageModel = DependancyService.Resolve(type) as IFreshPageModel;
            return ResolvePageModel (type, data, pageModel);
        }

        public static Page ResolvePageModel (Type type, object data, IFreshPageModel pageModel)
        {
            var name = PageModelMapper.GetPageTypeName (type);
            var pageType = Type.GetType (name);
            if (pageType == null)
                throw new Exception (name + " not found");

            var page = (Page)DependancyService.Resolve(pageType);

            BindingPageModel(data, page, pageModel);

            return page;
        }

        public static Page BindingPageModel(object data, Page targetPage, IFreshPageModel pageModel)
        {
            // pageModel.WireEvents (targetPage);
            // pageModel.CurrentPage = targetPage;
            pageModel.SetCurrentPage (targetPage);
            pageModel.CoreMethods = new PageModelCoreMethods (targetPage, pageModel);
            pageModel.Init (data);
            targetPage.BindingContext = pageModel;
            return targetPage;
        }            
    }
}

