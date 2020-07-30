<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Lastproduct.ascx.cs" Inherits="BanGiayNam.Modules.Lastproduct" %>
<h3>Sản phẩm mới nhất</h3>
<asp:Repeater ID="rptLastproduct" runat="server">
    <ItemTemplate>
<div class="row">
    <div class="col-md-4">
        <a href="Default?option=sanpham&id=<%# Eval("Slug") %>">
        <img src="public/images/<%# Eval("Img") %>" class="img-fluid" />
            </a>
    </div>
    <div class="col-md-8">
        <p><a href="Default?option=sanpham&id=<%# Eval("Slug") %>"><%# Eval("Name") %></a></p>
        <p><%# Eval("Price","{0:0,0} đ") %></p>
        </div>
</div>

    </ItemTemplate>
</asp:Repeater>
