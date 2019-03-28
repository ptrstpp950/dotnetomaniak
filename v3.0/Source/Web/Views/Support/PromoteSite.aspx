<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SiteTemplate.Master"
    Inherits="System.Web.Mvc.ViewPage<PromoteSiteViewData>" %>

<script runat="server">

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Page.Header.Title = "{0} - Promocja".FormatWith(Model.SiteTitle);
    }        
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<%= Html.ArticleHeader("Materia�y promocyjne", new string[] { "Strona g��wna", "Materia�y promocyjne"}) %>
    <p>Je�li chcia�by� promowa� dotnetomaniaka, na swojej stronie czy blogu, tutaj znajdziesz
        niezb�d� do tego celu narz�dzia. Je�li masz jakie� pytania odno�nie promocji lub
        brakuje Ci tu czego� -
        <%= Html.ActionLink("napisz nam wiadomo��", "Contact", "Support")%></p>
    
            <%
                foreach (var key in Model.Items.Keys)
                {
%>
            <div class="articleHeader">
                <p>
                    <span class="promo-header"><%=key%></span>
                </p>
            </div>
            <%
                    foreach (var promoteItem in Model.Items[key])
                    {%>
                  <div class="promo">
                    <div class="promo-sample">
                        <img src="<%=promoteItem.Url %>" alt="promocja"  />
                    </div>
                    <div class="promo-download">
                        <p>Pliki do pobrania:</p>
                        <ul>
                            <li><a href="<%=promoteItem.Eps %>" target="_blank">eps</a></li>
                            <li><a href="<%=promoteItem.Pdf %>" target="_blank">pdf</a></li>
                            <li><a href="<%=promoteItem.Jpg %>" target="_blank">jpg</a></li>
                            <li><a href="<%=promoteItem.Png %>" target="_blank">png</a></li>
                        </ul>
                    </div>
                  </div>
                    <%}
                }%>  
                    
        <div class="articleHeader">
            <p>
                <span class="promo-header">Skrypt na bloga</span>
            </p>
        </div>
        <div class="promo">
        <p>
            Je�li masz sw�j blog, lub stron� mo�esz umo�liwi� swoim czytelnikom wypromowanie
            swojego artyku�u na dotnetomaniak.pl. Naj�atwiej b�dzie Ci skorzysta� z <a href="http://www.feedburner.com/fb/a/publishers/feedflare">
                FeedFlare</a>. Niezb�dny plik znajduje si� tu: <a href="http://static.dotnetomaniak.pl/feedflare-v2.0.0.2.xml">
                    http://static.dotnetomaniak.pl/feedflare-v2.0.0.2.xml</a>. Je�li nie mo�esz
            skorzysta� z tego pliku skontaktuj si� z nami po wi�cej informacji.
        </p>      
        <p>
            Je�li masz ochot� mo�esz r�wnie� nas reklamowa� w realnym �wiecie. <a href="http://dotnetomaniak.cupsell.pl">
                Odwied� nasz sklep</a> i wybierz co� dla siebie. Dzi�ki temu b�dziesz mia� fajny
            gad�et a nam pomo�esz w rozwoju i utrzymaniu strony.</p>
    </div>
</asp:Content>
