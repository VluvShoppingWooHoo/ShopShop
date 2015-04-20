<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="VloveImport.web.Customer.ContactUs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="../UserControls/ucEmail.ascx" TagName="ucEmail" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="s12 m12 l12">
            <asp:UpdatePanel ID="updatePanel" runat="server">
                <ContentTemplate>
                    <span class="bold">Mobile</span> : 087-435-3118, 092-672-8160 
                    <span class="oblique"></span><br />
                    <br />
                    (PWT trading) Phannee World Trading Co.,Ltd
                    <br />
                    Contract us : Wechat : arbow123 ,Line ID : arbow123 , QQ ID : 1484258255<br />
                    Tel ; 087-4353118 , 088-3264117, 092-6728160<br />
                    E-Maill : info@iloveimport.com &nbsp;
                    <asp:ImageButton ID="imgbtn_SendEmail" runat="server" ImageUrl="~/images/icon/sendemail.png" Width="45px" Height="35px" OnClick="imgbtn_SendEmail_Click" />
                    <br />
                    <br />

                    <span class="bold">วันทำงาน   จันทร์ –ศุกร์ 10.00 - 20.00
                    <br />
                        เสาร์   10.00-12.00 AM<br />
                    </span>
                    ที่อยู่ในการรับสินค้า ซอยโชคชัย4 ถนนลาดพร้าว กทม 10230<br />
                    <br />

                    <div class="row">
                        <div class="s12 m12 l12 ContentTitle">
                            ติดต่อโกดังที่ไทย
                        </div>

                        +6687-4353118
                        <br />
                        +6688-3264117<br />
                        <br />
                    </div>
                    <div class="row">
                        <div class="s12 m12 l12 ContentTitle">
                            ติดต่อโกดังที่จีน
                        </div>
                        +8615017510371<br />
                        +8618523502489<br />
                    </div>

                    <asp:ModalPopupExtender ID="MadoalPop_Email" runat="server" BackgroundCssClass="modalBackground"
                        PopupControlID="Panel1" TargetControlID="lbl_modal_email">
                    </asp:ModalPopupExtender>
                    <asp:Panel ID="Panel1" Height="600px" Width="800px" runat="server" Style="display: none;">
                        <%--Style="display: none;"--%>
                        <table width="800px" style="border-collapse: separate; border-spacing: 0px; height:550px;" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td width="52px" height="43px" style="padding: 0px 0px;" class="trLogin_LEFT"></td>
                                <td align="left" class="trLogin_CENTER" style="padding: 0px 0px;">
                                    <div style="margin-left: -40px; margin-top: 10px;">
                                        <asp:Label ID="lbl_modal_email" runat="server" Text="Send Email"></asp:Label>
                                    </div>
                                </td>
                                <td align="right" width="52px" height="43px" style="padding: 0px 0px;" class="trLogin_RIGHT">
                                    <div style="text-align: right; margin-right: 10px; margin-top: 10px;">
                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/icon/Close.png" Width="20px" Height="20px" />
                                    </div>
                                </td>
                            </tr>
                            <tr style="background-color: #CFCDCD;">
                                <td style="text-align: center; padding: 0px 0px;" colspan="3">
                                    <center>
                                    <asp:Panel Width="96%" Height="550px" ID="Panel2" runat="server" BackColor="#FFFFFF">
                                         <br />
                                         <uc1:ucEmail ID="ucEmail1" runat="server" />                 
                                    </asp:Panel>
                                </center>
                                </td>
                            </tr>
                            <tr style="background-color: #CFCDCD;">
                                <td height="15px" style="padding: 0px 0px;" align="center" colspan="3"></td>
                            </tr>
                        </table>
                    </asp:Panel>
                    </ContentTemplate>       
            </asp:UpdatePanel>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            SetFadeout();
        });
    </script>
</asp:Content>
