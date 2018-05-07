<%@ Page Title="" Language="C#" MasterPageFile="~/Site2Master.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Site2.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <div class="login-page">
        <div class="form">
            <div class="login-form">
                Name
        <asp:TextBox ID="txtName" runat="server" MaxLength="20"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqValusername" runat="server" ControlToValidate="txtName" Display="Dynamic" CssClass="error" ErrorMessage="required"></asp:RequiredFieldValidator>
                Username
        <asp:TextBox ID="txtUsername" runat="server" MaxLength="20"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqValUsernaame" runat="server" ControlToValidate="txtUsername" Display="Dynamic" CssClass="error" ErrorMessage="required"></asp:RequiredFieldValidator>
                Password
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqValPassword" runat="server" ControlToValidate="txtPassword" Display="Dynamic" CssClass="error" ErrorMessage="required"></asp:RequiredFieldValidator>
                Confirm Password
        <asp:TextBox ID="txtCPassword" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqValCPassword" runat="server" ControlToValidate="txtCPassword" Display="Dynamic" CssClass="error" ErrorMessage="required"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cmpValCPassword" runat="server" ControlToValidate="txtCPassword" ControlToCompare="txtPassword" ErrorMessage="Password and Confirm Password not matched"></asp:CompareValidator>
                <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" Text="Register" Style="background-color: orange;" />

                <p class="message">Already have account? <a href="Login.aspx">Go to Login</a></p>
            </div>
        </div>
    </div>


</asp:Content>
