using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;

namespace Manpower.CustomerPortal.ContentTypes.Media
{
    [ContentType(GUID = "224BB751-1A90-432F-80D8-D685943439B2")]
    [MediaDescriptor(ExtensionString = "jpg,jpeg,jpe,gif,bmp,png")]
    public class ImageFile : MediaBase, IContentImage
    {
    }
}