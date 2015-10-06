using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Manpower.CustomerPortal.Utilities
{
    public static class StringExtensions
    {
        private static readonly HashSet<char> _DefaultNonWordCharacters = new HashSet<char> { ',', '.', ':', ';' };

        public static string ToFormatted(this string source, bool forList = false)
        {
            return FormattingUtilities.FormatPlainText(source, forList);
        }

        public static string ToFormatted(this string source, int maxLength)
        {
            TextFormattingOptions formatting = TextFormattingOptions.DefaultPlainText;
            formatting.MaxLength = maxLength;
            return FormattingUtilities.FormatText(source, formatting);
        }

        public static string ToFormattedHtml(this string source, bool forList = false)
        {
            return FormattingUtilities.FormatHtmlText(source, forList);
        }

        public static string ToFormattedHtml(this string source, int maxLength)
        {
            TextFormattingOptions formatting = TextFormattingOptions.DefaultHtmlText;
            formatting.MaxLength = maxLength;
            return FormattingUtilities.FormatText(source, formatting);
        }

        public static string ToFormattedHtml(this string source, params string[] whiteListedTags)
        {
            return FormattingUtilities.FormatHtmlText(source);
        }

        public static string ToFormattedToolTip(this string source)
        {
            return FormattingUtilities.FormatToolTip(source);
        }

        public static string ToFormatted(this string source, TextFormattingOptions options)
        {
            return FormattingUtilities.FormatText(source, options);
        }

        public static string ToPossessive(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return source;

            return FormattingUtilities.GetPossessiveCase(source);
        }

        /// <summary>
        /// Equals ignoring case and culture
        /// </summary>
        /// <param name="self"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool EqualsIgnoreCase(this String self, string value)
        {
            if (self == null)
            {
                return false;
            }
            return self.Equals(value, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Contains ignoring case and culture
        /// </summary>
        /// <param name="self"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ContainsIgnoreCase(this String self, string value)
        {
            return (self.IndexOf(value, StringComparison.InvariantCultureIgnoreCase) > -1);
        }

        public static string CropWholeWords(this string value, int length, HashSet<char> nonWordCharacters = null)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            if (length < 0)
            {
                throw new ArgumentException("Negative values not allowed.", "length");
            }

            if (nonWordCharacters == null)
            {
                nonWordCharacters = _DefaultNonWordCharacters;
            }

            if (length >= value.Length)
            {
                return value;
            }
            int end = length;

            for (int i = end; i > 0; i--)
            {
                if (value[i].IsWhitespace())
                {
                    break;
                }

                if (nonWordCharacters.Contains(value[i])
                    && (value.Length == i + 1 || value[i + 1] == ' '))
                {
                    //Removing a character that isn't whitespace but not part 
                    //of the word either (ie ".") given that the character is 
                    //followed by whitespace or the end of the string makes it
                    //possible to include the word, so we do that.
                    break;
                }
                end--;
            }

            if (end == 0)
            {
                //If the first word is longer than the length we favor 
                //returning it as cropped over returning nothing at all.
                end = length;
            }

            return value.Substring(0, end) + "...";
        }

        public static bool IsValidEmail(this string emailAddress)
        {
            try
            {
                // ReSharper disable once ObjectCreationAsStatement
                new MailAddress(emailAddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private static bool IsWhitespace(this char character)
        {
            return character == ' ' || character == 'n' || character == 't';
        }

        public static string RemoveTagsAndRenderNewlines(this String self)
        {
            var text = FormattingUtilities.RemoveAllTags(self);
            return Regex.Replace(text, Environment.NewLine, "<br />");
        }
    }
}
