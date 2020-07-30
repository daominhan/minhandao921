using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanGiayNam.Libraries
{
    public class phantrang
    {
        public int pageCurrent()
        {
            var pageCurrent = 1;
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["page"]))
            {
                pageCurrent = int.Parse(HttpContext.Current.Request.QueryString["page"].ToString());
            }
            return pageCurrent;
        }
        public int pageFirst(int pageCurrent, int pageSize)
        {
            return (pageCurrent - 1) * pageSize;
        }
        public string PageLink(int total, int pageSize, string strUrl)
        {
            int pageNumber = total / pageSize;
            pageNumber = (total % pageSize != 0) ? (pageNumber++) : (pageNumber);
            string strpageLink = "<ul>";
            for (int i = 1; i <= pageNumber; i++)
            {
                strpageLink += "<li><a href='" + strUrl + "&page=" + i.ToString() + "'>" + i.ToString() + "</a></li>";
            }
            strpageLink += "<ul>";
            return strpageLink;
        }
    }
}