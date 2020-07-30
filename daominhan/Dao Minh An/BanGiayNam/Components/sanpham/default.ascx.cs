using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BanGiayNam.Models;
using BanGiayNam.Libraries;

namespace BanGiayNam.Component.sanpham
{
    public partial class _default : System.Web.UI.UserControl
    {
        DBBanGiayNam db = new DBBanGiayNam();
        phantrang pt = new phantrang();
        protected void Page_Load(object sender, EventArgs e)
        {
            var pageSize = 9;
            int pageCurrent = pt.pageCurrent();
            int pageFirst = pt.pageFirst(pageCurrent, pageSize);
            int total = db.Products
                .Where(m => m.StateId == 1)
                .Count();
            ltPhantrang.Text = pt.PageLink(total, pageSize, "Default.aspx?option=sanpham");
            var list = db.Products
                .Where(m => m.StateId == 1)
                .OrderByDescending(m => m.Created_at)
                .Skip(pageFirst).Take(pageSize);
            rptSanpham.DataSource = list.ToList();
            rptSanpham.DataBind();
        }
    }
}