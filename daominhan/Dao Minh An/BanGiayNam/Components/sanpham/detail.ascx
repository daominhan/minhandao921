<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="detail.ascx.cs" Inherits="BanGiayNam.Component.sanpham.detail" %>
<div class="container">
    <div class="product-detail">
    <asp:FormView ID="fvChitiet" runat="server" Width="100%">
        <ItemTemplate>
            <div class="row">
                <div class="col-md-6">
                    <img class="img-fluid w-100" src="public/images/<%# Eval("Img") %>" />
                </div>
                <div class="col-md-6">
                    <h1><%# Eval("Name") %></h1>
                    <h3><%# Eval("Price","{0:0,0} đ") %></h3>
                    <h6>Mô tả</h6>
                    <p><%# Eval("Metadesc") %></p>
                    <div class="from-inline">
                        <asp:TextBox ID="txtNumber" CssClass="form-control" runat="server" TextMode="Number" Text="1" />
                        <asp:Button ID="btnDatmua" CssClass="btn btn-outline-danger" runat="server" Text="Đặt mua" />
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:FormView>
        </div>
    <div class="product-more">
        <div class="row">
            <asp:Repeater ID="rptSanphamMore" runat="server" >
                <ItemTemplate >
                    <div class="col-md-3">
                            <div class="product-items mb-3">
                                <a href="Default.aspx?option=sanpham&id=<%# Eval("Slug") %>">
                            <img class="img-fluid" src="public/images/<%# Eval("Img") %>" alt="<%# Eval("Img") %>"/>
                                    </a>
                            <h3><a href="Default.aspx?option=sanpham&id=<%# Eval("Slug") %>"><%# Eval("Name") %></a></h3>
                            <h3><%# Eval("Price","{0:0,0} đ") %></h3>
                            <a href="#" class="btn btn-success w-100">Đặt hàng</a>
                            </div>
                        </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</div>