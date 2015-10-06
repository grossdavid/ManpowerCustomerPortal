using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using Manpower.CustomerPortal.ContentTypes.Pages.Base;

namespace Manpower.CustomerPortal.ContentTypes.Pages
{
    [ContentType(DisplayName = "DocumentListPage", GUID = "72FC614B-1753-4205-BD85-422E69D4ECF3", Description = "")]
    public class DocumentListPage : PageTypeBase
    {
        [CultureSpecific]
        [Display(
            Name = "Main body",
            Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        public virtual XhtmlString MainBody { get; set; }

        [UIHint(UIHint.MediaFolder)]
        [Display(
            Name = "Document container",
            Description = "Folder to list document from",
            GroupName = SystemTabNames.Content,
            Order = 200)]
        public virtual ContentReference DocumentContainer{ get; set; }

    }
}