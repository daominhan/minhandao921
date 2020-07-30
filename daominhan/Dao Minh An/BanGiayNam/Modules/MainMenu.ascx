<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainMenu.ascx.cs" Inherits="BanGiayNam.Modules.MainMenu" %>
<div class="col-md-2">
				
			 </div>
			<div class="col-md-6 menutop">
				<ul>
					  <li><a href="Default.aspx?option=trangchu">Trang Chủ</a></li>
					  <li ><a href="Default.aspx?option=gioithieu">Giới Thiệu</a></li>
                    <asp:Literal ID="ltMenuSanpham" runat="server"></asp:Literal>
					  
					  <li><a href="Default.aspx?option=tintuc">Tin Tức</a></li>
					  <li ><a href="Default.aspx?option=lienhe">Liên Hệ</a></li>
                    <li class="nav-item dropdown">
        <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
          Dropdown
        </a>
        <div class="dropdown-menu" aria-labelledby="navbarDropdown">
          <a class="dropdown-item" href="#">Action</a>
          <a class="dropdown-item" href="#">Another action</a>
          <div class="dropdown-divider"></div>
          <a class="dropdown-item" href="#">Something else here</a>
        </div>
      </li>
				</ul>
			 </div>