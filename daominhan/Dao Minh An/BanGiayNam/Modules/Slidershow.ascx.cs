using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BanGiayNam.Models;

namespace BanGiayNam.Modules
{
    public partial class Slidershow : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DBBanGiayNam db = new DBBanGiayNam();
            var list = db.Sliders
            .Where(m => m.StateId == 1 && m.Position == "Slideshow")
            .OrderBy(m => m.Orders).ToList();
            String strSlider1 = "";
            String strSlider2 = "";
            int i = 1;
            foreach (var slider in list)
            {
                if (i == 1)
                {
                    strSlider1 += "<li data-target='#carouselExampleIndicators' data-slide-to='0' class='active'></li>";
                    strSlider2 += "<div class='carousel-item active'>";
                    strSlider2 += "<img class='d-block w-100' src='public/images/" + slider.Img + "' alt='First slide'/>";
                    strSlider2 += " </div>";
                }
                else
                {
                    strSlider1 += "<li data-target='#carouselExampleIndicators' data-slide-to='0'></li>";
                    strSlider2 += "<div class='carousel-item'>";
                    strSlider2 += "<img class='d-block w-100' src='public/images/" + slider.Img + "' alt='First slide'/>";
                    strSlider2 += " </div>";
                }
                i++;
            }
            ltSlider1.Text = strSlider1;
            ltSlider2.Text = strSlider2;
        }
    }
}