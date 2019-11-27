<%@ Page Title="List Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MailingListDetailsPage.aspx.cs" Inherits="Mailman.MailingListDetailsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="mailingListDetailsForm" runat="server" ItemType="Mailman.Models.MailingList" SelectMethod="LoadModel" RenderOuterTable="false">
        <ItemTemplate>
            <h1><%#: Item.Name %></h1>
            <p><%#: Item.Description %></p>


            <h3>Subscribers:</h3>
            <div id="Lists" style="text-align: left">
                <asp:ListView ID="list_members"
                    ItemType="Mailman.Models.User"
                    runat="server"
                    SelectMethod="GetListMembers">
                    <ItemTemplate>
                        <div style="display: grid; grid: auto / 30rem 20rem 12rem">
                            <div>
                                <a href="/UserDetailsPage.aspx?id=<%#: Item.ID %>">
                                    <%#: Item.EmailAddress %>
                                </a>
                            </div>
                            <p>
                                <%#: Item.FirstName %>, <%#: Item.LastName %>
                            </p>
                            <asp:LinkButton ID="buttonUnsubscribe" runat="server" OnCommand="buttonUnsubscribe_Command" CommandArgument="<%#: Item.ID %>">
                                Unsubscribe
                            </asp:LinkButton>
                        </div>
                    </ItemTemplate>
                    <ItemSeparatorTemplate>
                        <br />
                    </ItemSeparatorTemplate>
                </asp:ListView>
            </div>

        </ItemTemplate>
    </asp:FormView>
</asp:Content>
