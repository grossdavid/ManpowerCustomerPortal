using System.Collections.Generic;
using System.Linq;
using EPiServer;
using EPiServer.Core;
using EPiServer.Filters;
using EPiServer.ServiceLocation;

namespace Manpower.CustomerPortal.Utilities.Extensions
{
    public static class PageReferenceExtensions
    {
        public static string GetUrl(this PageReference self)
        {
            var page = GetPage<PageData>(self);

            return page?.LinkURL;
        }

        public static T GetPage<T>(this PageReference self) where T : PageData
        {
            return ServiceLocator.Current.GetInstance<IContentLoader>().Get<T>(self);
        }

        public static IEnumerable<T> GetChildren<T>(this PageReference self, bool filterForVisitor = true, bool filterDisplayInMenu = false, string language = null) where T : PageData
        {
            var children = (language != null) ? ServiceLocator.Current.GetInstance<IContentLoader>().GetChildren<T>(self, new LanguageSelector(language)) : ServiceLocator.Current.GetInstance<IContentLoader>().GetChildren<T>(self);

            if (filterForVisitor)
            {
                children =  FilterForVisitor.Filter(children).Cast<T>();
            }
            if (filterDisplayInMenu)
            {
                children = children.Where(p => p.VisibleInMenu);
            }
            return children;
        }

        public static PaginatedList<T> GetChildren<T>(this PageReference self, int page, int pageSize, bool filterForVisitor = true) where T : PageData
        {
            return PaginatedList<T>.ToPaginatedList(self.GetChildren<T>(filterForVisitor), page, pageSize);
        }
    }
}
