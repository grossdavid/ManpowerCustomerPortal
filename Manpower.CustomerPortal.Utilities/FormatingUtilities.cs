using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using EPiServer.Framework.Localization;
using Encoder = Microsoft.Security.Application.Encoder;

namespace Manpower.CustomerPortal.Utilities
{
    public static class FormattingUtilities
    {
        #region Text formatting

        public static string FormatPlainText(string text, bool forList = false)
        {
            TextFormattingOptions formatting;
            if (forList)
                formatting = TextFormattingOptions.DefaultPlainTextInLists;
            else
                formatting = TextFormattingOptions.DefaultPlainText;

            return FormatText(text, formatting);
        }

        public static string FormatHtmlText(string text, bool forList = false)
        {
            TextFormattingOptions formatting;
            if (forList)
                formatting = TextFormattingOptions.DefaultHtmlTextInLists;
            else
                formatting = TextFormattingOptions.DefaultHtmlText;

            return FormatText(text, formatting);
        }

        public static string FormatToolTip(string text)
        {
            return FormatText(text, TextFormattingOptions.DefaultToolTips);
        }

        public static string FormatText(string text, TextFormattingOptions options)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            string formatted = text;

            if (options.UrlEncode)
            {
                formatted = Encoder.UrlEncode(formatted);
            }
            else if (options.HtmlEncode)
            {
                formatted = Encoder.HtmlEncode(formatted);
            }
            else if (options.HtmlAttributeEncode)
            {
                //formatted = AntiXss.HtmlAttributeEncode(formatted);
                formatted = HttpUtility.HtmlAttributeEncode(formatted);
            }
            else if (options.JavascriptEncode)
            {
                formatted = HttpUtility.JavaScriptStringEncode(formatted);
            }
            else
            {
                formatted = RemoveStyleAndScriptDefinitions(text);

                if (options.RemoveAllTags)
                    formatted = RemoveAllTags(formatted);

                else if (options.BlackListedTags != null)
                    formatted = RemoveTags(formatted, options.BlackListedTags);

                else if (options.WhiteListedTags != null)
                    formatted = RemoveAllTagsExceptWhiteListed(formatted, options.WhiteListedTags);

                //formatted = AntiXss.GetSafeHtmlFragment(formatted);
            }


            if (options.MaxWordLength > 0)
                formatted = SplitLongWordsInText(formatted, options.MaxWordLength);

            if (options.MaxLength > 0 && formatted.Length > options.MaxLength)
                formatted = CropText(formatted, options.MaxLength);

            if (options.NewLinesToBreakTags)
            {
                formatted = formatted.Replace("\n", "<br />\n");
                formatted = formatted.Replace("&#13;", "<br />\n"); //we also replace the html-encoded newline chars.
            }

            if (options.LowerCaseFirstLetter)
                formatted = MakeFirstLetterToLowerCase(formatted);

            else if (options.UpperCaseFirstLetter)
                formatted = MakeFirstLetterUpperCase(formatted);

            return formatted;
        }

        public static string[] GetWhiteListedHtmlTags()
        {
            return new[]                 
            { 
                "b",
                "i",
                "u", 
                "strong", 
                "em", 
                "pre",
                "code",
                "a", 
                "ul", 
                "ol", 
                "li", 
                "p", 
                "br", 
                "blockquote",
                "span",
                "img",
                "embed",
                "object"
           };
        }

