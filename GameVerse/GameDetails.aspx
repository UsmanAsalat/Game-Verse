<%@ Page Title="Game Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GameDetails.aspx.cs" Inherits="GameVerse.GameDetails" %>

<asp:Content ID="GameDetailContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container my-5">
        <div class="row">
            <!-- Game Image -->
            <div class="col-md-5 mb-4">
                <img src="https://upload.wikimedia.org/wikipedia/en/a/a7/God_of_War_4_cover.jpg" class="img-fluid rounded shadow" alt="God of War" />
            </div>

            <!-- Game Details -->
            <div class="col-md-7">
                <h2 class="text-info">God of War</h2>
                <p class="lead text-light">
                    Embark on an epic Norse adventure with Kratos and his son Atreus. Face mythological beasts, solve puzzles, and explore stunning landscapes in this critically acclaimed action game.
                </p>
                <p class="text-muted">Genre: Action-Adventure</p>
                <p class="text-success h5">Price: $49.99</p>
                <button class="btn btn-info me-2">Add to Cart</button>
                <button class="btn btn-outline-info">Add to Wishlist</button>
            </div>
        </div>

        <!-- Reviews Section -->
        <hr class="text-secondary mt-5" />
        <h4 class="text-warning">⭐ Recent Reviews</h4>

        <div class="bg-dark p-3 rounded mb-3">
            <strong class="text-white">Usman Malik</strong>
            <p class="text-light mb-1">“One of the best storylines I’ve played. Totally worth it.”</p>
            <small class="text-muted">Rated: ★★★★★</small>
        </div>

        <div class="bg-dark p-3 rounded">
            <strong class="text-white">Areeba Khan</strong>
            <p class="text-light mb-1">“Great graphics and intense combat. A bit hard in boss fights.”</p>
            <small class="text-muted">Rated: ★★★★☆</small>
        </div>
    </div>
</asp:Content>
