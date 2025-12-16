<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="GameVerse.Register" %>

<asp:Content ID="RegisterContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-center align-items-center" style="min-height: 80vh;">
        <div class="bg-dark p-5 rounded shadow" style="width: 100%; max-width: 400px;">
            <h2 class="text-info text-center mb-4">📝 Register</h2>

            <asp:Label ID="lblMessage" runat="server" CssClass="text-success d-block text-center mb-3"></asp:Label>

            <div class="mb-3">
                <label class="form-label text-white">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter email" />
            </div>
            <div class="mb-3">
                <label class="form-label text-white">Password</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Create password" />
            </div>
            <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn btn-outline-info w-100" OnClick="btnRegister_Click" />
        </div>
    </div>
</asp:Content>
