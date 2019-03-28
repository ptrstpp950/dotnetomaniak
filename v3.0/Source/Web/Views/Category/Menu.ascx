<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ICollection<ICategory>>" %>
<script runat="server">
    private bool IsInSupportPages(string url)
    {
        return url.Contains("PromoteSite") || url.Contains("Faq") || url.Contains("Contact") || url.Contains("About");
    }

    private bool IsCategory(string url)
    {
        return url.Contains("Category/");
    }
    </script>
<ul class="navbar-nav mr-auto mt-2 mt-lg-0">
    <li class="nav-item dropdown <%= IsCategory(Request.Url.AbsolutePath) ? "active" : string.Empty %>">
        <a class="nav-link dropdown-toggle" href="#" id="navbarDropdownCategories" role="button" 
           data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
            Kategorie
        </a>
        <div class="dropdown-menu" aria-labelledby="navbarDropdownCategories">
            <%
                foreach (ICategory category in Model.OrderBy(x => x.Name))
                {
            %>
                <a class="dropdown-item" href="<%= Url.Action("Category", "Story", new { name = category.UniqueName })%>"
                   data-toggle="tooltip" data-placement="right" title="<%=category.Description%>">
                    <%= category.Name %>
                </a>
            <%
                }
            %>
        </div>
    </li>
    <li class="nav-item dropdown <%= IsInSupportPages(Request.Url.AbsolutePath) ? "active" : string.Empty %>">
        <a class="nav-link dropdown-toggle" href="#" id="navbarDropdownAbout" role="button" 
           data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
            O dotNETomaniak
        </a>
        <div class="dropdown-menu" aria-labelledby="navbarDropdownAbout">
            <a class="dropdown-item" href="<%= Url.Action("All","Badges") %>">Odznaki</a>
            <a class="dropdown-item" href="<%= Url.RouteUrl("PromoteSite")%>">Promocja</a>
            <a class="dropdown-item" href="<%= Url.Action("Faq", "Support")%>">FAQ</a>
            <a class="dropdown-item" href="<%= Url.RouteUrl("About") %>">O dotNETomaniak</a>
            <a class="dropdown-item" href="<%= Url.Action("Policy","Support") %>">Polityka prywatności</a>
            <a class="dropdown-item" href="<%= Url.RouteUrl("Contact") %>">Kontakt</a>
        </div>
    </li>
    <li><a class="nav-item nav-link" href="http://dotnetomaniak.cupsell.pl" target="_blank">Sklep z gadżetami</a></li>
</ul>