<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="homework_form_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
    <%
        string username = Request["username"];
        string password = Request["password"];
       
    %>
<body>
     <%
         if (String.IsNullOrEmpty(username))
         {
             Response.AddHeader("refresh","2;URL=login.html");
             Response.Write("用户名必须填写，2秒后自动返回登录。");
             Response.Write("<a href='login.html'>返回登录。</a>");
             return;
         }
         if (String.IsNullOrEmpty(password))
         {
             Response.AddHeader("refresh", "2;URL=login.html");
             Response.Write("密码必须填写，2秒后自动返回登录。");
             Response.Write("<a href='login.html'>返回登录。</a>");
             return;
         }
         if (!String.Equals("admin",username))
         {
             Response.AddHeader("refresh", "2;URL=login.html");
             Response.Write("用户名错误，2秒后自动返回登录。");
             Response.Write("<a href='login.html'>返回登录。</a>");
             return;
         }
         if (!String.Equals("123456", password))
         {
             Response.AddHeader("refresh", "2;URL=login.html");
             Response.Write("密码错误，2秒后自动返回登录。");
             Response.Write("<a href='login.html'>返回登录。</a>");
             return;
         }
         Response.Write("登录成功。。。");
     %>
    
</body>
</html>
