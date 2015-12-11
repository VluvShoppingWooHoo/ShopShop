<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucApprovePaymentDetail.ascx.cs" Inherits="VloveImport.web.admin.UserControls.ucApprovePaymentDetail" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register src="../UserControls/ucImage.ascx" tagname="ucImage" tagprefix="uc1" %>

<fieldset style="width: 95%;">
    <legend>
        Transaction Detail
    </legend>
    <table>
        <tr>
            <td class ="width20">Transaction Name : </td>
            <td class ="width30">
                <asp:Label ID="lblDetail_TranName" runat="server"></asp:Label>
            </td>
            <td class ="width20">Transaction Type : </td>
            <td class ="width30">
                <asp:Label ID="lblDetail_TranType" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Transaction Date : </td>
            <td>
                <asp:Label ID="lblDetail_TranDate" runat="server"></asp:Label>
            </td>
            <td>Transaction Amount :</td>
            <td>
                <asp:Label ID="lblDetail_TranAmount" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Transaction Status : </td>
            <td>
                <asp:Label ID="lblDetail_TranStatus" runat="server"></asp:Label>
            </td>
            <td>Transaction Picture : </td>
            <td>
                <asp:ImageButton ID="imbURL" runat="server" Width="30px" Height="40px" OnClick="imbURL_Click"/>
            </td>
        </tr>
        <tr>
            <td>Transaction Detail : </td>
            <td colspan ="3">
                <asp:Label ID="lblDetail_TranDetail" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Transaction Remark : </td>
            <td colspan ="3">
                <asp:Label ID="lblDetail_TranRemark" runat="server"></asp:Label>
            </td>
        </tr>
        <tr id = "trTransaction_Payment" runat ="server" visible ="false">
            <td>Payment Date : </td>
            <td>
                <asp:Label ID="lblDetail_PaymentDate" runat="server"></asp:Label>
            </td>
            <td>Bank Transfer : </td>
            <td>
                <asp:Label ID="lblDetail_BankTrasfer" runat="server"></asp:Label>
            </td>
        </tr>
        <tr id = "trTransaction_WithDraw" runat ="server" visible ="false">
            <td>Customer Bank Name : </td>
            <td colspan ="3">
                <asp:Label ID="lblDetail_Cus_Bank_Name" runat="server"></asp:Label>
            </td>
        </tr>
        <tr id = "trTransaction_Order" runat ="server" visible ="false">
            <td>Order ID : </td>
            <td>
                <asp:Label ID="lblDetail_Order_ID" runat="server"></asp:Label>
            </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>Employee Support :</td>
            <td>
                <asp:Label ID="lblDetail_EmpName" runat="server"></asp:Label>
            </td>
            <td>Employee Update Date :</td>
            <td>
                <asp:Label ID="lblDetail_EmpUpdateDate" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Employee Remark :</td>
            <td colspan ="3">
                <asp:Label ID="lblDetail_EmpRemark" runat="server"></asp:Label>
            </td>
        </tr> 
    </table>
</fieldset>

<fieldset style="width: 95%;">
    <legend>Customer Detail
    </legend>
    <table>
        <tr>
            <td>Customer Code</td>
            <td>
                <asp:Label ID="lbl_ViewDetail_CusCode" runat="server" Text=""></asp:Label>
            </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>ชื่อ - นามสกุล :</td>
            <td>
                <asp:Label ID="lbl_ViewDetail_CusName" runat="server" Text=""></asp:Label>
            </td>
            <td>เบอร์โทรศัพท์ :</td>
            <td>
                <asp:Label ID="lbl_ViewDetail_Telphone" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>จำนวนเงินในบัญชีคงเหลือ :</td>
            <td>
                <asp:Label ID="lbl_ViewDetail_Total_Amount" runat="server" Text=""></asp:Label>
            </td>
            <td>Email :</td>
            <td>
                <asp:Label ID="lbl_ViewDetail_Email" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</fieldset>
<asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modalBackground"
    PopupControlID="Panel1" TargetControlID="lbl_modal_view">
</asp:ModalPopupExtender>
<asp:Panel ID="Panel1" Height="600px" Width="900px" runat="server" Style="display: none;">
    <%--Style="display: none;"--%>
    <table width="800px" style="border-collapse: separate; border-spacing: 0px; height: 600px;" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td width="52px" height="43px" style="padding: 0px 0px;" class="trLogin_LEFT"></td>
            <td align="left" class="trLogin_CENTER" style="padding: 0px 0px;">
                <div style="margin-left: -40px; margin-top: 10px;">
                    <asp:Label ID="lbl_modal_view" runat="server" Text="Image"></asp:Label>
                </div>
            </td>
            <td align="right" width="52px" height="43px" style="padding: 0px 0px;" class="trLogin_RIGHT">
                <div style="text-align: right; margin-right: 10px; margin-top: 10px;">
                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/img/icon/Close.png" Width="20px" Height="20px" 
                        OnClick="ImageButton2_Click"/>
                </div>
            </td>
        </tr>
        <tr style="background-color: #CFCDCD;">
            <td style="text-align: center; padding: 0px 0px;" colspan="3">
                <center>
                    <asp:Panel Width="96%" Height="580px" ID="Panel6" runat="server" BackColor="#FFFFFF">
                        <br />
                            <uc1:ucImage ID="ucImage" runat="server" />                            
                    </asp:Panel>
                </center>
            </td>
        </tr>
        <tr style="background-color: #CFCDCD;">
            <td height="15px" style="padding: 0px 0px;" align="center" colspan="3"></td>
        </tr>
    </table>
</asp:Panel>