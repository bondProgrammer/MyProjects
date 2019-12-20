<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="managesubcategory.aspx.cs" Inherits="Admin_managesubcategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="breadcrumbs">
        <div class="container">
            <ol class="breadcrumb breadcrumb1 animated wow slideInLeft animated" data-wow-delay=".5s" style="visibility: visible; animation-delay: 0.5s; animation-name: slideInLeft;">
                <li class="active">Manage Sub Category Details</li>
            </ol>
        </div>
    </div>

    <div class="account">
        <div class="container">
            <h2>Sub Category Details</h2>
            <div class="account_grid">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="col-md-6 login-right">
                            <span>Category Name</span>
                            <asp:DropDownList ID="ddlcategoryi" runat="server"
                                data-toggle="tooltip" data-placement="bottom"
                                title="Select category" AutoPostBack="true" CssClass="form-control">
                            </asp:DropDownList>
                            <span>Sub Category Name</span>
                            <asp:TextBox ID="txtsubcategory" runat="server"
                                name="subcategory" type="text" placeholder="Sub Category Name"></asp:TextBox>
                            <div class="word-in">
                                <asp:Button ID="btnSubmit" runat="server" Text="Save"
                                    type="submit" class="btn btn-1 btn-1d" OnClick="btnSubmit_Click" />
                                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                            </div>
                        </div>

                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnSubmit" />
                    </Triggers>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="col-md-6 login-left">
                            <h4>Edit/Delete Sub Category</h4>
                            <asp:GridView ID="grvDetails" runat="server"
                                DataKeyNames="SubCategoryId"
                                AutoGenerateColumns="false" Width="98%" TabIndex="4"
                                class="table table-bordered" AllowPaging="True" PageSize="5"
                                OnPageIndexChanging="grvDetails_PageIndexChanging"
                                OnRowCancelingEdit="grvDetails_RowCancelingEdit"
                                OnRowDataBound="grvDetails_RowDataBound"
                                OnRowDeleting="grvDetails_RowDeleting"
                                OnRowEditing="grvDetails_RowEditing"
                                OnRowUpdating="grvDetails_RowUpdating">
                                <Columns>
                                    <asp:TemplateField HeaderText="Edit/Delete">
                                        <EditItemTemplate>
                                            <asp:Button ID="btnupdate" runat="server" Text="Update" class="btn btn-success" CommandName="Update" />
                                            <asp:Button ID="btncancel" runat="server" Text="Cancel" class="btn btn-success" CommandName="Cancel" />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Button ID="btnedit" runat="server" Text="Edit" class="btn btn-success" CommandName="Edit" ValidationGroup="edit" />
                                            <asp:Button ID="btndelete" runat="server" Text="Delete" class="btn btn-success" CommandName="Delete"
                                                OnClientClick="return confirm('Are you sure you want to delete this entry?');" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Height="30px" />
                                        <ItemStyle Width="80px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID" Visible="false">

                                        <ItemTemplate>
                                            <asp:Label ID="lblsubCategoryId" runat="server" Text='<%#Eval("SubCategoryId") %>' />
                                        </ItemTemplate>

                                        <HeaderStyle HorizontalAlign="Center" Height="30px" />
                                        <ItemStyle Width="80px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Category">
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddlcategory" runat="server"
                                                class="form-control" data-toggle="tooltip" data-placement="bottom"
                                                title="Search category" Height="35px" Width="45%">
                                            </asp:DropDownList>
                                            <asp:Label ID="lblmcName" runat="server" Text="*" Font-Size="Medium"></asp:Label>

                                            <asp:RequiredFieldValidator ID="reqCategory" runat="server"
                                                ErrorMessage="Please select category " ControlToValidate="ddlcategory"
                                                ValidationGroup="edit" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblcategory" runat="server" Text='<%#Eval("CategoryName") %>' />
                                        </ItemTemplate>

                                        <HeaderStyle HorizontalAlign="Center" Height="30px" />
                                        <ItemStyle Width="80px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sub Category">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtsubCategory" runat="server" class="form-control"
                                                Text='<%#Eval("SubCategory") %>' placeholder="Enter Sub Category" />
                                            <asp:Label ID="lblscName" runat="server" Text="*" Font-Size="Medium"></asp:Label>

                                            <asp:RequiredFieldValidator ID="reqSubCategory" runat="server"
                                                ErrorMessage="Please enter sub category " ControlToValidate="txtsubCategory"
                                                ValidationGroup="edit" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblsubCategory" runat="server" Text='<%#Eval("SubCategory") %>' />
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
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="grvDetails" />
                    </Triggers>
                </asp:UpdatePanel>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>

</asp:Content>
