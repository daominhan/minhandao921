using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BanGiayNam.Models;

namespace BanGiayNam.Component.sanpham
{
    public partial class detail : System.Web.UI.UserControl
    {
        DBBanGiayNam db = new DBBanGiayNam();
        protected void Page_Load(object sender, EventArgs e)
        {
            string strlug = Request.QueryString["Id"];
            var row = db.Products.Where(m => m.StateId == 1 && m.Slug == strlug)
                .Take(1);
            fvChitiet.DataSource = row.ToList();
            fvChitiet.DataBind();
            //rptSanphamMore
            var rowProduct = row.First();
            //int catid = rowProduct.CatId;
            var listmore = db.Products
                .Where(m => m.CatId == rowProduct.CatId && m.StateId == 1 && m.Id != rowProduct.Id)
                .OrderByDescending(m => m.Created_at)
                .Take(8);
            rptSanphamMore.DataSource = listmore.ToList();
            rptSanphamMore.DataBind();
        }
    }
}