<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ApplicationInsightsWebsite.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    1.在ApplicationInsights.config中加上Instrumentation Key<br />
    2.頁面執行後會自動回傳Default.aspx的事件回到Azure上<br />

    <asp:Button runat="server" ID="btnException" Text="Create Exception" OnClick="btnException_Click" />
    <asp:Button runat="server" ID="btnCreateCustomEvent" Text="Create Custom Event" OnClick="btnCreateCustomEvent_Click" />
</asp:Content>
