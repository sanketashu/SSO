<%@ Page Title="" Language="C#" MasterPageFile="~/Site2Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Site2.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table>
            <tr>
                <td>
                    <asp:Label ID="lblMain" runat="server" Font-Bold="True" Font-Names="Broadway" 
                        Font-Size="X-Large">Site 2</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <div id="divLinks" runat="server"></div>
                </td>
            </tr>
        </table>
</asp:Content>
