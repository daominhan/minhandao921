<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="default.ascx.cs" Inherits="BanGiayNam.Component.lienhe._default" %>
<div class="container">
        <div class="row">
 
            <div class="col-md-12">
                <asp:Literal ID="ltThongbao" runat="server"></asp:Literal>
                <div class="form-group">
                    <label for="">Họ và tên</label>
                    <asp:TextBox ID="txtFullname" runat="server" CssClass="form-control" placeholder="Họ và tên" />
                </div>
                 <div class="form-group">
                    <label for="">Email</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email" />
                </div>
                 <div class="form-group">
                    <label for="">Số điện thoại</label>
                    <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" placeholder="Số điện thoại" Type="number" />
                </div>
                 <div class="form-group">
                    <label for="">Tiêu đề liên hệ</label>
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" placeholder="Tiêu đề liên hệ" />
                </div>
                 <div class="form-group">
                    <label for="">Nội dung liên hệ</label>
                    <asp:TextBox ID="txtDetail" TextMode="MultiLine" runat="server" CssClass="form-control" placeholder="Nội dung liên hệ" />
                </div>
                <div class="form-group">
                    <asp:Button ID="btGui" OnClick="btGui_Click" CssClass="btn btn-outline-danger" Text="Gửi liên hệ" runat="server" />
                </div>
            </div>
                 <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6" style="margin-top: 40px">
		<div class="googlemap" style="float: left; width: 680px; height: 520px;">
			<iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2330.072876463196!2d106.77959636001317!3d10.834265524889044!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x317527049eb3decb%3A0xb602c61adaf65858!2zMTg5IFTEg25nIE5oxqFuIFBow7osIFTEg25nIE5oxqFuIFBow7ogQiwgUXXhuq1uIDksIEjhu5MgQ2jDrSBNaW5oLCBWaWV0bmFt!5e0!3m2!1sen!2sin!4v1503222962846" width="600" height="450" frameborder="0" style="border:0" allowfullscreen></iframe>
		</div>
        </div>
    </div>
