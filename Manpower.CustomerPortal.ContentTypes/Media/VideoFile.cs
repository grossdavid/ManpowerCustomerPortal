using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;

namespace Manpower.CustomerPortal.ContentTypes.Media
{
    [ContentType(GUID = "21B5145B-D90E-4B67-BF5D-00196F5A7FCE")]
    [MediaDescriptor(ExtensionString = "flv,mp4,mov,avi,webm")]
    public class VideoFile : MediaBase, IContentVideo
    {
    }
}