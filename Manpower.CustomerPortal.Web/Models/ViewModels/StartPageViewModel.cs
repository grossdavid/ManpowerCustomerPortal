using Manpower.CustomerPortal.ContentTypes.Pages;

namespace Manpower.CustomerPortal.Web.Models.ViewModels
{
    public class StartPageViewModel : PageViewModel<StartPage>
    {
        public StartPageViewModel(StartPage currentPage) : base(currentPage) { }

        public string CustomerReportDownloadUrl { get; set; }
    }
}