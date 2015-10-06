using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using EPiServer.Core;
using Manpower.CustomerPortal.Utilities.Extensions;

namespace Manpower.CustomerPortal.Web
{
    // ReSharper disable once InconsistentNaming
    public partial class login : Page
    {
        protected override void OnLoad(EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    AutoLoginCookie.CheckAutoLoginCookie(Request.Cookies["AutoLoginCookie"]);
            //}

            if (Request.QueryString["accessDenied"] == "1")
            {
                ShowAccesssDenied();
            }

            var destinationUrl = Request.QueryString["returnUrl"];
            if (string.IsNullOrWhiteSpace(destinationUrl))
            {
                destinationUrl = ContentReference.StartPage.GetUrl();
            }

            loginControl.DestinationPageUrl = destinationUrl;

            base.OnLoad(e);

            //var hyperLinkLoginInstructions = (HyperLink)loginControl.FindControl("hyperLinkLoginInstructions");
            //var cbKeepLoggedIn = (CheckBox)loginControl.FindControl("cbKeepLoggedIn");
            //cbKeepLoggedIn.Text = Translations.KeepMeLoggedIn;

            //if (hyperLinkLoginInstructions != null && !string.IsNullOrWhiteSpace(CurrentPage.LoginInstructionsUrl))
            //{
            //    hyperLinkLoginInstructions.NavigateUrl = CurrentPage.LoginInstructionsUrl;
            //    hyperLinkLoginInstructions.Text = CurrentPage.LoginInstructionsText;
            //}
        }

        private void ShowAccesssDenied()
        {
            var spanFailure = (HtmlControl)loginControl.FindControl("spanFailure");
            spanFailure.Visible = true;

            //var failureText = (ITextControl)loginControl.FindControl("FailureText");
            //failureText.Text = Translations.AccesDenied;
        }

        protected void login_LoginError(object sender, EventArgs e)
        {
            var spanFailure = (HtmlControl)loginControl.FindControl("spanFailure");
            spanFailure.Visible = true;
        }

        //public LoginGlobalization Translations
        //{
        //    get { return GlobalizationBuilderFactory.GetGlobalizationSectionInstance<LoginGlobalization>(); }
        //}

        //private ISettings _settings;
        //public ISettings Settings
        //{
        //    get { return _settings ?? (_settings = SettingsProviderFactory.GetSettingsProvider().GetSettings()); }
        //}

        protected void login_LoggedIn(object sender, EventArgs e)
        {
            //var cbKeepLoggedIn = (CheckBox)loginControl.FindControl("cbKeepLoggedIn");
            //var userName = (TextBox)loginControl.FindControl("UserName");

            //var currentUser = Membership.GetUser(userName.Text);

            //if (cbKeepLoggedIn.Checked && currentUser != null)
            //    Response.Cookies.Add(AutoLoginCookie.CreateAutoLoginCookie(currentUser.UserName));
        }
    }
}