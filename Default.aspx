<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Mailman._Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .longTextBox {
            width: 600px;
        }
        input {
            max-width: 600px;
        }
    </style>

    <h2>Mailman: The simplest mailing list organizer.</h2>
    <br />

    <div>
        <h3>Create New List:</h3>
        <p style="margin-bottom:0">Name:</p>
        <asp:TextBox ID="NewList_Name" runat="server" CssClass="longTextBox"></asp:TextBox>
        <p style="margin-top: 1rem; margin-bottom:0">Description:</p>
        <asp:TextBox ID="NewList_Description" runat="server" CssClass="longTextBox"></asp:TextBox>
        <br />
        <br />
        <asp:LinkButton style="margin-top: 2rem" ID="NewList_Create" runat="server" OnClick="NewList_Create_Click" Font-Bold="true" Font-Size="Large">Create</asp:LinkButton>
    </div>

    <br />
    <br />
    <br />

    <h3>Lists:</h3>
    <div id="Lists" style="text-align: left">
        <asp:ListView ID="mailingLists_List"
            ItemType="Mailman.Models.MailingList"
            runat="server"
            SelectMethod="GetMailingLists">
            <ItemTemplate>
                <div style="display: grid; grid: auto / 40rem 12rem 12rem">
                    <div style="font-size: large; font-style: normal;">
                        <a href="/MailingListDetailsEx.aspx?id=<%#: Item.MailingListID %>">
                            <%#: Item.Name %>
                        </a>
                    </div>
                    <asp:LinkButton ID="listEdit" runat="server" OnCommand="listEdit_Click" CommandArgument="<%#: Item.MailingListID %>">
                        Edit
                    </asp:LinkButton>
                    <asp:LinkButton ID="listDelete" runat="server" OnCommand="listDelete_Click" CommandArgument="<%#: Item.MailingListID %>">
                        Delete
                    </asp:LinkButton>
                </div>
                
            </ItemTemplate>
            <ItemSeparatorTemplate>
                <br />
            </ItemSeparatorTemplate>
        </asp:ListView>
    </div>
</asp:Content>
