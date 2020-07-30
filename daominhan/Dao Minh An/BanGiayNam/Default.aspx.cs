using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanGiayNam
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strlink = "~/Components/";
            if (string.IsNullOrEmpty(Request.QueryString["option"]))
            {
                strlink += "trangchu/default.ascx";
            }
            else
            {
                string stroption = Request.QueryString["option"].ToString();
                if (string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    if (string.IsNullOrEmpty(Request.QueryString["cat"]))
                    {
                        strlink += stroption + "/default.ascx";
                    }
                    else
                    {
                        strlink += stroption + "/category.ascx";
                    }
                }
                else
                {
                    strlink += stroption + "/detail.ascx";
                }
            }
            Control ct = new Control();
            ct = Page.LoadControl(strlink);
            NoiDung.Controls.Add(ct);
        }
    }
}