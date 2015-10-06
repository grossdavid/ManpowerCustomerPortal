using System;

namespace Manpower.CustomerPortal.Utilities
{
    public static class DateExtensions
    {
        public static string ToFormatted(this DateTime date)
        {
            return FormattingUtilities.FormatDate(date, DateFormattingOptions.Default);
        }

        public static string ToFormatted(this DateTime date, DateFormattingOptions options)
        {
            return FormattingUtilities.FormatDate(date, options);
        }

        public static string ToFormatted(this DateTime date, DateFormat format)
        {
            return FormattingUtilities.FormatDate(date, new DateFormattingOptions() { DateFormat = format });
        }
    }
}