        public static string CropText(string text, int maxLength)
        {
            if (string.IsNullOrEmpty(text) || maxLength <= 0)
                return text;

            string formatted = text;

            int num = 0;
            bool withinTag = false;
            bool withinHtmlEncoded = false;
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < formatted.Length; i++)
            {
                char c = formatted[i];

                builder.Append(c);

                if (!withinTag && !withinHtmlEncoded)
                {
                    num++;
                }

                if (c == '<')
                    withinTag = true;
                else if (c == '>')
                    withinTag = false;
                else if (c == '&')
                    withinHtmlEncoded = true;
                else if (c == ';' || char.IsWhiteSpace(c))
                    withinHtmlEncoded = false;

                if (!withinTag && !withinHtmlEncoded && num >= maxLength)
                {
                    builder.Append("...");
                    break;
                }
            }
            formatted = builder.ToString();
            return formatted;
        }

        public static string SplitLongWordsInText(string text, int maxWordLength)
        {
            if (string.IsNullOrEmpty(text) || maxWordLength <= 0)
                return text;

            string formatted = text;

            int num = 0;
            bool withinTag = false;
            bool withinHtmlEncoded = false;
            StringBuilder builder = new StringBuilder(formatted);
            for (int i = 0; i < builder.Length; i++)
            {
                char c = builder[i];

                if (char.IsWhiteSpace(c))
                {
                    num = 0;
                }
                else if (!withinTag && !withinHtmlEncoded)
                {
                    num++;
                }

                if (c == '<')
                    withinTag = true;
                else if (c == '>')
                    withinTag = false;
                else if (c == '&')
                    withinHtmlEncoded = true;
                else if (c == ';' || char.IsWhiteSpace(c))
                    withinHtmlEncoded = false;

                if (!withinTag && !withinHtmlEncoded && num >= maxWordLength)
                {
                    builder.Insert(++i, " ");
                    num = 0;
                }
            }
            formatted = builder.ToString();
            return formatted;
        }

        public static string MakeFirstLetterUpperCase(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            char[] letters = text.ToCharArray();
            letters[0] = char.ToUpper(letters[0]);
            return new string(letters);
        }

        public static string MakeFirstLetterToLowerCase(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            char[] letters = text.ToCharArray();
            letters[0] = char.ToLower(letters[0]);
            return new string(letters);
        }

        public static string RemoveTags(string text, params string[] tags)
        {
            //Build regex for encoding forbidden tags
            string pattern = @"<\s*/?\s*({0})[^>]*>";

            StringBuilder sb = new StringBuilder();
            sb.Append("(" + tags[0] + ")");
            for (int i = 1; i < tags.Length; i++)
            {
                sb.Append("|(" + tags[i] + ")");
            }

            pattern = string.Format(pattern, sb);
            Regex regex = new Regex(pattern, RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.RightToLeft);

            StringBuilder processedText = new StringBuilder(text);

            foreach (Match m in regex.Matches(text))
            {
                string sequence = text.Substring(m.Index, m.Length);
                processedText = processedText.Replace(sequence, string.Empty, m.Index, m.Length);
            }
            return processedText.ToString();
        }

        public static string RemoveStyleAndScriptDefinitions(string text)
        {
            string pattern = @"<{0}.*?</{0}[^>]*>";

            RegexOptions options = RegexOptions.Singleline | RegexOptions.IgnoreCase;

            text = Regex.Replace(text, string.Format(pattern, "style"), string.Empty, options);
            text = Regex.Replace(text, string.Format(pattern, "script"), string.Empty, options);

            text = Regex.Replace(text, string.Format(pattern, @"[a-z]+:[a-z]+"), string.Empty, options);
            text = Regex.Replace(text, @"<!--.*?-->", string.Empty, options);
            return text;
        }

        public static string RemoveAllTags(string text)
        {
            return RemoveTags(text, "[a-z]");
        }

        public static string RemoveHtmlTagsAndEntities(string text = "")
        {
            text = Regex.Replace(text, @"<[^>]*(>|$)", string.Empty);
            text = Regex.Replace(text, @"&[^;]+?;", string.Empty);
            return text;
        }
        

        public static string RemoveAllTagsExceptWhiteListed(string text, params string[] allowedTags)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string tag in allowedTags)
            {
                sb.Append(string.Format(@"(?!/?\s*{0}[^a-z])", tag));
            }
            return RemoveTags(text, sb.ToString());
        }

        #endregion

        #region Date formatting

        public static string FormatDate(DateTime date, DateFormattingOptions options)
        {
            string formatted;

            switch (options.DateFormat)
            {
                default:
                    formatted = AgoFormat(ref date);
                    break;
                case DateFormat.LongDateFormat:
                    formatted = date.ToString(LocalizationService.Current.GetString("/Common/DateTime/DateFormat"));
                    break;
                case DateFormat.ShortDateFormat:
                    formatted = date.ToString(LocalizationService.Current.GetString("/Common/DateTime/ShortDateFormat"));
                    break;
                case DateFormat.FullDateTimeFormat:
                    formatted = date.ToString(LocalizationService.Current.GetString("/Common/DateTime/FullDateTimeFormat"));
                    break;
            }

            if (options.LowerCaseFirstLetter)
                formatted = FormatText(formatted, new TextFormattingOptions() { LowerCaseFirstLetter = true });

            return formatted;
        }

        private static string AgoFormat(ref DateTime date)
        {
            string formatted;

            TimeSpan ts = DateTime.Today.AddDays(1) - date;

            if (ts.Days == 0)
            { 
                TimeSpan tsExact = DateTime.Now - date;

                if (tsExact.Hours == 0)
                    formatted = LocalizationService.Current.GetString("/Common/DateTime/Now");
                else if (tsExact.Hours == 1)
                    formatted = LocalizationService.Current.GetString("/Common/DateTime/OneHourAgo");
                else
                    formatted = string.Format(LocalizationService.Current.GetString("/Common/DateTime/HoursAgo"), tsExact.Hours);
            }
            else if (ts.Days == 1)
                formatted = LocalizationService.Current.GetString("/Common/DateTime/Yesterday");
            else if (ts.Days < 7)
                formatted = string.Format(LocalizationService.Current.GetString("/Common/DateTime/DaysAgo"), ts.Days);
            else if (ts.Days >= 7 && ts.Days < 14)
                formatted = LocalizationService.Current.GetString("/Common/DateTime/OneWeekAgo");
            else if (ts.Days >= 14 && ts.Days <= 30)
                formatted = string.Format(LocalizationService.Current.GetString("/Common/DateTime/WeeksAgo"), Math.Floor(ts.Days / 7.0));
            else
                formatted = date.ToString(LocalizationService.Current.GetString("/Common/DateTime/DateFormat"));

            return formatted;
        }

        public static string GetPossessiveCase(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            char[] letters = text.ToCharArray();
            char lastLetter = char.ToLower(letters[letters.Length - 1]);

            if (lastLetter == 's')
                return text + LocalizationService.Current.GetString("/Common/Text/PossesiveCaseEndingWithS");
            else
                return text + LocalizationService.Current.GetString("/Common/Text/PossesiveCase");
        }

        #endregion
    }
}
