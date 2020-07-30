using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BanGiayNam.Models;
namespace BanGiayNam.Modules
{
    public partial class MainMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DBBanGiayNam db = new DBBanGiayNam();
            var list = db.Categorys
                .Where(m => m.ParentId == 0 && m.StateId == 1)
                .OrderBy(m => m.Orders);
            String strmainmenu = "";
            if (list.Count().Equals(0))
            {
                strmainmenu += "<li class='nav-item'>";
                strmainmenu += "<a class='nav-lin' href='Default.aspx?option=lienh'>Sản Phẩm</a>";
                strmainmenu += "</li>";
            }
            else
            {
                strmainmenu += "<li class='nav-item dropdown'>";
                strmainmenu += "<a class='nav-link dropdown-toggle' data-toggle='dropdown' href='Default.aspx?option=sanpham' role='button' aria-haspopup='true' aria-expanded='false'>Sản Phẩm</a>";
                strmainmenu += "<div class='dropdown-menu'>";
                foreach (var menu in list.ToList())
                {
                    strmainmenu += "<a class='dropdown-item' href='Default.aspx?option=sanpham&cat=" + menu.Slug + "'>" + menu.Name + "</a>";
                }
                strmainmenu += " </div>";
                strmainmenu += " </li>";
            }
            ltMenuSanpham.Text = strmainmenu;
        }
    }
}