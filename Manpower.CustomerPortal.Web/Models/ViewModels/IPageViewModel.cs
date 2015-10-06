using Manpower.CustomerPortal.ContentTypes.Pages.Base;

namespace Manpower.CustomerPortal.Web.Models.ViewModels
{
    public interface IPageViewModel<out T> where T : PageTypeBase
    {
        T CurrentPage { get; }

        LayoutViewModel Layout { get; set; }
    }
}