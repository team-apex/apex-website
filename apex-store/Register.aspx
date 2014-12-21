<%@ Page Title="" Language="C#" MasterPageFile="~/Apex.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="apex_store.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="//code.jquery.com/ui/1.11.2/jquery-ui.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.2/themes/smoothness/jquery-ui.css"/>
    <link href="Content/site.css" rel="stylesheet" />
</asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container">
            <div id="register" class="input-group"> 
                <h4>Register</h4>
                <hr/>   
                <asp:Label CssClass="form-label" runat="server">First Name: </asp:Label><asp:TextBox ID="tbxFname" CssClass="form-control" placeholder="John" runat="server"/><br/>
                <asp:Label CssClass="form-label" runat="server">Last Name: </asp:Label><asp:TextBox ID="tbxLname" CssClass="form-control" runat="server" placeholder="Smith"/><br/>
                <asp:Label CssClass="form-label" runat="server">E-mail: </asp:Label><asp:TextBox ID="tbxEmail" CssClass="form-control" placeholder="johnsmith@example.com" runat="server"/><br/>
                <asp:Label CssClass="form-label" runat="server">Password: </asp:Label><asp:TextBox ID="tbxPassword" CssClass="form-control" TextMode="Password" placeholder="*************" runat="server"/><br/>
                <asp:Label CssClass="form-label" runat="server">Confirm Password: </asp:Label><asp:TextBox ID="tbxConfirmPassword" CssClass="form-control" TextMode="Password" placeholder="*************" runat="server"/><br/>
                <asp:Label CssClass="form-label" runat="server">Date of Birth: </asp:Label><asp:TextBox ID="tbxDob" CssClass="date form-control" placeholder="06/06/2006" runat="server"/><br/>
                <asp:Label CssClass="form-label" runat="server">Gender:</asp:Label>
                <!--cant align this right-->
                <asp:RadioButtonList ID="rbnGender" runat="server" 
                RepeatDirection="Horizontal" RepeatLayout="Table">
                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
            </asp:RadioButtonList> 
                <asp:CheckBox runat="server" Text="Remember Me" ID="cbxRememberMe"/><br/>
                <asp:Button runat="server" Text="Register" id="btnRegister" class="btn btn-info btn-sm btn-form" OnClick="btnRegister_Click"></asp:Button><p/>
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>
        </div>
            <br/>
        <script>
            $(function () {
                $(".date").datepicker({
                    dateFormat: "dd-MM-yy"
                }).val();
            });
        </script>
    </asp:Content>
