namespace Manpower.CustomerPortal.Utilities
{
    public struct TextFormattingOptions
    {
        public static TextFormattingOptions DefaultPlainText
        {
            get
            {
                return new TextFormattingOptions()
                {
                    MaxWordLength = 120,
                    NewLinesToBreakTags = true,
                    HtmlEncode = true,
                };
            }
        }

        public static TextFormattingOptions DefaultPlainTextInLists
        {
            get
            {
                return new TextFormattingOptions()
                {
                    MaxWordLength = 20,
                    RemoveAllTags = true,
                    MaxLength = 85
                };
            }
        }

        public static TextFormattingOptions DefaultToolTips
        {
            get
            {
                return new TextFormattingOptions()
                {
                    HtmlAttributeEncode = true
                };
            }
        }


        public static TextFormattingOptions DefaultHtmlText
        {
            get
            {
                return new TextFormattingOptions()
                {
                    MaxWordLength = 120,
                    WhiteListedTags = FormattingUtilities.GetWhiteListedHtmlTags()
                };
            }
        }

        public static TextFormattingOptions DefaultHtmlTextInLists
        {
            get
            {
                return new TextFormattingOptions()
                {
                    RemoveAllTags = true,
                    MaxWordLength = 120,
                    MaxLength = 300
                };
            }
        }

        public static TextFormattingOptions DefaultJavascript
        {
            get
            {
                return new TextFormattingOptions()
                {
                    JavascriptEncode = true,
                };
            }
        }

        public bool HtmlEncode { get; set; }
        public bool HtmlAttributeEncode { get; set; }
        public bool UrlEncode { get; set; }
        public bool JavascriptEncode { get; set; }

        public bool NewLinesToBreakTags { get; set; }

        public int MaxLength { get; set; }
        public int MaxWordLength { get; set; }

        public bool RemoveAllTags { get; set; }
        public string[] WhiteListedTags { get; set; }
        public string[] BlackListedTags { get; set; }

        public bool UpperCaseFirstLetter { get; set; }
        public bool LowerCaseFirstLetter { get; set; }

    }
}
