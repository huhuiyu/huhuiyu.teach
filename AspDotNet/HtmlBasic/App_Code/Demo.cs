using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Demo 的摘要说明
/// </summary>
public class Demo
{
    public Demo()
    {
    }

    public static void Test(HttpResponse response)
    {
        response.Write("<br/>" + DateTime.Now.ToString("yyyy-MM-dd"));
    }
}