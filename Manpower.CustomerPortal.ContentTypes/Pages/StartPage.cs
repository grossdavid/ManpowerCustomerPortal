using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using Manpower.CustomerPortal.ContentTypes.Pages.Base;

namespace Manpower.CustomerPortal.ContentTypes.Pages
{
    [ContentType(DisplayName = "StartPage", GUID = "F93BCB21-F3B5-477D-9D6B-C802C261676D", Description = "Startpage")]
    public class StartPage : PageTypeBase
    {
        
        [CultureSpecific]
        [Display(
            Name = "Main body",
            Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        public virtual XhtmlString MainBody { get; set; }

        [Editable(true)]
        [UIHint(UIHint.MediaFile)]
        [Display(
            Name = "Report file",
            GroupName = SystemTabNames.Content,
            Order = 200)]
        public virtual ContentReference ReportDownloadFile { get; set; }
    }
}