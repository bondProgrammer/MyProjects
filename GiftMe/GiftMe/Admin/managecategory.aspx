<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="managecategory.aspx.cs" Inherits="Admin_managecategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs">
        <div class="container">
            <ol class="breadcrumb breadcrumb1 animated wow slideInLeft animated" data-wow-delay=".5s" style="visibility: visible; animation-delay: 0.5s; animation-name: slideInLeft;">
                <li class="active">Manage Category Details</li>
            </ol>
        </div>
    </div>
    <div class="account">
        <div class="container">
            <h2>Category Details</h2>
            <div class="account_grid">
                <div class="col-md-6 login-right">
                    <span>Category Name</span>
                    <asp:TextBox ID="txtcategory" runat="server" name="category" type="text" placeholder="Category Name"></asp:TextBox>
                    <div class="word-in">
                        <asp:Button ID="btnSubmit" runat="server" Text="Save"
                            type="submit" class="btn btn-1 btn-1d" OnClick="btnSubmit_Click" />
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="col-md-6 login-left">
                    <h4>Edit/Delete Category</h4>
                      <asp:GridView ID="grvDetails" runat="server"
                                        DataKeyNames="CategoryId"
                                        AutoGenerateColumns="false" Width="98%" TabIndex="4"
                                        class="table table-bordered" AllowPaging="True" PageSize="5"
                                        OnPageIndexChanging="grvDetails_PageIndexChanging"
                                        OnRowCancelingEdit="grvDetails_RowCancelingEdit"
                                        OnRowDeleting="grvDetails_RowDeleting"
                                        OnRowEditing="grvDetails_RowEditing"
                                        OnRowUpdating="grvDetails_RowUpdating">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Edit/Delete">
                                                <EditItemTemplate>
                                                    <asp:Button ID="btnupdate" runat="server" Text="Update" class="btn btn-success" 
                                                        CommandName="Update" />
                                                    <asp:Button ID="btncancel" runat="server" Text="Cancel" class="btn btn-success" 
                                                        CommandName="Cancel" />
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Button ID="btnedit" runat="server" Text="Edit" class="btn btn-success" 
                                                        CommandName="Edit" ValidationGroup="edit" />
                                                    <asp:Button ID="btndelete" runat="server" Text="Delete" class="btn btn-success" 
                                                        CommandName="Delete"
                                                        OnClientClick="return confirm('Are you sure you want to delete this entry?');" />
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Height="30px" />
                                                <ItemStyle Width="80px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblcategoryId" runat="server" Text='<%#Eval("CategoryId") %>' />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Height="30px" />
                                                <ItemStyle Width="80px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Category">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtcategory" runat="server" class="form-control"
                                                        Text='<%#Eval("CategoryName") %>' placeholder="Enter Category" />
                                                    <asp:Label ID="lblcName" runat="server" Text="*" Font-Size="Medium"></asp:Label>
                                                    <asp:RequiredFieldValidator ID="reqCategory" runat="server"
                                                        ErrorMessage="Please enter category " ControlToValidate="txtcategory"
                                                        ValidationGroup="edit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblcategory" runat="server" Text='<%#Eval("CategoryName") %>' />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Height="30px" />
                                                <ItemStyle Width="80px" />
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
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
</asp:Content>

