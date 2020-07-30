using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BanGiayNam.Models;

namespace BanGiayNam.Component.trangchu
{
    public partial class _default : System.Web.UI.UserControl
    {
        DBBanGiayNam db = new DBBanGiayNam();
        protected void Page_Load(object sender, EventArgs e)
        {
            var listproduct = db.Products
                .Where(m => m.StateId == 1)
                .OrderByDescending(m => m.Created_at)
                .Take(12);
            rptSanpham.DataSource = listproduct.ToList();
            rptSanpham.DataBind();
        }
    }
}