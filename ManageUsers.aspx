<%@ Page Title="Users" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="Mailman.ManageUsers" %>
<asp:Content ID="ContentManageUsers" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Manage Users</h2>
    <p>This page gives you an overview of all users in the system.</p>
    <br />
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
                        <a href="/UserDetailsPage.aspx?id=<%#: Item.UserID %>">
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
