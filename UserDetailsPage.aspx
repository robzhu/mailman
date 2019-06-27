<%@ Page Title="User Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserDetailsPage.aspx.cs" Inherits="Mailman.UserDetailsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView runat="server" ItemType="Mailman.Models.User" SelectMethod="LoadModel" RenderOuterTable="false">
        <ItemTemplate >
            <h2><%#: Item.FirstName%> <%#: Item.LastName%></h2>
            <p><%#: Item.EmailAddress %></p>

            <h3>Current Subscriptions:</h3>
            <div id="CurrentSubscriptions" style="text-align: left">
                <asp:ListView ID="user_Subscriptions"
                    ItemType="Mailman.Models.MailingList"
                    runat="server"
                    SelectMethod="GetUserSubscriptions">
                    <ItemTemplate>
                        <div style="display: grid; grid: auto / 40rem 12rem 12rem">
                            <div>
                                <a href="/MailingListDetailsPage.aspx?id=<%#: Item.MailingListID %>">
                                    <%#: Item.Name %>
                                </a>
                            </div>
                            <asp:LinkButton ID="buttonUnsubscribe" runat="server" OnCommand="buttonUnsubscribe_Command" CommandArgument="<%#: Item.MailingListID %>">
                                Unsubscribe
                            </asp:LinkButton>
                        </div>
                        <p>
                            <%#: Item.Description %>
                        </p>
                    </ItemTemplate>
                    <ItemSeparatorTemplate>
                        <br />
                    </ItemSeparatorTemplate>
                </asp:ListView>
            </div>

            <h3>Available Subscriptions:</h3>
            <div id="AvaialableSubscriptions" style="text-align: left">
                <asp:ListView ID="ListView1"
                    ItemType="Mailman.Models.MailingList"
                    runat="server"
                    SelectMethod="GetAvailableSubscriptions">
                    <ItemTemplate>
                        <div style="display: grid; grid: auto / 40rem 12rem 12rem">
                            <div>
                                <a href="/MailingListDetailsPage.aspx?id=<%#: Item.MailingListID %>">
                                    <%#: Item.Name %>
                                </a>
                            </div>
                            <asp:LinkButton ID="buttonSubscribe" runat="server" OnCommand="buttonSubscribe_Command" CommandArgument="<%#: Item.MailingListID %>">
                                Subscribe
                            </asp:LinkButton>
                        </div>
                        <p>
                            <%#: Item.Description %>
                        </p>
                    </ItemTemplate>
                    <ItemSeparatorTemplate>
                        <br />
                    </ItemSeparatorTemplate>
                </asp:ListView>
            </div>

            <%--Add
            Remove--%>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
