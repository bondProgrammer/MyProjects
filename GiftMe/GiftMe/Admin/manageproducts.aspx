<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="manageproducts.aspx.cs" Inherits="Admin_manageproducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="breadcrumbs">
        <div class="container">
            <ol class="breadcrumb breadcrumb1 animated wow slideInLeft animated" data-wow-delay=".5s" style="visibility: visible; animation-delay: 0.5s; animation-name: slideInLeft;">
                <li class="active">Manage Product Details</li>
            </ol>
        </div>
    </div>
    <div class="account">
        <div class="container">
            <h2>Sub Category Details</h2>
            <div class="account_grid">
                <div class="col-md-12 login-right">
                    <asp:Label ID="Label1" runat="server" CssClass="control-label" Font-Bold="true" Font-Size="Medium" Text=""></asp:Label>
                    <asp:Label ID="lblerrormsgfu" runat="server" CssClass="control-label" Font-Bold="true" Font-Size="Medium"></asp:Label>
                    <asp:Label ID="lblmsgu" runat="server" CssClass="control-label" Font-Bold="true" Font-Size="Medium"></asp:Label>
                    <asp:Label ID="lblmsgu1" runat="server" CssClass="control-label" Font-Bold="true" Font-Size="Medium"></asp:Label>
                    <hr />
                    <br />
                    <table style="width: 60%; height: auto;" class="table-responsive">
                        <tr>
                            <td>&nbsp;
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlcategorysearch" runat="server"
                                    class="form-control" data-toggle="tooltip" data-placement="bottom"
                                    title="Search category" AutoPostBack="true" Height="35px"
                                    OnSelectedIndexChanged="ddlcategorysearch_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlsearch" runat="server"
                                    class="form-control" data-toggle="tooltip" data-placement="bottom"
                                    title="Search sub category" AutoPostBack="true" Height="35px"
                                    OnSelectedIndexChanged="ddlsearch_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlitemsearch" runat="server"
                                    class="form-control" data-toggle="tooltip" data-placement="bottom"
                                    title="Search item" AutoPostBack="true" Height="35px">
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;
                            </td>
                            <td>
                                <asp:Button ID="btnsearch" runat="server"
                                    Text="Search" CssClass="btn btn-success" OnClick="btnsearch_Click" />
                            </td>
                        </tr>
                    </table>
                    <hr />
                    <br />
                    <asp:GridView ID="grvDetails" runat="server"
                        DataKeyNames="ItemId"
                        AutoGenerateColumns="false" TabIndex="4"
                        class="table table-bordered" AllowPaging="True" PageSize="5"
                        ShowFooter="true"
                        OnPageIndexChanging="grvDetails_PageIndexChanging"
                        OnRowCancelingEdit="grvDetails_RowCancelingEdit"
                        OnRowCommand="grvDetails_RowCommand"
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
                                    <asp:Button ID="btnAdd" class="btn btn-success" runat="server"
                                        Text="Add" OnClick="AddNew" ValidationGroup="add" />
                                </FooterTemplate>
                                <HeaderStyle HorizontalAlign="Center" Height="30px" />

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ID" Visible="false">

                                <ItemTemplate>
                                    <asp:Label ID="lblitemId" runat="server" Text='<%#Eval("ItemId") %>' />
                                </ItemTemplate>

                                <HeaderStyle HorizontalAlign="Center" Height="30px" />

                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Cat" Visible="false">

                                <ItemTemplate>
                                    <asp:Label ID="lblct" runat="server" Text='<%#Eval("CategoryId") %>' />
                                </ItemTemplate>

                                <HeaderStyle HorizontalAlign="Center" Height="30px" />

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SCat" Visible="false">

                                <ItemTemplate>
                                    <asp:Label ID="lblsct" runat="server" Text='<%#Eval("SubCategoryId") %>' />
                                </ItemTemplate>

                                <HeaderStyle HorizontalAlign="Center" Height="30px" />

                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Item">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtitem" runat="server" class="form-control"
                                        Text='<%#Eval("ItemName") %>' placeholder="Enter Item" />
                                    <asp:Label ID="lbliName" runat="server" Text="*" Font-Size="Medium"></asp:Label>

                                    <asp:RequiredFieldValidator ID="reqItem" runat="server"
                                        ErrorMessage="Please enter item " ControlToValidate="txtitem"
                                        ValidationGroup="edit" ForeColor="Red"></asp:RequiredFieldValidator>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblitem" runat="server" Text='<%#Eval("ItemName") %>' />
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtfitem" runat="server" class="form-control"
                                        Text='<%#Eval("ItemName") %>' placeholder="Enter Item" />
                                    <asp:Label ID="lbliName1" runat="server" Text="*" Font-Size="Medium"></asp:Label>

                                    <asp:RequiredFieldValidator ID="reqfItem" runat="server"
                                        ErrorMessage="Please enter item " ControlToValidate="txtfitem"
                                        ValidationGroup="add" ForeColor="Red"></asp:RequiredFieldValidator>
                                </FooterTemplate>
                                <HeaderStyle HorizontalAlign="Center" Height="30px" />

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Item Price">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtitemPrice" runat="server" class="form-control"
                                        Text='<%#Eval("ItemPrice") %>' placeholder="Enter Item Price" patthern="^\d+(\.\d{1,2})?$" />
                                    <asp:Label ID="lbliPrice" runat="server" Text="*" Font-Size="Medium"></asp:Label>
                                    <asp:RegularExpressionValidator ID="regiprice" runat="server"
                                        ErrorMessage="Enter Valid Amount" ControlToValidate="txtitemPrice"
                                        ValidationExpression="^\d+(\.\d{1,2})?$"
                                        ForeColor="Red" ValidationGroup="edit"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="reqIPrice" runat="server"
                                        ErrorMessage="Please enter item price" ControlToValidate="txtitemPrice"
                                        ValidationGroup="edit" ForeColor="Red"></asp:RequiredFieldValidator>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblitemprice" runat="server" Text='<%#Eval("ItemPrice") %>' />
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtfitemPrice" runat="server" class="form-control"
                                        Text='<%#Eval("ItemPrice") %>' placeholder="Enter Item Price" patthern="^\d+(\.\d{1,2})?$" />
                                    <asp:Label ID="lbliPrice1" runat="server" Text="*" Font-Size="Medium"></asp:Label>
                                    <asp:RegularExpressionValidator ID="regfiprice" runat="server"
                                        ErrorMessage="Enter Valid Amount" ControlToValidate="txtfitemPrice"
                                        ValidationExpression="^\d+(\.\d{1,2})?$"
                                        ForeColor="Red" ValidationGroup="add"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="reqfIPrice" runat="server"
                                        ErrorMessage="Please enter item price" ControlToValidate="txtfitemPrice"
                                        ValidationGroup="add" ForeColor="Red"></asp:RequiredFieldValidator>
                                </FooterTemplate>
                                <HeaderStyle HorizontalAlign="Center" Height="30px" />

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Image">

                                <EditItemTemplate>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:Image ID="img1" runat="server" ImageUrl='<%# Eval("ImagePath") %>'
                                                Height="50" Width="50" />
                                            <asp:FileUpload ID="fu" runat="server" data-toggle="tooltip"
                                                data-placement="bottom" title="Upload Image" />
                                            <asp:Button ID="btnup" runat="server" Text="Upload"
                                                class="btn btn-primary btn-label-left"
                                                CommandArgument='<%#DataBinder.Eval(Container, "DataItemIndex")%>'
                                                CommandName="up" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnup" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Image ID="img1" runat="server" ImageUrl='<%# Eval("ImagePath") %>'
                                        Height="70" Width="70" />
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <asp:Image ID="imgf1" runat="server" ImageUrl='<%# Eval("ImagePath") %>'
                                                Height="50" Width="50" />
                                            <asp:FileUpload ID="ffu" runat="server" data-toggle="tooltip"
                                                data-placement="bottom" title="Upload Image" />
                                            <asp:Button ID="btnfup" runat="server" Text="Upload"
                                                class="btn btn-primary btn-label-left"
                                                CommandArgument='<%#DataBinder.Eval(Container, "DataItemIndex")%>'
                                                CommandName="fup" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnfup" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </FooterTemplate>
                                <HeaderStyle HorizontalAlign="Center" Height="30px" />

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Image Path" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblip" runat="server" Text='<%# Eval("ImagePath") %>'></asp:Label>
                                </ItemTemplate>

                                <HeaderStyle HorizontalAlign="Center" Height="30px" />

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Image Name" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblin" runat="server" Text='<%# Eval("ImageName") %>'></asp:Label>
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
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
</asp:Content>

