using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class XCookie
{
    public static String Get(String Name, String defaultValue)
    {
        var cookie = HttpContext.Current.Request.Cookies[Name];
        if (cookie == null)
        {
            return defaultValue;
        }
        return cookie.Value;
    }

    public static void Set(String Name, Object Value, int Days)
    {
        var cookie = new HttpCookie(Name, Value.ToString());
        cookie.Expires = DateTime.Now.AddDays(Days);
        HttpContext.Current.Response.Cookies.Add(cookie);
    }

    public static String Add(String Name, Object ValueToAdd, int Days)
    {
        var defaultValue = ValueToAdd.ToString();
        var value = XCookie.Get(Name, defaultValue);
        if (!value.Contains(defaultValue))
        {
            value += "," + defaultValue;
        }
        XCookie.Set(Name, value, Days);

        return value;
    }
}