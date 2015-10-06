using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;

namespace Manpower.CustomerPortal.ContentTypes.Media
{
    [ContentType(GUID = "9DFAEE30-28FC-4D9A-A71B-BF7C6C384F9F")]
    [MediaDescriptor(ExtensionString = "pdf")]
    public class PdfFile :  MediaBase
    {
    }
} 