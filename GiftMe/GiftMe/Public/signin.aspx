<%@ Page Title="" Language="C#" MasterPageFile="~/Public/MasterPage.master" AutoEventWireup="true" CodeFile="signin.aspx.cs" Inherits="Public_signin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs">
        <div class="container">
            <ol class="breadcrumb breadcrumb1 animated wow slideInLeft animated" data-wow-delay=".5s" style="visibility: visible; animation-delay: 0.5s; animation-name: slideInLeft;">
                <li><a href="home.aspx"><span class="glyphicon glyphicon-home" aria-hidden="true"></span>Home</a></li>
                <li class="active">Account</li>
            </ol>
        </div>
    </div>
    <div class="account">
        <div class="container">
            <h2>Account</h2>
            <div class="account_grid">
                <div class="col-md-6 login-right">
                    <span>User Name</span>
                    <asp:TextBox ID="txtusername" runat="server" name="username" type="text" required="required" placeholder="User Name"></asp:TextBox>
                    <span>Password</span>
                    <asp:TextBox ID="txtPassword" runat="server" name="password" type="text" TextMode="Password" required="required" placeholder="Password"></asp:TextBox>
                    <div class="word-in">                        
                        <asp:Button ID="btnSubmit" runat="server" Text="Login"
                            type="submit" class="btn btn-1 btn-1d" OnClick="btnSubmit_Click" />
                        <asp:Label ID="lblerror1" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="col-md-6 login-left">
                    <h4>NEW CUSTOMERS</h4>
                    <p>Please register from here.</p>
                    <a class="acount-btn" href="signup.aspx">Create an Account</a>
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
</asp:Content>

