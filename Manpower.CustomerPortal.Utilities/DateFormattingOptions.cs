namespace Manpower.CustomerPortal.Utilities
{
    public enum DateFormat
    {
        AgoFormat,
        LongDateFormat,
        ShortDateFormat,
        FullDateTimeFormat,
    }

    public struct DateFormattingOptions
    {
        public static DateFormattingOptions Default
        {
            get
            {
                return new DateFormattingOptions()
                {
                    DateFormat = DateFormat.LongDateFormat
                };
            }
        }
        public bool LowerCaseFirstLetter { get; set; }
        public DateFormat DateFormat { get; set; }
    }
}
