﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Public/MasterPage.master" AutoEventWireup="true" CodeFile="productdetails.aspx.cs" Inherits="Public_productdetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs">
        <div class="container">
            <ol class="breadcrumb breadcrumb1 animated wow slideInLeft animated" data-wow-delay=".5s" style="visibility: visible; animation-delay: 0.5s; animation-name: slideInLeft;">
                <li><a href="home.aspx"><span class="glyphicon glyphicon-home" aria-hidden="true"></span>Home</a></li>
                <li class="active">Product Details</li>
            </ol>
        </div>
    </div>
    <div class="single">
        <div class="container">
            <div class="col-md-9">
                <div class="col-md-5 grid">
                    <div class="flexslider">
                        <ul class="slides">
                            <li data-thumb="images/si.jpg">
                                <div class="thumb-image">
                                    <asp:Label ID="lblitemid" runat="server" Visible="false"></asp:Label>
                                    <asp:Image ID="imgitem" runat="server" data-imagezoom="true" class="img-responsive" />
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="col-md-7 single-top-in">
                    <div class="single-para simpleCart_shelfItem">
                        <h2>
                            <label id="lblitemname" runat="server"></label>
                        </h2>
                        <p>
                            <label id="lblitemdetails" runat="server"></label>
                        </p>
                        <label id="lblitemprice" runat="server" class="add-to item_price"></label>
                       <%-- <a href="feedback.aspx" class="cart item_add">Contact</a>--%>
                    </div>
                </div>
                <div class="clearfix"></div>
            </div>
            <!----->
            <div class="col-md-3 product-bottom">
                <!--seller-->
                <div class="product-bottom" style="overflow: hidden; height: 400px;">
                    <h3 class="cate">Search Result</h3>
                    <marquee direction="down">
                    <asp:Repeater ID="DataList1" runat="server">
                        <ItemTemplate>
                            <div class="product-go">
                                <div class=" fashion-grid">
                                    <img class="img-responsive " src='<%# Eval("ImagePath") %>' alt="">
                                </div>
                                <div class=" fashion-grid1">
                                    <h6 class="best2"><%# Eval("ItemName") %> </h6>
                                    <span class=" price-in1">Rs. <%# Eval("ItemPrice") %></span>
                                </div>
                                <div class="clearfix"></div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                        </marquee>
                </div>

                <!--//seller-->
            </div>
            <div class="clearfix"></div>
        </div>
    </div>
    <script src="js/imagezoom.js"></script>
    <script defer src="js/jquery.flexslider.js"></script>
    <link rel="stylesheet" href="css/flexslider.css" type="text/css" media="screen" />

    <script>
        // Can also be used with $(document).ready()
        $(window).load(function () {
            $('.flexslider').flexslider({
                animation: "slide",
                controlNav: "thumbnails"
            });
        });
    </script>
    <!---pop-up-box---->
    <link href="css/popuo-box.css" rel="stylesheet" type="text/css" media="all" />
    <script src="js/jquery.magnific-popup.js" type="text/javascript"></script>
    <!---//pop-up-box---->
    <script>
        $(document).ready(function () {
            $('.popup-with-zoom-anim').magnificPopup({
                type: 'inline',
                fixedContentPos: false,
                fixedBgPos: true,
                overflowY: 'auto',
                closeBtnInside: true,
                preloader: false,
                midClick: true,
                removalDelay: 300,
                mainClass: 'my-mfp-zoom-in'
            });

        });
    </script>
</asp:Content>

