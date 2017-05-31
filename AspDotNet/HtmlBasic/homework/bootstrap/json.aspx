<%@ Page Language="C#" AutoEventWireup="true" CodeFile="json.aspx.cs" Inherits="homework_bootstrap_ajax" %>

<%
    if (Request["mode"] == "1")
    {
%>
  {"data":"服务器数据"}
<%
    }
    else
    {
%>
  {"data":"asp.net处理"}
<%
    }
    
%>