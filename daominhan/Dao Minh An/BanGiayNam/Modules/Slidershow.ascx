<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Slidershow.ascx.cs" Inherits="BanGiayNam.Modules.Slidershow" %>
<div class="slider">
							<div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
							<ol class="carousel-indicators">
                                <asp:Literal ID="ltSlider1" runat="server"></asp:Literal>
	    					
							  </ol>
							  <div class="carousel-inner" role="listbox">
                                  <asp:Literal ID="ltSlider2" runat="server"></asp:Literal>

							  </div>
							  <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
							    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
							    <span class="sr-only">Previous</span>
							  </a>
							  <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
							    <span class="carousel-control-next-icon" aria-hidden="true"></span>
							    <span class="sr-only">Next</span>
							  </a>
							</div>
						</div>