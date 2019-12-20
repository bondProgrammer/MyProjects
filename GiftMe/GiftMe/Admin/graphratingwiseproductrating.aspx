<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="graphratingwiseproductrating.aspx.cs" Inherits="Admin_graphratingwiseproductrating" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="breadcrumbs">
        <div class="container">
            <ol class="breadcrumb breadcrumb1 animated wow slideInLeft animated" data-wow-delay=".5s" style="visibility: visible; animation-delay: 0.5s; animation-name: slideInLeft;">
                <li class="active">Graphs</li>
            </ol>
        </div>
    </div>
    <div class="account">
        <div class="container">
            <h2>Rating wise items</h2>
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
                                <asp:DropDownList ID="ddlratingsearch" runat="server"
                                    class="form-control" data-toggle="tooltip" data-placement="bottom"
                                    title="Search rating" AutoPostBack="true" Height="35px">
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
                        AutoGenerateColumns="false" TabIndex="4"
                        class="table table-bordered" AllowPaging="True" PageSize="5"
                        ShowFooter="true"
                        OnPageIndexChanging="grvDetails_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="Item">
                                <ItemTemplate>
                                    <asp:Label ID="lblItemName" runat="server" Text='<%#Eval("ItemName") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Height="30px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Rating">
                                <ItemTemplate>
                                    <asp:Label ID="lblrating" runat="server" Text='<%#Eval("ratings") %>' />
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

