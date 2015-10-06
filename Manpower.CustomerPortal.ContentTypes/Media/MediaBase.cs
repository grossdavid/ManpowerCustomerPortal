using System.ComponentModel.DataAnnotations;
using EPiServer.Core;

namespace Manpower.CustomerPortal.ContentTypes.Media
{
    public abstract class MediaBase : MediaData//, IMediaFile
    {
        [ScaffoldColumn(false)]
        public virtual string Extension { get; set; }
        
        [ScaffoldColumn(false)]
        public virtual string Title { get; set; }
        
        [ScaffoldColumn(false)]
        public virtual bool IsLocked { get; set; }

        [ScaffoldColumn(false)]
        public virtual string ChangeNote { get; set; }

        [ScaffoldColumn(false)]
        public virtual bool MarkAsChanged { get; set; }
    }
}
