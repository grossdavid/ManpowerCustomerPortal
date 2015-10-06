using System.Collections.Generic;
using EPiServer.Core;
using Manpower.CustomerPortal.ContentTypes.Pages;

namespace Manpower.CustomerPortal.Web.Models.ViewModels
{
    public class DocumentListViewModel : PageViewModel<DocumentListPage>
    {
        public DocumentListViewModel(DocumentListPage currentPage) : base(currentPage)
        {
            
        }

        public ContentReference DocumentContainer { get; set; }

        public List<IContent> Documents { get; set; } 
    }
}