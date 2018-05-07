<%@ Page Title="" Language="C#" MasterPageFile="~/Site2Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Site2.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblMessage" runat="server" style="color:red"></asp:Label>
    <div class="login-page">
        <div class="form">
            <div class="login-form">
                Username <asp:TextBox ID="txtUsername" runat="server" MaxLength="20"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqValusername" runat="server" ControlToValidate="txtUsername" Display="Dynamic" CssClass="error" ErrorMessage="required"></asp:RequiredFieldValidator>
                Password <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqValPassword" runat="server" ControlToValidate="txtPassword" Display="Dynamic" CssClass="error" ErrorMessage="required"></asp:RequiredFieldValidator>
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Login" style="background-color: orange;" />

                <p class="message">Not registered? <a href="Register.aspx">Create an account</a></p>
            </div>
        </div>
    </div>
    
</asp:Content>
