<%@ Page Title="" Language="C#" MasterPageFile="~/Apex.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="apex_store.Login1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div id="login">
                <h4>Login</h4>
                <hr/>
                <asp:Label CssClass="form-label" runat="server">E-mail: </asp:Label><asp:TextBox ID="tbxEmail" runat="server"/><br/>
                <asp:Label CssClass="form-label" runat="server">Password:</asp:Label><asp:TextBox ID="tbxPassword" TextMode="password" runat="server"/><br/>
                <span class="input-group-btn">
                <asp:Button ID="btnLogin" runat="server" class="btn btn-success btn-sm btn-form" Text="Login" OnClick="btnLogin_Click"></asp:Button>
                </span>
                <asp:CheckBox runat="server" ID="cbxRememberMe"/>Remember Me
                <asp:Label runat="server" ID="lbl1"></asp:Label>
            </div>
        </div>
</asp:Content>
