<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server" method="get">
        <div>
            <%
               
                for (int i = 0; i < 10; i++)
                {
                    Response.Write("你好asp.net!<br/>");
                }

                Response.Write("<br/>" + Request.ApplicationPath);
                Response.Write("<br/>" + Server.MapPath(Request.ApplicationPath + "App_Code"));
                Response.Write("<br/>");
            %>
            <asp:TextBox ID="tbDemo" runat="server"></asp:TextBox>
            <asp:Button runat="server" ID="btnDemo" Text="服务器按钮" />
            <%=tbDemo.Text %>
        </div>
    </form>
</body>
</html>
