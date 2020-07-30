<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="default.ascx.cs" Inherits="BanGiayNam.Component.trangchu._default" %>
<%@ Register Src="~/Modules/ListCategory.ascx" TagPrefix="uc1" TagName="ListCategory" %>
<%@ Register Src="~/Modules/Lastproduct.ascx" TagPrefix="uc1" TagName="Lastproduct" %>


<div class="clearfix main">
    <div class="container">
     <div class="row my-3">
         <div class="col-md-3">
             <div class="bg-white px-2">
                 <uc1:ListCategory runat="server" ID="ListCategory" />
             </div>
              <div class="bg-white px-2">
                  <uc1:Lastproduct runat="server" ID="Lastproduct" />
              </div>
             </div>
         <div class="col-md-9">
             <div class="bg-white px-2">
                              <h1>Sản phẩm mới</h1>
             <div class="row">
                 <asp:Repeater ID="rptSanpham" runat="server">
                     <ItemTemplate>
                         <div class="col-md-4">
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
         </div>
        </div>
    </div>
