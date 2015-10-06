using System.IO;

namespace Manpower.Portal.Utilities.Extensions
{
    public static class MediaFileExtentions
    {
        public static string GetExtension(this IMediaFile file)
        {
            var extension = Path.GetExtension(file.Name);

            if (!string.IsNullOrWhiteSpace(extension))
            {
                return extension.Substring(1);
            }

            return null;
        }
    }
}