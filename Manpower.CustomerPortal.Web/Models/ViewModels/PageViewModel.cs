using Manpower.CustomerPortal.ContentTypes.Pages.Base;

namespace Manpower.CustomerPortal.Web.Models.ViewModels
{
    public class PageViewModel<T> : IPageViewModel<T> where T : PageTypeBase
    {
        public PageViewModel(T currentPage)
        {
            CurrentPage = currentPage;
        }

        public T CurrentPage { get; private set; }
        public LayoutViewModel Layout { get; set; }
    }
}