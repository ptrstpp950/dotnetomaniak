<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<BaseViewData>" %>
<% bool isAuthenticated = Model.IsCurrentUserAuthenticated; %>

<div id="membershipBox" class="modal" tabindex="-1" role="dialog">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title">Logowanie</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                <nav>
                    <div class="nav nav-tabs" id="nav-tab" role="tablist">
                        <a class="nav-item nav-link active" id="nav-login-tab" data-toggle="tab" href="#nav-login"
                           role="tab" aria-controls="nav-home" aria-selected="true">
                            Logowanie
                        </a>
                        <a class="nav-item nav-link" id="nav-openId-tab" data-toggle="tab" href="#nav-openId"
                           role="tab" aria-controls="nav-profile" aria-selected="false">
                            Logowanie OpenId
                        </a>
                    </div>
                </nav>
                <div class="tab-content" id="nav-tabContent">
                    <div class="tab-pane fade show active" id="nav-login" role="tabpanel" aria-labelledby="nav-login-tab">
                        <form id="frmLogin" action="<%= Url.Action("Login", "Membership") %>" method="post">
                            <div class="form-group">
                                <label for="txtLoginUserName">
                                    Nazwa użytkownika:
                                </label>
                                <input id="txtLoginUserName" class="form-control" name="userName" type="text"
                                       placeholder="nazwa użytkownika"/>
                                <span class="error"></span>
                            </div>
                            <div class="form-group">
                                <label for="txtLoginPassword">
                                    Hasło:
                                </label>
                                <input id="txtLoginPassword" name="password" type="password" class="form-control"
                                       placeholder="hasło"/>
                                <span class="error"></span>
                            </div>
                            <div class="form-check">
                                <input id="chkLoginRememberMe" class="form-check-input" name="rememberMe" type="checkbox"
                                       value="true"/>
                                <label class="form-check-label" for="chkLoginRememberMe">
                                    Zapamiętajmnie na tym komputerze
                                </label>
                            </div>
                            <button id="btnLogin" type="submit" class="btn btn-primary">zaloguj</button>
                            <button type="button" href="#" id="lostPassword" name="lostPassword"
                                    class="btn btn-secondary">
                                zapomniałem hasła
                            </button>
                            <span id="loginMessage" class="message"></span>
                        </form>
                        <h6>
                            lub...
                        </h6>
                        <p>
                            Zaloguj się przy użyciu Facebooka.
                        </p>
                        <div>
                            <fb:login-button scope="public_profile,email"
                                             onlogin="checkLoginState();" data-size="large">
                                Zaloguj
                            </fb:login-button>
                        </div>


                    </div>
                    <div class="tab-pane fade" id="nav-openId" role="tabpanel" aria-labelledby="nav-openId-tab">
                        <p>
                            Zewnętrzni dostawcy tożsamości korzystają z technologii OpenID, dzięki której Twoje
                            hasło zawsze jest poufne i nie musisz zapamiętywać kolejnego.
                        </p>
                        <form id="frmOpenIdLogin" action="<%= Url.Action("OpenId", "Membership") %>" method="post">
                            <fieldset>
                                <div class="add-article-row">
                                    <label for="openid_identifier" class="label" id="openId">
                                        Wprowadź URL swojego OpenID:
                                    </label>
                                    <br/>
                                    <input id="openid_identifier" name="identifier" type="text" class="openIDTextBox"/>
                                    <span class="error"></span>
                                </div>
                                <div class="add-row2">
                                    <input id="openid_RememberMe" name="rememberMe" type="checkbox" value="true"/>Zapamiętaj
                                    mnie na tym komputerze
                                </div>
                                <div class="add-article-row">
                                    <button id="btnOpenId" type="submit" class="btn btn-primary">login</button>
                                </div>
                            </fieldset>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>


<div id="signupSection" class="modal" tabindex="-1" role="dialog">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title">Załóż konto</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                <p>
                    Podaj nazwę użytkownika i adres e-mail, aby założyć konto. Dzięki niemu będziesz na
                    bieżąco informowany o zmianach w serwisie.
                </p>
                <form id="frmSignup" action="<%= Url.Action("Signup", "Membership") %>" method="post">
                    <div class="form-group">
                        <label for="txtSignupUserName">
                            Nazwa użytkownika:
                        </label>
                        <input id="txtSignupUserName" name="userName" type="text" class="form-control"/>
                        <span class="error invalid-feedback"></span>
                    </div>
                    <div class="form-group">
                        <label for="txtSignupPassword">
                            Hasło:
                        </label>
                        <input id="txtSignupPassword" name="password" type="password" class="form-control"/>
                        <span class="error invalid-feedback"></span>
                    </div>
                    <div class="form-group">
                        <label for="txtSignupEmail">
                            Email:
                        </label>
                        <input id="txtSignupEmail" name="email" type="text" class="form-control"/>
                        <span class="error invalid-feedback"></span>
                        <span class="info valid-feedback">
                            (Proszę wprowadź poprawny adres e-mail,
                            będzie potrzebny do weryfikacji)
                        </span>
                    </div>
                    <div class="form-group">
                        <span id="signupMessage" class="message"></span>
                    </div>
                    <div class="add-article-row">
                        <input id="btnSignup" type="submit" class="btn btn-primary" value="Zarejestruj się"/>
                    </div>
                </form>
            </div>
        </div>
    </div>
