<%@ Page Language="C#" MasterPageFile="~/Views/Shared/SiteTemplate.Master" Inherits="System.Web.Mvc.ViewPage<StoryContentViewData>" %>
<%@ Import Namespace="hbehr.recaptcha" %>

<script runat="server">

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        GenerateScripts();

        Page.Header.Title = "{0} - Dodaj nowy artykuł".FormatWith(Model.SiteTitle);
    }

    private void GenerateScripts()
    {
        jQueryScriptManager scriptManager = jQueryScriptManager.Current;

        scriptManager.RegisterSource(Url.Asset("js3"));

        scriptManager.RegisterOnReady("Story.set_autoDiscover({0});".FormatWith(Model.AutoDiscover.ToString().ToLowerInvariant()));
        scriptManager.RegisterOnReady("Story.set_captchaEnabled({0});".FormatWith(Model.CaptchaEnabled.ToString().ToLowerInvariant()));

        if (Model.AutoDiscover)
        {
            scriptManager.RegisterOnReady("Story.set_retrieveStoryUrl('{0}');".FormatWith(Url.RouteUrl("Retrieve")));
        }

        scriptManager.RegisterOnReady("Story.set_suggestTagsUrl('{0}');".FormatWith(Url.RouteUrl("SuggestTags")));

        scriptManager.RegisterOnReady("Story.init()");
        scriptManager.RegisterOnDispose("Story.dispose();");
    }

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server" />
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div>
        <%= Html.PageHeader("Dodaj nowy artykuł")%>
        <p>Wypełnij formularz, aby dodać artykuł</p>
    </div>
    <form id="frmStorySubmit" action="<%= Url.Action("Submit", "Story") %>" method="post">
        <div class="form-group row">
            <label for="txtStoryUrl" class="form-control-label col-sm-2 col-form-label">Url:</label>
            <div class="col-sm-10">
                <input id="txtStoryUrl" name="url" type="text" class="form-control" value="<%= Model.Url %>" />
                <span id="errorStoryUrl" class="error form-control-feedback"></span>
            </div>
        </div>
        <div class="form-group row">
            <label for="txtStoryTitle" class="form-control-label col-sm-2 col-form-label">Tytuł:</label>
            <div class="col-sm-10">
                <input id="txtStoryTitle" name="title" type="text" class="form-control" value="<%= Model.Title %>" />
                <span class="error form-control-feedback"></span>
            </div>
        </div>
        <div class="form-group row">
            <label for="txtStoryDescription" class="form-control-label col-sm-2 col-form-label">Opis:</label>
            <div class="col-sm-10">
                <input type="hidden" id="hidDescription" name="description" />
                <textarea id="txtStoryDescription" name="storyDescription" class="form-control" cols="52" rows="4"><%= Model.Description %></textarea>
                <span class="error form-control-feedback"></span>
                <div>
                    <a id="lnkStoryPreview" class="btn btn-sm btn-info" href="javascript:void(0)">ukryj podgląd</a>
                </div>
                <div class="wysiwyg-code col-sm-12">
                    <div id="storyPreview" class="livePreview wysiwyg-code2">
                    </div>
                </div>
            </div>
        </div>
        <div class="form-group">
            <label for="txtStoryTags" class="form-control-label col-sm-2 col-form-label">Tagi:</label>
            <input id="txtStoryTags" name="tags" type="text" class="form-control" />
            <span class="form-text">(oddziel przecinkiem wiele tagów)</span>
            <span class="error form-control-feedback"></span>
        </div>
        <div class="add-article-row radios-wrapper">
            <label class="label">
                Kategoria:</label>
            <% Html.RenderAction("RadioButtonList", "Category"); %>   
            <div class="clearfix"></div>
            <span class="error"></span>
        </div>
        <%if (Model.CaptchaEnabled)%>
        <%{%>
        <div class="add-article-row">
            <label>Captcha:</label>
            <div style="float: left;">
            <%= ReCaptcha.GetCaptcha() %>
            </div>
        </div>
        <%}%>
        <div class="add-article-row" id="storyMessage"></div>
        <div class="articleHeader">
        </div>
        <div class="add-article-row">
            <input id="btnStorySubmit" type="submit" class="largeButton" value="Dodaj" />
        </div>
    </form>
</asp:Content>
