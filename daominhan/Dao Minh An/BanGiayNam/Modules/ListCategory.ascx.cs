using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BanGiayNam.Models;
namespace BanGiayNam.Modules
{
    public partial class ListCategory : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DBBanGiayNam db = new DBBanGiayNam();
            var list1 = db.Categorys.Where(m => m.StateId == 1 && m.ParentId == 0)
                .OrderBy(m => m.Orders).ToList();
            string strListcat = "<h3>Danh mục sản phẩm</h3>";
            strListcat += "<ul>";
            foreach (var item1 in list1)
            {
                strListcat += "<li>";
                strListcat += "<a href='Default.aspx?option=sanpham&cat=" + item1.Slug + "'>" + item1.Name + "</a>";
                var list2 = db.Categorys
                    .Where(m => m.StateId == 1 && m.ParentId == item1.Id)
                .OrderBy(m => m.Orders);
                if (!list2.Count().Equals(0))
                {
                    strListcat += "<ul>";
                    foreach (var item2 in list2)
                    {
                        strListcat += "<li>";
                        strListcat += "<a href='Default.aspx?option=sanpham&cat=" + item2.Slug + "'>" + item2.Name + "</a>";
                        var list3 = db.Categorys
                            .Where(m => m.StateId == 1 && m.ParentId == item2.Id)
                            .OrderBy(m => m.Orders);
                        if (!list3.Count().Equals(0))
                        {
                            strListcat += "<ul>";
                            foreach (var item3 in list3)
                            {
                                strListcat += "<li>";
                                strListcat += "<a href='Default.aspx?option=sanpham&cat=" + item3.Slug + "'>" + item3.Name + "</a>";
                                strListcat += "</li>";
                            }
                            strListcat += "</ul>";
                        }
                        strListcat += "</li>";
                    }
                    strListcat += "</ul>";
                }
                strListcat += "</li>";
            }
            strListcat += "</ul>";
            ltListCategory.Text = strListcat;
        }
    }
}