namespace Manpower.CustomerPortal.Utilities.Extensions
{
    public static class LinkItemCollectionExtensions
    {
        //public static IEnumerable<T> ToPages<T>(this LinkItemCollection linkItemCollection, bool filterForVisitor = false)
        //{
        //    var pages = new List<PageData>();

        //    foreach (var linkItem in linkItemCollection)
        //    {
        //        string linkUrl;
        //        if (!PermanentLinkMapStore.TryToMapped(linkItem.Href, out linkUrl))
        //            continue;

        //        if (string.IsNullOrEmpty(linkUrl))
        //            continue;

        //        var pageReference = PageReference.ParseUrl(linkUrl);

        //        if (PageReference.IsNullOrEmpty(pageReference))
        //            continue;

        //        pages.Add(DataFactory.Instance.GetPage(pageReference));
        //    }

        //    if (filterForVisitor)
        //    {
        //        var pdc = new PageDataCollection(pages);
        //        return FilterForVisitor.Filter(pdc).Where(p => p.IsVisibleOnSite() && p.VisibleInMenu).OfType<T>();
        //    }
        //    return pages.OfType<T>();
        //}
    }
}
