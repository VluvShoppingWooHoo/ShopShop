﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="frmApprovePayment.aspx.cs" Inherits="VloveImport.web.admin.pages.frmApprovePayment" %>

<%@ Register Src="../UserControls/ucCalendar.ascx" TagName="ucCalendar" TagPrefix="uc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <%--<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>--%>

            <fieldset style="width: 98.5%;">
                <legend>Search Criteria</legend>
                <table style="border: 1 solid;">
                    <tr>
                        <td class="width15">
                            <asp:Label ID="Label2" runat="server" Text="Transaction Status"></asp:Label>
                        </td>
                        <td class="width35">
                            <asp:DropDownList ID="ddlTranSactionStatus" runat="server"></asp:DropDownList>
                        </td>
                        <td class="width15">
                            <asp:Label ID="Label1" runat="server" Text="Transaction Date :"></asp:Label>
                        </td>
                        <td class="width35">
                            <uc1:ucCalendar ID="ucCalendar1" runat="server" />
                            &nbsp;-&nbsp;
                            <uc1:ucCalendar ID="ucCalendar2" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label4" runat="server" Text="Transaction Type :"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="ddlTranSactionType" runat="server">
                                <asp:ListItem Value="-1">แสดงทั้งหมด</asp:ListItem>
                                <asp:ListItem Value="1">รายการเงินเข้า</asp:ListItem>
                                <asp:ListItem Value="2">รายการเงินออก</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Customer Code :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCusCode" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="text-align: center;">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btnSearch" OnClick="btnSearch_Click" />&nbsp;&nbsp;
                            <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btnCancel" OnClick="btnReset_Click" />
                        </td>
                    </tr>
                </table>
            </fieldset>
            <table>
                <tr>
                    <td style="text-align: left;">
                        <asp:Label ID="lblResult" runat="server" Text="<b>Result Data</b>"></asp:Label>
                    </td>
                    <td style="text-align: right;">
                        <asp:Button ID="btnSelectOrder" runat="server" Text="ดูรายการที่เลือก" CssClass="btnCancel" Visible ="false" OnClick="btnSelectOrder_Click" />
                    </td>
                </tr>
            </table>
            <asp:GridView ID="gv_detail" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" Width="100%"
                DataKeyNames="ORDER_ID,ORDER_DATE_TEXT,CUS_FULLNAME,ORDER_STATUS_TEXT,EMP_NAME,SUM_PROD_PRICE,CUS_CODE,ORDER_CODE,TRANSPORT_STATUS_TEXT,SUM_PROD_PRICE_ACTIVE,ORDER_STATUS">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="imgBtn_choose" runat="server" Height="20px" ImageUrl="~/img/icon/nxt-checkbox-checked-ok-md.png" Width="20px" OnClick="imgBtn_choose_Click" />
                            <asp:ImageButton ID="imgBtn_cancel_choose" runat="server" Height="20px" ImageUrl="~/img/icon/nxt-checkbox-checked-not-ok-md.png" Width="20px" Visible="false" OnClick="imgBtn_cancel_choose_Click" />
                        </ItemTemplate>
                        <HeaderStyle CssClass="width5" />
                        <ItemStyle CssClass="ItemStyle-center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="ROW_INDEX" HeaderText="No.">
                        <HeaderStyle CssClass="width5" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TRAN_DATE_TEXT" HeaderText="Transaction Date">
                        <HeaderStyle CssClass="width10" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ORDER_DATE_TEXT" HeaderText="Transaction Type">
                        <HeaderStyle CssClass="width15" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ORDER_DATE_TEXT" HeaderText="Transaction Name">
                        <HeaderStyle CssClass="width15" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CUS_CODE" HeaderText="CustomerCode">
                        <HeaderStyle CssClass="width10" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ORDER_STATUS_TEXT" HeaderText="Order Status">
                        <HeaderStyle CssClass="width15" />
                    </asp:BoundField>
                    <asp:BoundField DataField="EMP_NAME" HeaderText="Employee Name">
                        <HeaderStyle CssClass="width15" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SUM_PROD_PRICE_ACTIVE" DataFormatString="{0:#,##0.00}" HeaderText="Total Amount">
                        <HeaderStyle CssClass="width10" />
                        <ItemStyle CssClass="ItemStyle-right" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Tools">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgBtn_view" runat="server" ImageUrl="~/img/icon/View.png" Width ="25px" Height ="25px" OnClick="imgBtn_view_Click"/>
                        </ItemTemplate>
                        <HeaderStyle CssClass="width5" />
                        <ItemStyle CssClass="ItemStyle-center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>


            <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modalBackground"
                PopupControlID="Panel1" TargetControlID="lblheader">
            </asp:ModalPopupExtender>

            <asp:Panel ID="Panel1" Height="700px" Width="1200px" runat="server">
                <%--Style="display: none;"--%>
                <table width="800px" style="border-collapse: separate; border-spacing: 0px" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td width="52px" height="43px" style="padding: 0px 0px;" class="trLogin_LEFT"></td>
                        <td align="left" class="trLogin_CENTER" style="padding: 0px 0px;">
                            <div style="margin-left: -40px; margin-top: 10px;">
                                <asp:Label ID="lblheader" runat="server" Text="รายการที่เลือก"></asp:Label>
                            </div>
                        </td>
                        <td align="right" width="52px" height="43px" style="padding: 0px 0px;" class="trLogin_RIGHT">
                            <div style="text-align: right; margin-right: 10px; margin-top: 10px;">
                                <asp:ImageButton ID="BtnImgClose" runat="server" ImageUrl="~/img/icon/Close.png" Width="20px" Height="20px" OnClick="BtnImgClose_Click" />
                            </div>
                        </td>
                    </tr>
                    <tr style="background-color: #CFCDCD;">
                        <td style="text-align: center; padding: 0px 0px;" colspan="3">
                            <center>
                            <asp:Panel Width="96%" Height="550px" ID="Panel2" runat="server" BackColor="#FFFFFF" ScrollBars="Vertical">
                                <br />
                                <fieldset style ="width:95%;">
                                    <legend>
                                        รายการที่เลือก การจัดการสถานะของการสั่งซื้อ
                                    </legend>
                                        <table>
                                            <tr>
                                                <td width ="15%">สถานะ :</td>
                                                <td width ="85%">
                                                    <asp:DropDownList ID="ddl_choose_status_order" runat="server" AutoPostBack="True">
                                                        <asp:ListItem Value="-1">กรุณาเลือก</asp:ListItem>
                                                        <asp:ListItem Value="1">สถานะการสั่งซื้อ</asp:ListItem>
                                                        <asp:ListItem Value="2">สถานะการส่งสินค้า</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>สถานะที่ต้องการแก้ไข :</td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_choose_sub_status" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td>
                                                    <asp:Button ID="btnUpdateStatus" runat="server" Text="Update Status" CssClass ="btnSave"></asp:Button>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                    <asp:GridView ID="gv_detail_view" runat="server" AutoGenerateColumns="False" Width="95%"
                                        DataKeyNames="ORDER_ID,ORDER_DATE_TEXT,CUS_FULLNAME,ORDER_STATUS_TEXT,EMP_NAME,SUM_PROD_PRICE,CUS_CODE,ORDER_CODE,TRANSPORT_STATUS_TEXT,SUM_PROD_PRICE_ACTIVE,ORDER_STATUS">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgBtn_gv_view_delete" runat="server" Height="20px" ImageUrl="~/img/icon/nxt-checkbox-checked-not-ok-md.png" Width="20px" />
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="width5" />
                                                <ItemStyle CssClass="ItemStyle-center" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ROW_INDEX" HeaderText="No." >
                                            <HeaderStyle CssClass="width5" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ORDER_CODE" HeaderText="OrderCode" >
                                            <HeaderStyle CssClass="width10" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ORDER_DATE_TEXT" HeaderText="Order Date" >
                                            <HeaderStyle CssClass="width15" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CUS_CODE" HeaderText="CustomerCode" >
                                            <HeaderStyle CssClass="width15" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ORDER_STATUS_TEXT" HeaderText="Order Status" >
                                            <HeaderStyle CssClass="width15" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TRANSPORT_STATUS_TEXT" HeaderText="Transport Status" >
                                            <HeaderStyle CssClass="width20" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="EMP_NAME" HeaderText="Employee Name" >
                                            <HeaderStyle CssClass="width15" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SUM_PROD_PRICE_ACTIVE" DataFormatString="{0:#,##0.00}" HeaderText="Total Amount">
                                                <HeaderStyle CssClass="width10" />
                                                <ItemStyle CssClass="ItemStyle-right" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
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
</asp:Content>
