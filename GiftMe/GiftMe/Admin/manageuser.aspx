<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="manageuser.aspx.cs" Inherits="Admin_manageuser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs">
        <div class="container">
            <ol class="breadcrumb breadcrumb1 animated wow slideInLeft animated" data-wow-delay=".5s" style="visibility: visible; animation-delay: 0.5s; animation-name: slideInLeft;">
                <li class="active">Manage User Details</li>
            </ol>
        </div>
    </div>
    <div class="account">
        <div class="container">
            <h2>User Details</h2>
            <div class="account_grid">
                <div class="col-md-12 login-right">
                    <br />
                    <asp:Label ID="lblmsgu" runat="server" CssClass="control-label" Font-Bold="true" Font-Size="Medium"></asp:Label>
                    <asp:Label ID="lblmsgu1" runat="server" CssClass="control-label" Font-Bold="true" Font-Size="Medium"></asp:Label>
                    <br />
                    <asp:GridView ID="grvDetails" runat="server"
                        DataKeyNames="UserId"
                        AutoGenerateColumns="false" TabIndex="4" Width="100%"
                        class="table table-bordered" AllowPaging="True" PageSize="5"
                        ShowFooter="true"
                        OnPageIndexChanging="grvDetails_PageIndexChanging"
                        OnRowDeleting="grvDetails_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:Button ID="btndelete" runat="server" Text="Delete" class="btn btn-success"
                                        CommandName="Delete"
                                        OnClientClick="return confirm('Are you sure you want to delete this entry?');" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Height="30px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserId" runat="server" Text='<%#Eval("UserId") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Height="30px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="User Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserName" runat="server" Text='<%#Eval("UserName") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Height="30px" />
                                <ItemStyle Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="User Mobile">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserMobile" runat="server" Text='<%#Eval("UserMobile") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Height="30px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="User Email">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserEmail" runat="server" Text='<%#Eval("UserEmail") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Height="30px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="User State">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserState" runat="server" Text='<%#Eval("UserState") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Height="30px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="User City">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserCity" runat="server" Text='<%#Eval("UserCity") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Height="30px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Gender">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserGender" runat="server" Text='<%#Eval("UserGender") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Height="30px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Education">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserEducation" runat="server" Text='<%#Eval("UserEducation") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Height="30px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Profession">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserProfession" runat="server" Text='<%#Eval("UserProfession") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Height="30px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Age">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserAge" runat="server" Text='<%#Eval("UserAge") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Height="30px" />
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="White" BorderStyle="None" />
                        <HeaderStyle Height="30px" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <PagerSettings Mode="NumericFirstLast" />
                        <PagerStyle HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="#0066CC"
                            Height="25px" Width="25px" />
                        <RowStyle HorizontalAlign="Justify" VerticalAlign="Middle" BorderStyle="None" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

