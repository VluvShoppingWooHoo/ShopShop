<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="frmOrder.aspx.cs" Inherits="VloveImport.web.admin.pages.frmOrder" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <fieldset style="width: 95%;">
                <legend>รายละเอียดการสั่งซื้อสินค้า
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
                        <td>จำนวนเงินที่ได้รับจากลูกค้า :</td>
                        <td>
                            <asp:Label ID="lbl_ViewDetail_Amount_Receive" runat="server" Text=""></asp:Label>
                        </td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>จำนวนเงินที่ลูกค้าต้องจ่ายจริง :</td>
                        <td>
                            <asp:Label ID="lbl_ViewDetail_Amount_Actually_Pay" runat="server" Text=""></asp:Label>
                        </td>
                        <td>จำวนวนเงินที่ต้องคืนลูกค้า
                        </td>
                        <td>
                            <asp:Label ID="lbl_ViewDetail_Amount_Recall_Pay" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>ราคาสินค้า</td>
                        <td>
                            <asp:Label ID="lbl_ViewDetail_Product_Price" runat="server" Text=""></asp:Label>
                        </td>
                        <td>ราคาค่าขนส่ง</td>
                        <td>
                            <asp:Label ID="lbl_ViewDetail_Transport_Price" runat="server" Text=""></asp:Label>
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
                        <td colspan="3">
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
            <fieldset style="width: 95%;">
                <legend>แก้ไขสถานะการสั่งซื้อ
                </legend>
                <table>
                    <tr>
                        <td width="15%">สถานะการสั่งซื้อ :</td>
                        <td width="85%">
                            <asp:DropDownList ID="ddl_ViewDetail_ORDER_STATUS" runat="server">
                                <%--                                                        <asp:ListItem Value="-1">กรุณาเลือก</asp:ListItem>
                                                        <asp:ListItem Value="0">ยกเลิก</asp:ListItem>
                                                        <asp:ListItem Value="1">รอชำระเงิน</asp:ListItem>
                                                        <asp:ListItem Value="2">ชำระเงินแล้ว</asp:ListItem>--%>
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
                            <asp:DropDownList ID="ddl_ViewDetail_TRANSPORT_STATUS" runat="server">
                                <%--                                                        <asp:ListItem Value="1">อยู่ระหว่างการสั่งจากประเทศจีน</asp:ListItem>
                                                        <asp:ListItem Value="2">สินค้ารอส่งให้ลูกค้า</asp:ListItem>
                                                        <asp:ListItem Value="3">จัดส่งสินค้าให้ลูกค้าแล้ว</asp:ListItem>--%>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btn_detail_update" runat="server" Text="Update Status" CssClass="btnSave" OnClick="btn_detail_update_Click"></asp:Button>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset style="width: 95%;">
                <legend>ข้อมูลลูกค้า
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
                            <asp:Label ID="Label16" runat="server" Text=""></asp:Label>
                        </td>
                        <td>Email :</td>
                        <td>
                            <asp:Label ID="lbl_ViewDetail_Email" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset style="width: 95%;">
                <legend>รายการสินค้า
                </legend>
                <table>
                    <tr>
                        <td>
                            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                                <asp:View ID="View1" runat="server">
                                    <asp:Button ID="btnEditProd_num" runat="server" Text="แก้ไขจำนวนสินค้า" CssClass=" btnSearch" OnClick="btnEditProd_num_Click"></asp:Button>
                                    <asp:GridView ID="gv_detail_prod_view" runat="server" AutoGenerateColumns="False" Width="100%"
                                        DataKeyNames="ORDER_ID,ORDER_DATE_TEXT,CUS_FULLNAME,ORDER_STATUS_TEXT,EMP_NAME,SUM_PROD_PRICE,OD_ID">
                                        <Columns>
                                            <asp:BoundField DataField="ROW_INDEX" HeaderText="No." />
                                            <asp:BoundField DataField="OD_ITEMNAME" HeaderText="รายละเอียดสินค้า" />
                                            <asp:BoundField DataField="OD_REMARK" HeaderText="หมายเหตุ" />
                                            <asp:BoundField DataField="OD_PRICE" DataFormatString="{0:#,##0.00}" HeaderText="ราคาต่อชิ้น">
                                                <ItemStyle CssClass="ItemStyle-right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="OD_AMOUNT" HeaderText="จำนวนสินค้าที่สั่งซื้อ">
                                                <ItemStyle CssClass="ItemStyle-right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TOTAL_PROD_PRICE" DataFormatString="{0:#,##0.00}" HeaderText="ราคารวม">
                                                <ItemStyle CssClass="ItemStyle-right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="OD_AMOUNT_ACTIVE" HeaderText="จำนวนสินค้าที่ได้รับ">
                                                <ItemStyle CssClass="ItemStyle-right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TOTAL_PROD_PRICE_ACTIVE" DataFormatString="{0:#,##0.00}" HeaderText="ราคารวม">
                                                <ItemStyle CssClass="ItemStyle-right" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:View>
                                <asp:View ID="View2" runat="server">
                                    <asp:Button ID="btnEditProd_num_save" runat="server" Text="Update " CssClass=" btnSave" OnClick="btnEditProd_num_save_Click"></asp:Button>&nbsp;&nbsp;
                                                                <asp:Button ID="btnEditProd_num_cancel" runat="server" Text="Cancel" CssClass="btnCancel" OnClick="btnEditProd_num_cancel_Click"></asp:Button>
                                    <asp:GridView ID="gv_detail_prod_Edit" runat="server" AutoGenerateColumns="False" Width="100%"
                                        DataKeyNames="ORDER_ID,ORDER_DATE_TEXT,CUS_FULLNAME,ORDER_STATUS_TEXT,EMP_NAME,SUM_PROD_PRICE,OD_ID">
                                        <Columns>
                                            <asp:BoundField DataField="ROW_INDEX" HeaderText="No." />
                                            <asp:BoundField DataField="OD_ITEMNAME" HeaderText="รายละเอียดสินค้า" />
                                            <asp:BoundField DataField="OD_REMARK" HeaderText="หมายเหตุ" />
                                            <asp:BoundField DataField="OD_PRICE" DataFormatString="{0:#,##0.00}" HeaderText="ราคาต่อชิ้น">
                                                <ItemStyle CssClass="ItemStyle-right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="OD_AMOUNT" HeaderText="จำนวนสินค้าที่สั่งซื้อ">
                                                <ItemStyle CssClass="ItemStyle-right" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="จำนวนสินค้าที่ได้รับ">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("OD_AMOUNT_ACTIVE") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="gv_detail_prod_Edit_txt" runat="server" AutoCompleteType ="Disabled" Text='<%# Bind("OD_AMOUNT_ACTIVE") %>' MaxLength="8"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="gv_detail_prod_Edit_txt_FilteredTextBoxExtender" runat="server" Enabled="True" TargetControlID="gv_detail_prod_Edit_txt" ValidChars="0123456789">
                                                    </asp:FilteredTextBoxExtender>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="ItemStyle-right" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:View>
                            </asp:MultiView>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
