<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MailingListDetails.aspx.cs" Inherits="Mailman.MailingListDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="mailingListDetail" runat="server" ItemType="Mailman.Models.MailingList" SelectMethod="GetMailingList" RenderOuterTable="false">
        <ItemTemplate>
            <div>
                meow
            </div>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>