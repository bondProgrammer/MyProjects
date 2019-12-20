<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="graphuserwiseproductratings.aspx.cs" Inherits="Admin_graphuserwiseproductratings" %>

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
            <h2>user wise ratings</h2>
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
                                <asp:DropDownList ID="ddlusersearch" runat="server"
                                    class="form-control" data-toggle="tooltip" data-placement="bottom"
                                    title="Search user" AutoPostBack="true" Height="35px">
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
                    <asp:Chart ID="Chart1" runat="server" Width="800px">
                        <Legends>
                            <asp:Legend Alignment="Center" Docking="Left" IsTextAutoFit="true" Name="ProductName3" LegendStyle="Table" />
                        </Legends>
                        <Series>
                            <asp:Series Name="Series1" ChartType="Pie"
                                CustomProperties="PieLineColor=Black, PieLabelStyle=Outside">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                                <Area3DStyle Enable3D="True" Inclination="0" Rotation="0" />
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
</asp:Content>

