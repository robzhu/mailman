<%@ Page Title="Users" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="Mailman.ManageUsers" %>
<asp:Content ID="ContentManageUsers" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .longTextBox {
            width: 600px;
        }
        input {
            max-width: 600px;
        }
    </style>

    <h2>Manage Users</h2>
    <p>This page gives you an overview of all users in the system.</p>
    <br />
    <hr />

    <h2>Add New User:</h2>
    <p style="margin-bottom:0">First Name:</p>
    <asp:TextBox ID="textFirstName" runat="server" CssClass="longTextBox"></asp:TextBox>
    <p style="margin-bottom:0">Last Name:</p>
    <asp:TextBox ID="textLastName" runat="server" CssClass="longTextBox"></asp:TextBox>
    <p style="margin-bottom:0">Email:</p>
    <asp:TextBox ID="textEmail" runat="server" CssClass="longTextBox"></asp:TextBox>
    <br />
    <br />
    <asp:LinkButton style="padding-top: 4rem" ID="buttonAddUser" runat="server" OnClick="buttonAddUser_Click" Font-Bold="true" Font-Size="Large">Add</asp:LinkButton>
    <hr />

    <h3>Users:</h3>
    <div id="Users" style="text-align: left">
        <asp:ListView ID="manageUsers_List"
            ItemType="Mailman.Models.User"
            runat="server"
            SelectMethod="GetAllUsers">
            <ItemTemplate>
                <div style="display: grid; grid: auto / 30rem 20rem">
                    <div style="font-size: large; font-style: normal;">
                        <a href="/UserDetailsPage.aspx?id=<%#: Item.ID %>">
                            <%#: Item.EmailAddress %>
                        </a>
                    </div>
                    <p>
                        <%#: Item.FirstName %> <%#: Item.LastName %>
                    </p>
                </div>
            </ItemTemplate>

            <ItemSeparatorTemplate>
                <br />
            </ItemSeparatorTemplate>
        </asp:ListView>
    </div>
</asp:Content>
