using System;
using System.Web;

namespace Manpower.Portal.Utilities
{
    public class LocalIntranetUtility
    {
        private readonly LocalIntranetManager _localIntranetManager;
        public LocalIntranetUtility(LocalIntranetManager localIntranetManager)
        {
            _localIntranetManager = localIntranetManager;
        }

        private const string _LocalIntranetStartPageCookieName = "lisp";
        public HttpCookie GetUserLocalIntranetCookie()
        {
            return HttpContext.Current.Request.Cookies[_LocalIntranetStartPageCookieName];
        }

        public void SetUserLocalIntranetCookie(string localIntranetStartPageId = null, string localIntranetStartPageLanguage = null, int cookieDurationDays = 365)
        {
            // Create cookie. (Default cookie: Express in english language for 365 days)
            var localIntranetCookie = new HttpCookie(_LocalIntranetStartPageCookieName);

            localIntranetCookie.Values["id"] = localIntranetStartPageId ?? _localIntranetManager.DefaultLocalIntranetStartPageId;
            localIntranetCookie.Values["language"] = localIntranetStartPageLanguage ?? _localIntranetManager.DefaultLocalIntranetStartPageLanguage;
            localIntranetCookie.Expires = DateTime.Now.AddDays(cookieDurationDays);

            HttpContext.Current.Response.Cookies.Add(localIntranetCookie);
        }

        public void RemoveUserLocalIntranetCookie()
        {
            var localIntranetCookie = new HttpCookie(_LocalIntranetStartPageCookieName)
            {
                Expires = DateTime.Now.AddDays(-1)
            };
            HttpContext.Current.Response.Cookies.Add(localIntranetCookie);
        }
    }
}