</div>

<% if ((isAuthenticated) && (!Model.CurrentUser.IsOpenIDAccount())) %>
<%
   { %>
    <div class="modal" tabindex="-1" role="dialog" id="changePasswordSection">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Zmień hasło</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <form id="frmChangePassword" action="<%= Url.Action("ChangePassword", "Membership") %>"
                          method="post">
                        <div class="form-group">
                            <label for="txtChangeOldPassword">
                                Stare:
                            </label>
                            <input id="txtChangeOldPassword" name="oldPassword" type="password" class="form-control"/>
                            <span class="error invalid-feedback"></span>
                        </div>
                        <div class="form-group">
                            <label for="txtChangeNewPassword">
                                Nowe:
                            </label>
                            <input id="txtChangeNewPassword" name="newPassword" type="password" class="form-control"/>
                            <span class="error invalid-feedback"></span>
                        </div>
                        <div class="form-group">
                            <label for="txtChangenConfirmPassword">
                                Potwierdź:
                            </label>
                            <input id="txtChangenConfirmPassword" name="confirmPassword" type="password" class="form-control"/>
                            <span class="error invalid-feedback"></span>
                        </div>
                        <div class="form-group">
                            <span id="changePasswordMessage" class="info valid-feedback"></span>
                        </div>
                        <div class="form-group">
                            <input id="btnChangePassword" type="submit" class="btn btn-primary"  value="Change Password"/>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
<% } %>


<!--div id="membershipBox" class="modalBox">
<div class="titleContainer">
    <div class="title">
        <%--<% Model.SiteTitle%>--%></div>
    <div id="membershipClose" class="closeButton" title="Close">
    </div>
