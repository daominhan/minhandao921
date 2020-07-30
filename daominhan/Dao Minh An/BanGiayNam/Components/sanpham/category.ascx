<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="category.ascx.cs" Inherits="BanGiayNam.Components.sanpham.category" %>
<%@ Register Src="~/Modules/ListCategory.ascx" TagPrefix="uc1" TagName="ListCategory" %>
<%@ Register Src="~/Modules/Lastproduct.ascx" TagPrefix="uc1" TagName="Lastproduct" %>
<%@ Register Src="~/Components/sanpham/detail.ascx" TagPrefix="uc1" TagName="detail" %>
<div class="row">
        <div class="col-md-3">
            <uc1:ListCategory runat="server" ID="ListCategory" />
            <uc1:Lastproduct runat="server" ID="Lastproduct" />
        </div>
        <div class="col-md-9">
             <div class="bg-white px-2">
                              <h1><asp:Literal ID="ltTitleCategory" runat="server"></asp:Literal></h1>
             <div class="row">
                 <asp:Repeater ID="rptSanpham" runat="server">
                     <ItemTemplate>
                         <div class="col-md-4">
                            <div class="product-items mb-3">
                                <a href="Default.aspx?option=sanpham&id=<%# Eval("Slug") %>">
                            <img class="img-fluid" src="public/images/<%# Eval("Img") %>" alt="<%# Eval("Img") %>" style="height:100px;"/>
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