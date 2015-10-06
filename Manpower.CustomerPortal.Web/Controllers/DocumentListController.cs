using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using Manpower.CustomerPortal.ContentTypes.Pages;
using Manpower.CustomerPortal.Web.Models.ViewModels;

namespace Manpower.CustomerPortal.Web.Controllers
{
    public class DocumentListController : PageControllerBase<DocumentListPage>
    {
        // GET: DocumentList
        public ActionResult Index(DocumentListPage currentPage)
        {
            var model = new DocumentListViewModel(currentPage);
            model.DocumentContainer = currentPage.DocumentContainer;
            model.Documents = GetDocuments(currentPage.DocumentContainer);

            return View(model);
        }

        private List<IContent> GetDocuments(ContentReference documentContainer)
        {
            if(ContentReference.IsNullOrEmpty(documentContainer))
                return null;

            return ServiceLocator.Current.GetInstance<IContentRepository>().GetChildren<IContent>(documentContainer).ToList();
        }
    }
}