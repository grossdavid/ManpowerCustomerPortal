using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;

namespace Manpower.CustomerPortal.ContentTypes.Media
{
    [ContentType(GUID = "72BACCC3-6B3C-414B-9E45-E8C394254F98")]
    [MediaDescriptor(ExtensionString = "doc,docx,xls,xlsx,ppt,pptx")]
    public class OfficeFile : MediaBase
    {
    }
}