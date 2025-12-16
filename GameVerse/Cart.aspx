<%@ Page Title="Cart" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="GameVerse.Cart" %>

<asp:Content ID="CartContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container my-5">
        <h2 class="text-success mb-4">🛒 Your Shopping Cart</h2>
        <asp:Literal ID="litCart" runat="server" />

        <asp:Panel ID="pnlCheckout" runat="server" CssClass="mt-4" Visible="false">
            <h4 class="text-white">Total Games: <asp:Label ID="lblTotal" runat="server" /></h4>
            <asp:Button ID="btnPurchase" runat="server" Text="Purchase" CssClass="btn btn-outline-success mt-2" OnClick="btnPurchase_Click" />
        </asp:Panel>
    </div>
</asp:Content>
