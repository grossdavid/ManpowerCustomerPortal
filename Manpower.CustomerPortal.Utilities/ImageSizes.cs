using System.Drawing;

namespace Manpower.CustomerPortal.Utilities
{
    public static class ImageSizes
    {
        public static Size UserHeaderSize
        {
            get { return new Size(44, 44); }
        }
        
        public static Size SearchResultSize
        {
            get { return new Size(70, 70); }
        } 

        public static Size UserProfileSize
        {
            get { return new Size(160, 160); }
        }
    }
}
