using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;

namespace Manpower.CustomerPortal.ContentTypes.Media
{
    [ContentType(GUID = "f54613a1-64d4-430a-b893-a08ddd4c4b0a")]
    [MediaDescriptor(ExtensionString = "txt")]
    public class TextFile : MediaBase
    {
    }
}