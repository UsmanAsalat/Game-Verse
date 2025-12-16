<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GameVerse._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container my-5">
        <div class="p-5 rounded text-center shadow-lg mb-5" style="background: linear-gradient(145deg, #1e1e1e, #2c2c2c);">
            <img src="https://i.ibb.co/Kj7X6r02/gameverse.jpg" alt="GameVerse Logo" style="border-radius: 15px;" class="mb-3" />
            <h1 class="display-4 fw-bold text-white">Welcome to <span style="color: #00ffff;">GameVerse</span></h1>
            <p class="lead text-light">Explore top PC games. Add to your wishlist or cart. New games coming soon!</p>
            <a class="btn btn-outline-info btn-lg mt-3" href="Store.aspx">Browse Store</a>
        </div>
    </div>
</asp:Content>
