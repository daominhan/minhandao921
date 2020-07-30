<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="default.ascx.cs" Inherits="BanGiayNam.Component.sanpham._default" %>
<%@ Register Src="~/Modules/ListCategory.ascx" TagPrefix="uc1" TagName="ListCategory" %>
<%@ Register Src="~/Modules/Lastproduct.ascx" TagPrefix="uc1" TagName="Lastproduct" %>
<%@ Register Src="~/Components/sanpham/detail.ascx" TagPrefix="uc1" TagName="detail" %>
<div class="container">
    <div class="row">
        <div class="col-md-3">
            <uc1:ListCategory runat="server" ID="ListCategory" />
            <uc1:Lastproduct runat="server" ID="Lastproduct" />
            <uc1:detail runat="server" ID="detail" />
        </div>
        <div class="col-md-9">
            <h3>Sản phẩm theo loại</h3>
            <div class="row">
                <asp:Repeater ID="rptSanpham" runat="server">
                    <ItemTemplate>
                        <div class="col-md-4">
                            <div class="product-items mb-3">
                                <a href="Default.aspx?option=sanpham&id=<%# Eval("Slug") %>">
                                    <img class="img-fluid" src="public/images/<%# Eval("Img") %>" alt="<%# Eval("Img") %>" />
                                </a>
                                <h3><a href="Default.aspx?option=sanpham&id=<%# Eval("Slug") %>"><%# Eval("Name") %></a></h3>
                                <h3><%# Eval("Price","{0:0,0} đ") %></h3>
                                <a href="#" class="btn btn-success w-100">Đặt hàng</a>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="row">
                <asp:Literal ID="ltPhantrang" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
</div>
