<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CustomerChangePassword.aspx.cs" Inherits="VloveImport.web.Customer.CustomerChangePassword" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col s12 m12 l12">
            <div style = "border:2px solid #B7B2AF; background-color:#B7B2AF; vertical-align :middle; width:30%; height:50px;">
                <br />
                <div style ="margin-left:10px;">
                    <b>เลือก I LOVE IMPORT ธนาคาร</b>                                        
                </div>
            </div>
            <div style = "vertical-align :middle; width:40%; height:50px; margin-left: 32%; margin-top: -40px;">            
                <div style ="margin-left:10px;">
                    <asp:DropDownList ID="ddlBank" DataTextField="BANK_SHOP_ACCOUNT_NO" DataValueField="BANK_SHOP_ID" runat="server" 
                    CssClass="dpBlock ddlBank" Width="300px"></asp:DropDownList>
                </div>
            </div>
        </div>
    </div>



    <script type="text/javascript">       
    </script>
</asp:Content>
