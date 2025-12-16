<%@ Page Title="Admin Panel" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="GameVerse.AdminPanel" %>

<asp:Content ID="AdminContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container my-5">
        <h2 class="text-info mb-4">🛠️ GameVerse Admin Panel</h2>

        <!-- Add Game Form -->
        <div class="bg-dark p-4 rounded shadow mb-5">
            <h4 class="text-light">Add New Game</h4>
            <div class="mb-3">
                <label class="text-white">Title</label>
                <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label class="text-white">Image URL</label>
                <asp:TextBox ID="txtImage" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label class="text-white">Price</label>
                <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label class="text-white">Description</label>
                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
            </div>
            <asp:Button ID="btnAddGame" runat="server" Text="Add Game" CssClass="btn btn-success" OnClick="btnAddGame_Click" />
        </div>

        <!-- Display Added Games -->
        <h4 class="text-light">Current Games (Mocked)</h4>
        <asp:Literal ID="litGames" runat="server" />
    </div>
</asp:Content>
