<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="login.aspx.cs" Inherits="Manpower.CustomerPortal.Web.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="Content/css/main.css" media="screen" />
</head>
<body class="manpower">
    <form runat="server">
        <asp:Login OnLoggedIn="login_LoggedIn" ID="loginControl" runat="server" OnLoginError="login_LoginError" FailureText="Kunde inte logga in.">
            <LayoutTemplate>
                <div class="login">
                    <header>
                        <img src="Content/images/logo.jpg" alt="Logo" />
                    </header>
                    <div class="login-content">
                        <div class="login-text">
                            <h3>Logga in</h3>
                            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.</p>

                            <%--<ul>
                                <li><a class="btn" href="/ForgotPassword.aspx">Glömt lösenord</a></li>
                            </ul>--%>

                        </div>
                        <div class="login-form">
                            <section id="spanFailure" runat="server" visible="false" class="alert alert-error">
                                <asp:Literal ID="FailureText" runat="server" />
                            </section>
                            <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" ValidationGroup="LoginUserValidationGroup" />
                            <fieldset>
                                <div class="control-group">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" CssClass="control-label">Användarnamn</asp:Label>
                                    <div class="controls">
                                        <asp:TextBox ID="UserName" runat="server" CssClass="text" />
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                            CssClass="validation-message" ToolTip="Användarnamn är obligatoriskt" ForeColor="" Display="dynamic"
                                            ValidationGroup="LoginUserValidationGroup">Användarnamn är obligatoriskt</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" CssClass="control-label">Lösenord</asp:Label>
                                    <div class="controls">
                                        <asp:TextBox ID="Password" runat="server" CssClass="text" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                            CssClass="validation-message" ToolTip="Lösenord är obligatoriskt" ForeColor="" Display="dynamic"
                                            ValidationGroup="LoginUserValidationGroup">Lösenord är obligatoriskt</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-actions">
                                    <asp:LinkButton ID="LoginButton" CssClass="btn btn-primary" runat="server" CommandName="Login" Text="Logga in" ValidationGroup="LoginUserValidationGroup" />
                                    <br />
                                    <br />
                                    <asp:CheckBox CssClass="cbKeepLoggedIn" runat="server" ID="cbKeepLoggedIn" Text="Kom ihåg mig" />
                                </div>
                            </fieldset>
                        </div>
                    </div>
                </div>
            </LayoutTemplate>
        </asp:Login>
    </form>
</body>
</html>