</div>
<div class="contentContainer">
    <% if ((isAuthenticated) && (!Model.CurrentUser.IsOpenIDAccount())) %>
    <%
       { %>
        <div id="changePasswordSection">
            <div class="box">
                <h5>Zmień hasło</h5>                
                <form id="frmChangePassword" action="<%= Url.Action("ChangePassword", "Membership") %>"
                      method="post">
                    <fieldset>
                        <div class="add-article-row">
                            <label for="txtChangeOldPassword" class="label">
                                Stare:</label>
                            <input id="txtChangeOldPassword" name="oldPassword" type="password" class="textBox" />
                            <span class="error"></span>
                        </div>
                        <div class="add-article-row">
                            <label for="txtChangeNewPassword" class="label">
                                Nowe:</label>
                            <input id="txtChangeNewPassword" name="newPassword" type="password" class="textBox" />
                            <span class="error"></span>
                        </div>
                        <div class="add-article-row">
                            <label for="txtChangenConfirmPassword" class="label">
                                Potwierdź:</label>
                            <input id="txtChangenConfirmPassword" name="confirmPassword" type="password" class="textBox" />
                            <span class="error"></span>
                        </div>
                        <div class="add-article-row">
                            <span id="changePasswordMessage" class="message"></span>
                        </div>
                        <div class="add-article-row">
                            <input id="btnChangePassword" type="submit" class="button" value="Change Password" />
                        </div>
                    </fieldset>
                </form>
            </div>
        </div>        
    <% } %>
    <% if (!isAuthenticated) %>
    <%
       { %>
        <div id="lostPasswordSection">
            <div class="box">
                <h5>Zapomniałeś hasła</h5>
                <form id="frmForgotPassword" action="<%= Url.Action("ForgotPassword", "Membership") %>" method="post">
                    <fieldset>
                        <div class="add-article-row">
                            <label for="txtForgotEmail" class="label">
                                Email:</label>
                            <input id="txtForgotEmail" name="email" type="text" class="textBox" />
                            <span class="error"></span><span class="info">(działa tylko dla zarejestrowanych)</span>
                        </div>
                        <div class="add-article-row">
                            <span id="forgotPasswordMessage" class="message"></span>
                        </div>
                        <div class="add-article-row">
                            <input id="btnForgotPassword" type="submit" class="button" value="Wyślij hasło" />
                        </div>
                    </fieldset>
                </form>
            </div>            
        </div> 
    <% } %>
    <div id="RecommendationSection">
        <div class="box">
            <h5>
                Edycja reklamy</h5>
            <form id="frmRecommendation" action="<%= Url.Action("EditAd", "Recommendation") %>" method="post">
                <fieldset>
                    <input type="hidden" id="hidAdId" name="id"/>
                    <div class="add-article-row">
                        <label for="txtRecommendationLink" class="label">
                            Link rekomendacji:</label>
                        <input id="txtRecommendationLink" name="RecommendationLink" type="text" class="textBox" />
                        <span class="error"></span>
                    </div>
                    <div class="add-article-row">
                        <label for="txtRecommendationTitle" class="label">
                            Tytuł rekomendacji:</label>
                        <input id="txtRecommendationTitle" name="RecommendationTitle" type="text" class="textBox" />
                        <span class="error"></span>
                    </div>
                    <div class="add-article-row">
                        <label for="txtImageLink" class="label">
                            Link zdjęcia:</label>
                        <input id="txtImageLink" name="ImageLink" type="text" class="textBox" />
                        <span class="error"></span>
                    </div>
                    <div class="add-article-row">
                        <label for="txtImageTitle" class="label">
                            Tytuł zdjęcia:</label>
                        <input id="txtImageTitle" name="ImageTitle" type="text" class="textBox"/>
                    </div>
                    <div class="add-article-row">
                        <label for="txtStartTime" class="label">
                            Reklama od:</label>
                        <input id="txtStartTime" name="StartTime" type="text" class="textBox"/>
                    </div>
                    <div class="add-article-row">
                        <label for="txtEndTime" class="label">
                            Reklama do:</label>
                        <input id="txtEndTime" name="EndTime" type="text" class="textBox"/>
                    </div>
                    <div class="add-article-row">
                        <label for="txtPosition" class="label">
                            Pozycja reklamy:</label>
                        <input id="txtPosition" name="Position" type="text" class="textBox"/>
                    </div>
                    <div class="add-article-row">
                        <label for="txtEmail" class="label">
                            Email:</label>
                        <input id="txtEmail" name="Email" type="text" class="textBox"/>
                    </div>
                    <div class="add-article-row">
                        <label for="IsBanner" class="label" class="textBox">
                            Banner:</label>
                        <input id="IsBanner" name="isBanner" type="checkbox"/>
                        <input name="isBanner" type="hidden"/>
                    </div>
                    <div class="add-article-row">
                        <span id="RecommendationMessage" class="message"></span>
                    </div>
                    <div class="add-article-row">
                        <input id="btnSubmitAd" type="submit" class="button" value="Sign up" />
                    </div>
                </fieldset>
            </form>
        </div>
    </div>
    <div id="EventSection">
        <div class="box">
            <h5>
                Edycja wydarzenia</h5>
            <form id="frmEvent" action="<%= Url.Action("AddEvent", "CommingEvent") %>" method="post">
                <fieldset>
                    <input type="hidden" id="hidEventId" name="id"/>                    
                    <div class="add-article-row">
                        <label for="txtEventLink" class="label">
                            Link do wydarzenia:</label>
                        <input id="txtEventLink" name="EventLink" type="text" class="textBox" />
                        <span class="error"></span>
                    </div>
                    <div class="add-article-row">
                        <label for="txtEventName" class="label">
                            Nazwa wydarzenia:</label>
                        <input id="txtEventName" name="EventName" type="text" class="textBox" />
                        <span class="error"></span>
                    </div>
                    <div class="add-article-row">
                        <label for="txtEventDate" class="label">
                            Data wydarzenia:</label>
                        <input id="txtEventDate" name="EventDate" type="text" class="textBox"/>
                    </div>
                    <div class="add-article-row">
                        <label for="txtEventPlace" class="label">
                            Miejsce wydarzenia:</label>
                        <input id="txtEventPlace" name="EventPlace" type="text" class="textBox"/>
                        <span class="error"></span>
                    </div>
                    <div class="add-article-row">
                        <label for="txtEventLead" class="label">
                            Opis wydarzenia:</label>
                        <textarea id="txtEventLead" name="EventLead" cols="40" rows="5" maxlength="500" class="largeTextArea" style="width: 334px !important;">Brak opisu</textarea>                        
                        <span class="error"></span>
                    </div>
                    <div class="add-article-row">
                        <label for="txtUserEmail" class="label">
                            Email zgłaszającego:
                        </label>
                        <input id="txtUserEmail" name="EventUserEmail" type="text" class="textBox" value="true" />
                        <span class="error"></span>
                    </div>
                    <% if (Model.IsCurrentUserAuthenticated && Model.CurrentUser != null &&
                           Model.CurrentUser.IsAdministrator())
                       { %>
                        <div id="isApprovedCheckbox" class="add-article-row" >
                            <label for="IsApproved" class="label" class="textBox">
                                Jest zatwierdzony:</label>
                            <%--<input id="isApprovedCheckBox" name="IsApproved" type="checkbox"/>  --%>     
                            <%= Html.CheckBox("IsApproved") %>               
                        </div>
                    <% } %>
                    <div class="add-article-row">
                        <span id="EventMessage" class="message"></span>
                    </div>
                    <div class="add-article-row">
                        <input id="btnSubmitEvent" type="submit" class="button" value="Sign up" />
                    </div>
                </fieldset>
            </form>
        </div>
    </div>
</div>
</div-->