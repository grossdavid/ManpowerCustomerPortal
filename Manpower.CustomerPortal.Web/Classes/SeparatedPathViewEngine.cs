using System.Linq;
using System.Web.Mvc;

namespace Manpower.CustomerPortal.Web.Classes
{
    public class SeparatedPathViewEngine : RazorViewEngine
    {
        private readonly string[] _partialViewLocationPaths =
        {
            "~/Views/Shared/Blocks/{0}.cshtml",
            "~/Views/Shared/PagePartials/{0}.cshtml",
            "~/Views/Shared/DisplayTemplates/{0}.cshtml",
            "~/Views/Shared/DisplayTemplates/{1}/{0}.cshtml"
        };

        private readonly string[] _viewLocationPaths =
        {
            "~/Views/Blocks/{1}/{0}.cshtml",   
            "~/Views/Pages/{1}/{0}.cshtml",
            "~/Views/Pages/{1}.cshtml"
        };

        public SeparatedPathViewEngine()
        {
            PartialViewLocationFormats = PartialViewLocationFormats.Union(_partialViewLocationPaths).ToArray();
            ViewLocationFormats = ViewLocationFormats.Union(_viewLocationPaths).ToArray();
        }
    }
}