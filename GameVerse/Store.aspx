<%@ Page Title="Store" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Store.aspx.cs" Inherits="GameVerse.Store" %>

<asp:Content ID="StoreContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container my-5">
        <h2 class="text-info mb-4">🎮 Explore Our Game Library</h2>

        <!-- Search Bar -->
        <div class="mb-4">
            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" 
                placeholder="Search games by title..." AutoPostBack="true" 
                OnTextChanged="txtSearch_TextChanged" />
        </div>


        <!-- Game Cards -->
        <div class="row">
            <asp:Repeater ID="rptGames" runat="server" OnItemCommand="rptGames_ItemCommand">
                <ItemTemplate>
                    <div class="col-md-4 mb-4">
                        <div class="card h-100 text-white">
                            <img src='<%# Eval("ImageUrl") %>' class="card-img-top" alt='<%# Eval("Title") %>' />
                            <div class="card-body bg-dark">
                                <h5 class="card-title"><%# Eval("Title") %></h5>
                                <p class="card-text"><%# Eval("Description") %></p>
                                <p class="text-success fw-bold">Price: $<%# Eval("Price") %></p>
                                <asp:Button runat="server" CssClass="btn btn-outline-info btn-sm me-2" Text="Add to Wishlist" CommandName="AddToWishlist" CommandArgument='<%# Eval("GameID") %>' />
                                <asp:Button runat="server" CssClass="btn btn-info btn-sm" Text="Add to Cart" CommandName="AddToCart" CommandArgument='<%# Eval("GameID") %>' />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
