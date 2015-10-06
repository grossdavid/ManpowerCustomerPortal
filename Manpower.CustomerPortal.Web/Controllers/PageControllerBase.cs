using EPiServer.Web.Mvc;
using Manpower.CustomerPortal.ContentTypes.Pages.Base;

namespace Manpower.CustomerPortal.Web.Controllers
{
    public abstract class PageControllerBase<T> : PageController<T> where T : PageTypeBase
    {
    }
}