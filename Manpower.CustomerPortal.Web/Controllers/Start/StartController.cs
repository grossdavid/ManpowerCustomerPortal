using System.Web.Mvc;
using EPiServer;
using EPiServer.Cms.Shell;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using Manpower.CustomerPortal.ContentTypes.Pages;
using Manpower.CustomerPortal.Web.Models.ViewModels;

namespace Manpower.CustomerPortal.Web.Controllers.Start
{
    public class StartController : PageControllerBase<StartPage>
    {
        // GET: Start
        public ActionResult Index(StartPage currentPage)
        {
            var model = new StartPageViewModel(currentPage);
            model.CustomerReportDownloadUrl = GetReportDownloadUrl(currentPage.ReportDownloadFile);

            return View(model);
        }

        private string GetReportDownloadUrl(ContentReference reportContentReference)
        {
            if (ContentReference.IsNullOrEmpty(reportContentReference))
                return "#";

            var report = ServiceLocator.Current.GetInstance<IContentRepository>().Get<IContent>(reportContentReference);
            return report?.DownloadUrl() ?? "#";
        }
    }
}