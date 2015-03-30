<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucApprovePaymentDetail.ascx.cs" Inherits="VloveImport.web.admin.UserControls.ucApprovePaymentDetail" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<fieldset style="width: 95%;">
    <legend>Transaction Detail</legend>
    <table>
        <tr>
            <td>Transaction Name :</td>
            <td>
                <asp:Label ID="lblDetail_TranName" runat="server"></asp:Label>
            </td>
            <td>Transaction Type :</td>
            <td>
                <asp:Label ID="lblDetail_TranType" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Transaction Date :</td>
            <td>
                <asp:Label ID="lblDetail_TranDate" runat="server"></asp:Label>
            </td>
            <td>Transaction Amount :</td>
            <td>
                <asp:Label ID="lblDetail_TranAmount" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Transaction Detail :</td>
            <td colspan ="3">
                <asp:Label ID="lblDetail_TranDetail" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Transaction Remark :</td>
            <td colspan ="3">
                <asp:Label ID="lblDetail_TranRemark" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Transaction Status :</td>
            <td>
                <asp:Label ID="lblDetail_TranStatus" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
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