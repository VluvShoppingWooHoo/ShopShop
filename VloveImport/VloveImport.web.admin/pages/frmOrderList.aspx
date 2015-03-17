<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="frmOrderList.aspx.cs" Inherits="VloveImport.web.admin.pages.frmOrderList" %>

<%@ Register Src="../UserControls/ucCalendar.ascx" TagName="ucCalendar" TagPrefix="uc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <fieldset style="width: 98.5%;">
                <legend>Search Criteria</legend>
                <table style="border: 1 solid;">
                    <tr>
                        <td class="width15">
                            <asp:Label ID="Label1" runat="server" Text="วันที่สั่งซื้อ :"></asp:Label>
                        </td>
                        <td class="width35">
                            <uc1:ucCalendar ID="ucCalendar1" runat="server" />
                            &nbsp;-&nbsp;
                    <uc1:ucCalendar ID="ucCalendar2" runat="server" />
                        </td>
                        <td class="width15">
                            <asp:Label ID="Label2" runat="server" Text="ชื่อลูกค้า:"></asp:Label>
                        </td>
                        <td class="width35">
                            <asp:TextBox ID="txtCusName" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="สถานะการสั่งซื้อ :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_order_status" runat="server" Width="300px">
                                <asp:ListItem Value="-1">แสดงทั้งหมด</asp:ListItem>
                                <asp:ListItem Value="0">ยกเลิก</asp:ListItem>
                                <asp:ListItem Value="1">ยังไม่ได้ชำระเงิน</asp:ListItem>
                                <asp:ListItem Value="2">ชำระเงินแล้ว</asp:ListItem>
                                <asp:ListItem Value="3">รอจัดส่ง</asp:ListItem>
                                <asp:ListItem Value="4">ส่งสินค้าแล้ว</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td></td>
                        <td></td>
                        <%--<td>
                            <asp:Label ID="Label4" runat="server" Text="วิธีการส่งสินค้า :"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="ddl_shipping_status" runat="server" Width="300px">
                                <asp:ListItem Value="-1">แสดงทั้งหมด</asp:ListItem>
                                <asp:ListItem Value="1">ขนส่งทางเรือ</asp:ListItem>
                                <asp:ListItem Value="2">ขนส่งทางเครื่องบิน</asp:ListItem>
                            </asp:DropDownList>
                        </td>--%>
                    </tr>
                    <tr>
                        <%--<td>
                            <asp:Label ID="Label5" runat="server" Text="สถานะการส่งสินค้า :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_transport_status" runat="server" Width="300px">
                                <asp:ListItem Value="-1">แสดงทั้งหมด</asp:ListItem>
                                <asp:ListItem Value="1">อยู่ระหว่างการส่งจากประเทศจีน</asp:ListItem>
                                <asp:ListItem Value="2">สินค้ารอส่งให้ลูกค้า</asp:ListItem>
                                <asp:ListItem Value="3">จัดส่งสินค้าให้ลูกค้าแล้ว</asp:ListItem>
                            </asp:DropDownList>
                        </td>--%>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td colspan="4" style="text-align: center;">                        
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btnSearch" OnClick="btnSearch_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btnCancel" />
                        </td>
                    </tr>
                </table>
            </fieldset>
            <table>
                <tr>
                    <td></td>
                    <td style="text-align: right;">
                        <asp:Button ID="btnclearOrder" runat="server" Text="Clear Order" CssClass="btnCancel" OnClick="btnclearOrder_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left;">
                        <asp:Label ID="lblResult" runat="server" Text="<b>Result Data</b>"></asp:Label>
                    </td>
                    <td style="text-align: right;">
                        <asp:Button ID="btnSelectOrder" runat="server" Text="ดูรายการที่เลือก" CssClass="btnCancel" OnClick="btnSelectOrder_Click" />
                    </td>
                </tr>
            </table>
            <asp:GridView ID="gv_detail" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="5" Width="95%"
                DataKeyNames="ORDER_ID,ORDER_DATE_TEXT,CUS_FULLNAME,ORDER_STATUS_TEXT,EMP_NAME,SUM_PROD_PRICE" OnPageIndexChanging="gv_detail_PageIndexChanging" OnRowCreated="gv_detail_RowCreated" OnRowDataBound="gv_detail_RowDataBound">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="imgBtn_choose" runat="server" Height="20px" ImageUrl="~/img/icon/nxt-checkbox-checked-ok-md.png" Width="20px" OnClick="imgBtn_choose_Click" />
                        </ItemTemplate>
                        <HeaderStyle CssClass="width5" />
                        <ItemStyle CssClass="ItemStyle-center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="ROW_INDEX" HeaderText="No." />
                    <asp:BoundField DataField="ORDER_ID" HeaderText="Order ID" />
                    <asp:BoundField DataField="ORDER_DATE_TEXT" HeaderText="Order Date" />
                    <asp:BoundField DataField="CUS_FULLNAME" HeaderText="Customer Name" />
                    <asp:BoundField DataField="ORDER_STATUS_TEXT" HeaderText="Order Status" />
                    <asp:BoundField DataField="EMP_NAME" HeaderText="Employee Name" />
                    <asp:BoundField DataField="SUM_PROD_PRICE" DataFormatString="{0:#,##0.00}" HeaderText="Total Amount">
                        <ItemStyle CssClass="ItemStyle-right" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Tools">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgBtn_edit" runat="server" ImageUrl="~/img/icon/b_edit.png" OnClick="imgBtn_edit_Click" />&nbsp;&nbsp;
                    <asp:ImageButton ID="imgBtn_delete" runat="server" Height="15px" ImageUrl="~/img/icon/Close-2-icon.png" Width="15px" OnClick="imgBtn_delete_Click" />
                        </ItemTemplate>
                        <ItemStyle CssClass="ItemStyle-center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>


            <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modalBackground"
                PopupControlID="Panel1" TargetControlID="lblheader">
            </asp:ModalPopupExtender>

            <asp:Panel ID="Panel1" Height="700px" Width="1200px" runat="server" Style="display: none;">
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
                                <asp:ImageButton ID="BtnImgClose" runat="server" ImageUrl="~/img/icon/Close.png" Width="20px" Height="20px" />
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
                                                    <asp:DropDownList ID="ddl_status_order" runat="server">
                                                        <asp:ListItem Value="-1">กรุณาเลือก</asp:ListItem>
                                                        <asp:ListItem Value="1">สถานะการสั่งซื้อ</asp:ListItem>
                                                        <asp:ListItem>สถานะการส่งสินค้า</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>สถานะที่ต้องการแก้ไข :</td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_sub_status_order" runat="server">
                                                        <asp:ListItem Value="-1">กรุณาเลือก</asp:ListItem>
                                                        <asp:ListItem Value="0">ยกเลิก</asp:ListItem>
                                                        <asp:ListItem Value="1">รอชำระเงิน</asp:ListItem>
                                                        <asp:ListItem Value="2">ชำระเงินแล้ว</asp:ListItem>
                                                        <asp:ListItem Value="3">รอจัดส่ง</asp:ListItem>
                                                        <asp:ListItem Value="4">ส่งสินค้าแล้ว</asp:ListItem>
                                                        <asp:ListItem Value="-2">---------</asp:ListItem>
                                                        <asp:ListItem Value="1">อยู่ระหว่างการสั่งจากประเทศจีน</asp:ListItem>
                                                        <asp:ListItem Value="2">สินค้ารอส่งให้ลูกค้า</asp:ListItem>
                                                        <asp:ListItem Value="3">จัดส่งสินค้าให้ลูกค้าแล้ว</asp:ListItem>
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
                                    <asp:GridView ID="gv_detail_view" runat="server" AutoGenerateColumns="False" AllowPaging="False" Width="95%" 
                                        DataKeyNames ="ORDER_ID,ORDER_DATE_TEXT,CUS_FULLNAME,ORDER_STATUS_TEXT,EMP_NAME,SUM_PROD_PRICE">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgBtn_gv_view_delete" runat="server" Height="20px" ImageUrl="~/img/icon/nxt-checkbox-checked-not-ok-md.png" Width="20px" OnClick="imgBtn_gv_view_delete_Click" />
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="width5" />
                                                <ItemStyle CssClass="ItemStyle-center" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ROW_INDEX" HeaderText="No." />
                                            <asp:BoundField DataField ="ORDER_ID" HeaderText="Order ID" />
                                            <asp:BoundField DataField = "ORDER_DATE_TEXT" HeaderText="Order Date" />
                                            <asp:BoundField DataField = "CUS_FULLNAME" HeaderText="Customer Name" />
                                            <asp:BoundField DataField = "ORDER_STATUS_TEXT" HeaderText="Order Status" />
                                            <asp:BoundField DataField = "EMP_NAME" HeaderText="Employee Name" />
                                            <asp:BoundField DataField = "SUM_PROD_PRICE" DataFormatString="{0:#,##0.00}" HeaderText="Total Amount" >
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

            <asp:ModalPopupExtender ID="Modal_Detail" runat="server" BackgroundCssClass="modalBackground"
                PopupControlID="Panel3" TargetControlID="lbl_modal_detail">
            </asp:ModalPopupExtender>

            <asp:Panel ID="Panel3" Height="700px" Width="1200px" runat="server">
                <%--Style="display: none;"--%>
                <table width="800px" style="border-collapse: separate; border-spacing: 0px" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td width="52px" height="43px" style="padding: 0px 0px;" class="trLogin_LEFT"></td>
                        <td align="left" class="trLogin_CENTER" style="padding: 0px 0px;">
                            <div style="margin-left: -40px; margin-top: 10px;">
                                <asp:Label ID="lbl_modal_detail" runat="server" Text="รายละเอียด ORDER : xxxxxx"></asp:Label>
                            </div>
                        </td>
                        <td align="right" width="52px" height="43px" style="padding: 0px 0px;" class="trLogin_RIGHT">
                            <div style="text-align: right; margin-right: 10px; margin-top: 10px;">
                                <asp:ImageButton ID="imgBtnClose_Modal_detail" runat="server" ImageUrl="~/img/icon/Close.png" Width="20px" Height="20px" />
                            </div>
                        </td>
                    </tr>
                    <tr style="background-color: #CFCDCD;">
                        <td style="text-align: center; padding: 0px 0px;" colspan="3">
                            <center>
                            <asp:Panel Width="96%" Height="550px" ID="Panel4" runat="server" BackColor="#FFFFFF" ScrollBars="Vertical">
                                <br />
                                    <fieldset style ="width:95%;">
                                        <legend>
                                            รายละเอียดการสั่งซื้อสินค้า
                                        </legend>
                                        <table>
                                            <tr>
                                                <td>เลขที่การสั่งซื้อ :</td>
                                                <td>
                                                    <asp:Label ID="lbl_ViewDetail_ORDER_ID" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td>วันที่ทำการสั่งซื้อ :</td>
                                                <td>
                                                    <asp:Label ID="lbl_ViewDetail_ORDER_DATE" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>วิธีการขนส่งขั้นที่ 1 :</td>
                                                <td>
                                                    <asp:Label ID="lbl_ViewDetail_TRANSPORT_1" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td>วิธีการขนส่งขั้นที่ 2 :</td>
                                                <td>
                                                    <asp:Label ID="lbl_ViewDetail_TRANSPORT_2" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>ที่อยู่จัดส่งสินค้า :</td>
                                                <td colspan ="3">
                                                    <asp:Label ID="lbl_ViewDetail_ADDRESS" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>พนักงานที่แก้ไขล่าสุด</td>
                                                <td>
                                                    <asp:Label ID="lbl_ViewDetail_EMP_NAME" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td>วันที่เข้ามาแก้ไข</td>
                                                <td>
                                                    <asp:Label ID="lbl_ViewDetail_EMP_UPDATE_DATE" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                <fieldset style ="width:95%;">
                                    <legend>
                                        แก้ไขสถานะการสั่งซื้อ
                                    </legend>
                                        <table>
                                            <tr>
                                                <td width ="15%">สถานะการสั่งซื้อ :</td>
                                                <td width ="85%">
                                                    <asp:DropDownList ID="DropDownList2" runat="server">
                                                        <asp:ListItem Value="-1">กรุณาเลือก</asp:ListItem>
                                                        <asp:ListItem Value="0">ยกเลิก</asp:ListItem>
                                                        <asp:ListItem Value="1">รอชำระเงิน</asp:ListItem>
                                                        <asp:ListItem Value="2">ชำระเงินแล้ว</asp:ListItem>
                                                        <asp:ListItem Value="3">รอจัดส่ง</asp:ListItem>
                                                        <asp:ListItem Value="4">ส่งสินค้าแล้ว</asp:ListItem>
                                                        <asp:ListItem Value="5">รอลูกค้ายืนยันการแก้ไขจำนวนสินค้า</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <%-- 
                                                        <asp:ListItem Value="5">รอลูกค้ายืนยันการแก้ไขจำนวนสินค้า</asp:ListItem>
                                                        สถานะนี้จะเกิดขึ้น โดยระบบจะ stamp ให้เองโดยเคสที่เป็น การแก้จำนวนสินค้าของพนักงานจะต้องมีการส่งเมลให้ลูกค้ากลับมา ยืนยันการสั่งซื้อ หรือ สามารถให้ยกเลิกการสั่งซื้อสินค้า
                                                        และถ้าเป็นสถานะนี้อยู่พนักงานจะไม่สามารถเข้ามาเปลี่ยน สถานะได้
                                                    --%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>สถานะการส่งสินค้า :</td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownList1" runat="server">
                                                        <asp:ListItem Value="1">อยู่ระหว่างการสั่งจากประเทศจีน</asp:ListItem>
                                                        <asp:ListItem Value="2">สินค้ารอส่งให้ลูกค้า</asp:ListItem>
                                                        <asp:ListItem Value="3">จัดส่งสินค้าให้ลูกค้าแล้ว</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td>
                                                    <asp:Button ID="btn_modal_detail_update" runat="server" Text="Update Status" CssClass ="btnSave"></asp:Button>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                    <fieldset style ="width:95%;">
                                        <legend>
                                            ข้อมูลลูกค้า
                                        </legend>
                                        <table>
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
                                                    <asp:Label ID="Label16" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td>Email :</td>
                                                <td>
                                                    <asp:Label ID="lbl_ViewDetail_Email" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                    <fieldset style ="width:95%;">
                                            <legend>
                                                รายการสินค้า
                                            </legend>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex ="0">
                                                            <asp:View ID="View1" runat="server">
                                                                <asp:Button ID="btnEditProd_num" runat="server" Text="แก้ไขจำนวนสินค้า" CssClass =" btnSearch"></asp:Button>
                                                                <asp:GridView ID="gv_detail_prod_view" runat="server" AutoGenerateColumns="False" AllowPaging="False" Width="100%" 
                                                                    DataKeyNames ="ORDER_ID,ORDER_DATE_TEXT,CUS_FULLNAME,ORDER_STATUS_TEXT,EMP_NAME,SUM_PROD_PRICE">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="ROW_INDEX" HeaderText="No." />
                                                                        <asp:BoundField DataField ="OD_ITEMNAME" HeaderText="รายละเอียดสินค้า" />
                                                                        <asp:BoundField DataField = "OD_REMARK" HeaderText="หมายเหตุ" />
                                                                        <asp:BoundField DataField = "OD_PRICE" DataFormatString="{0:#,##0.00}" HeaderText="ราคาต่อชิ้น" >
                                                                        <ItemStyle CssClass="ItemStyle-right" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField = "OD_AMOUNT" HeaderText="จำนวนสินค้าที่สั่งซื้อ" >
                                                                        <ItemStyle CssClass="ItemStyle-right" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField = "OD_PRICE" DataFormatString="{0:#,##0.00}" HeaderText="ราคารวม" >
                                                                        <ItemStyle CssClass="ItemStyle-right" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField = "OD_AMOUNT_ACTIVE" HeaderText="จำนวนสินค้าที่ได้รับ" >
                                                                        <ItemStyle CssClass="ItemStyle-right" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField = "OD_PRICE" DataFormatString="{0:#,##0.00}" HeaderText="ราคารวม" >
                                                                        <ItemStyle CssClass="ItemStyle-right" />
                                                                        </asp:BoundField>
                                                                    </Columns>
                                                                </asp:GridView>        
                                                            </asp:View>
                                                            <asp:View ID="View2" runat="server">
                                                                <asp:Button ID="btnEditProd_num_save" runat="server" Text="Update " CssClass =" btnSave"></asp:Button>&nbsp;&nbsp;
                                                                <asp:Button ID="btnEditProd_num_cancel" runat="server" Text="Cancel" CssClass ="btnCancel"></asp:Button>
                                                                <asp:GridView ID="gv_detail_prod_Edit" runat="server" AutoGenerateColumns="False" AllowPaging="False" Width="95%" 
                                                                    DataKeyNames ="ORDER_ID,ORDER_DATE_TEXT,CUS_FULLNAME,ORDER_STATUS_TEXT,EMP_NAME,SUM_PROD_PRICE">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="ROW_INDEX" HeaderText="No." />
                                                                        <asp:BoundField DataField ="ORDER_ID" HeaderText="Order ID" />
                                                                        <asp:BoundField DataField = "ORDER_DATE_TEXT" HeaderText="Order Date" />
                                                                        <asp:BoundField DataField = "CUS_FULLNAME" HeaderText="Customer Name" />
                                                                        <asp:BoundField DataField = "ORDER_STATUS_TEXT" HeaderText="Order Status" />
                                                                        <asp:BoundField DataField = "EMP_NAME" HeaderText="Employee Name" />
                                                                        <asp:BoundField DataField = "SUM_PROD_PRICE" DataFormatString="{0:#,##0.00}" HeaderText="Total Amount" >
                                                                        <ItemStyle CssClass="ItemStyle-right" />
                                                                        </asp:BoundField>
                                                                    </Columns>
                                                                </asp:GridView>  
                                                            </asp:View>
                                                        </asp:MultiView>
                                                    </td>
                                                </tr>
                                            </table>
                                    </fieldset>
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
