using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BanGiayNam.Models;
using BanGiayNam.Libraries;

namespace BanGiayNam.Components.sanpham
{
    public partial class category : System.Web.UI.UserControl
    {
        DBBanGiayNam db = new DBBanGiayNam();
        phantrang pt = new phantrang();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string strcat = Request.QueryString["cat"];
                int pageSize=9;
                int pageCurrent=pt.pageCurrent();
                int pageFirst = pt.pageFirst(pageCurrent, pageSize);
                var row = db.Categorys
               .Where(m => m.Slug == strcat && m.StateId == 1)
               .First();
                int total = db.Products
                     .Where(m => m.CatId == row.Id && m.StateId == 1)
                     .Count();
                var list = db.Products
                    .Where(m => m.CatId == row.Id && m.StateId == 1)
                    .OrderByDescending(m => m.Created_at)
                    .Skip(pageFirst).Take(pageSize);
                rptSanpham.DataSource = list.ToList();
                rptSanpham.DataBind();
                ltPhantrang.Text = pt.PageLink(total, pageSize, "Default.aspx?option=sanpham&cat=" + strcat);
            }
            catch
            {
                Response.Redirect("Default.aspx?option=sanpham");
            }
        }
    }
}