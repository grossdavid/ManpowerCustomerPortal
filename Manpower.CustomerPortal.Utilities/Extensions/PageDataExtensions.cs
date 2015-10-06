using System.Collections.Generic;
using EPiServer.Core;

namespace Manpower.Portal.Utilities.Extensions
{
    public static class PageDataExtensions
    {
        public static IEnumerable<T> GetChildren<T>(this PageData self, bool filterForVisitor = true, bool filterDisplayInMenu = false, string language = null) where T : PageData
        {
            return self.PageLink.GetChildren<T>(filterForVisitor, filterDisplayInMenu, language);
        }

        public static PaginatedList<T> GetChildren<T>(this PageData self, int page, int pageSize, bool filterForVistor = true)
            where T : PageData
        {
            return self.PageLink.GetChildren<T>(page, pageSize, filterForVistor);
        }

        public static bool IsAccessible(this PageData page)
        {
            return (page != null && !page.IsDeleted && page.CheckPublishedStatus(PagePublishedStatus.Published) && page.IsVisibleOnSite());
        }
    }
}
