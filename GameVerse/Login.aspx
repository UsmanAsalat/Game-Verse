<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GameVerse.Login" %>

<asp:Content ID="LoginContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-center align-items-center" style="min-height: 80vh;">
        <div class="bg-dark p-5 rounded shadow" style="width: 100%; max-width: 400px;">
            <h2 class="text-info text-center mb-4">🔐 Login</h2>

            <asp:Label ID="lblMessage" runat="server" CssClass="text-danger d-block text-center mb-3"></asp:Label>

            <div class="mb-3">
                <label class="form-label text-white">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter email" />
            </div>
            <div class="mb-3">
                <label class="form-label text-white">Password</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Enter password" />
            </div>
            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-info w-100" OnClick="btnLogin_Click" />
            <div class="text-center mt-3">
                <a href="Register.aspx" class="text-light">New user? Register here</a>
            </div>
        </div>
    </div>
</asp:Content>
