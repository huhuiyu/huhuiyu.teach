<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reg.aspx.cs" Inherits="homework_form_Reg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <h1>
        注册信息:<br/>
        用户名：<%=Request["username"] %><br/>
        密码：<%=Request["password"] %><br/>
        确认密码：<%=Request["password1"] %><br/>
    </h1>
</body>
</html>
