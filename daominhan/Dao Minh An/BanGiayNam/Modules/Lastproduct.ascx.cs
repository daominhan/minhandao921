using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BanGiayNam.Models;

namespace BanGiayNam.Modules
{
    public partial class Lastproduct : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DBBanGiayNam db = new DBBanGiayNam();
            var listlastproduct = db.Products
                .Where(m => m.StateId == 1)
                .OrderByDescending(m => m.Created_at)
                .Take(10);
            rptLastproduct.DataSource = listlastproduct.ToList();
            rptLastproduct.DataBind();
 
        }
    }
}