<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="colaborativefiltering.aspx.cs" Inherits="User_colaborativefiltering" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs">
        <div class="container">
            <ol class="breadcrumb breadcrumb1 animated wow slideInLeft animated" data-wow-delay=".5s" style="visibility: visible; animation-delay: 0.5s; animation-name: slideInLeft;">
                <li><a href="home.aspx"><span class="glyphicon glyphicon-home" aria-hidden="true"></span>Home</a></li>
                <li class="active">Products</li>
            </ol>
        </div>
    </div>
    <!--content-->
    <div class="products">
        <div class="container">
            <h2>Products</h2>
            <div class="col-md-12">
                <div class="content-top1">
                    <asp:Label ID="lblmsgu" runat="server" CssClass="control-label" Font-Bold="true" Font-Size="Medium"></asp:Label>
                    <asp:Label ID="lblmsgu1" runat="server" CssClass="control-label" Font-Bold="true" Font-Size="Medium"></asp:Label>
                    <hr />
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
                </div>
            </div>
            <div class="col-md-12">
                <div class="content-top1">                    
                    <asp:Repeater ID="DataList1" runat="server">
                        <ItemTemplate>
                            <div class="col-md-4 col-md4">
                                <div class="col-md1 simpleCart_shelfItem">
                                    <a href='<%# string.Format("productdetails.aspx?{0}", Eval("ItemId")) %>'>
                                        <img class="img-responsive" src='<%# Eval("ImagePath") %>' alt="" />
                                    </a>
                                    <h3><a href="#"><%# Eval("ItemName") %></a></h3>
                                    <div class="price">
                                        <h5 class="item_price">Rs.<%# Eval("ItemPrice") %></h5>
                                        <a href="#" class="item_add">Contact Us</a>
                                        <div class="clearfix"></div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div class="clearfix"></div>
                </div>
            </div>
            <div class="clearfix"></div>
        </div>
    </div>
    <!--//content-->
</asp:Content>