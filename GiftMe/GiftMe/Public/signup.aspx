<%@ Page Title="" Language="C#" MasterPageFile="~/Public/MasterPage.master" AutoEventWireup="true" CodeFile="signup.aspx.cs" Inherits="Public_signup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs">
        <div class="container">
            <ol class="breadcrumb breadcrumb1 animated wow slideInLeft animated" data-wow-delay=".5s" style="visibility: visible; animation-delay: 0.5s; animation-name: slideInLeft;">
                <li><a href="home.aspx"><span class="glyphicon glyphicon-home" aria-hidden="true"></span>Home</a></li>
                <li class="active">Register</li>
            </ol>
        </div>
    </div>
    <div class="container">
        <div class="register">
            <h2>Register</h2>
            <div class="col-md-6  register-top-grid">
                <div class="mation">
                    <span>Full Name</span>
                    <asp:TextBox ID="txtName" runat="server" name="fullname" type="text" required="required" placeholder="Full Name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqname" runat="server"
                        ErrorMessage="Please enter name " ControlToValidate="txtName"
                        ValidationGroup="save" ForeColor="Red"></asp:RequiredFieldValidator>
                    <span>Mobile No</span>
                    <asp:TextBox ID="txtMobile" runat="server" name="phonenumber" type="text" required="required" placeholder="Mobile No"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="reqmobile" runat="server"
                        ErrorMessage="Please enter mobile no " ControlToValidate="txtMobile"
                        ValidationGroup="save" ForeColor="Red"></asp:RequiredFieldValidator>
                    <span>Email Address</span>
                    <asp:TextBox ID="txtEmail" runat="server" name="email" type="text" required="required" placeholder="Email Id"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqemail" runat="server"
                        ErrorMessage="Please enter email id " ControlToValidate="txtEmail"
                        ValidationGroup="save" ForeColor="Red"></asp:RequiredFieldValidator>
                    <span>Gender</span>
                    <asp:RadioButton ID="rbtnmale" runat="server" GroupName="gen" Text="Male" />&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="rbtnfemale" runat="server" GroupName="gen" Text="Female" />
                    <br />
                    <br />
                    <span>Age</span>
                    <asp:DropDownList ID="ddlage" runat="server" Width="100%" Height="40">
                    </asp:DropDownList>
                    <br />
                    <br />
                    <span>Education</span>
                    <asp:DropDownList ID="ddleducation" runat="server" Width="100%" Height="40">
                    </asp:DropDownList>
                    <br />
                    <br />
                    <span>Profession</span>
                    <asp:DropDownList ID="ddlprofession" runat="server" Width="100%" Height="40">
                    </asp:DropDownList>
                </div>
                <div class="clearfix"></div>
            </div>
            <div class=" col-md-6 register-bottom-grid">
                <div class="mation">
                    <span>Password</span>
                    <asp:TextBox ID="txtpassword" runat="server" name="password" TextMode="Password" type="password" required="required" placeholder="Password"></asp:TextBox>
                    <br />
                    <br />
                    <span>Confirm Password</span>
                    <asp:TextBox ID="txtconfirmpassword" runat="server" name="password" TextMode="Password" type="password" required="required" placeholder="Confirm Password"></asp:TextBox>
                    <asp:CompareValidator ID="comv" runat="server" ErrorMessage="Password not match" 
                        ControlToCompare="txtpassword" ControlToValidate="txtconfirmpassword"></asp:CompareValidator>
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="register-but">
                <asp:Button ID="btnSubmit" runat="server" Text="Register"
                    type="submit" class="btn btn-1 btn-1d" OnClick="btnSubmit_Click" />
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
</asp:Content>

