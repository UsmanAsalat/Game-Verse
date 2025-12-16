<%@ Page Title="Wishlist" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Wishlist.aspx.cs" Inherits="GameVerse.Wishlist" %>

<asp:Content ID="WishlistContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container my-5">
        <h2 class="text-warning mb-4">💖 Your Wishlist</h2>
        <asp:Literal ID="litWishlist" runat="server" />
    </div>
</asp:Content>
