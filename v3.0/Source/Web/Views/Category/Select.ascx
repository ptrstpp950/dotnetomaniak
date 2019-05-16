<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ICollection<ICategory>>" %>
<select name="category" class="custom-select">
    <option value="" selected>Wybierz kategorię</option>
<%foreach (ICategory category in Model.Where(c=>c.IsActive).OrderBy(c => c.Name)) %>
<%{%>
    <option value="<%= Html.AttributeEncode(category.UniqueName) %>"><%= Html.Encode(category.Name)%></option>
<%}%>    
</select>
