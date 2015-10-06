using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace Manpower.CustomerPortal.ContentTypes.Pages.Base
{
    /// <summary>
    /// Base class for all page types
    /// </summary>
    public abstract class PageTypeBase : PageData, IContentBase
    {

        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Heading",
            Description = "Page heading",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string Heading
        {
            get
            {
                var heading = this.GetPropertyValue(p => p.Heading);

                // Use heading if available, otherwise page name
                return !string.IsNullOrWhiteSpace(heading)
                       ? heading
                       : PageName;
            }
            set { this.SetPropertyValue(p => p.Heading, value); }
        }
    }
}
