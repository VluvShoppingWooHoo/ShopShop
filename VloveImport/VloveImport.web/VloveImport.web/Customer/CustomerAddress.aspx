<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/master_page_batt.Master" AutoEventWireup="true" CodeBehind="CustomerAddress.aspx.cs" Inherits="VloveImport.web.Customer.CustomerAddress" StylesheetTheme = "th1" Theme ="th1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div >
    ที่อยุ่

    <asp:Button ID="btnAdd" runat="server" Text="Add Address" OnClick="btnAdd_Click" />
         
    <hr style="width:100%; text-align:left; background-color :#FFD700; height:5px; color: #6ACAE1; border :0;"/>

<table width ="100%">
    <tr>
        <td align ="center">
            <asp:GridView ID="gv_cus_address" runat="server" AutoGenerateColumns="False" Width ="90%">
                <Columns>
                    <asp:BoundField HeaderText="ลำดับ" DataField="Index" >
                    <ItemStyle HorizontalAlign="Right" Width="5%" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="ชื่อลูกค้า" DataField="CUS_ADD_CUS_NAME" >
                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="รายละเอียด" DataField="CUS_ADD_ADDRESS_TEXT" >
                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="ที่อยู่" >
                    <ItemStyle HorizontalAlign="Left" Width="30%" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="จังหวัด" DataField="PROVINCE_NAME" >
                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="ภาค" DataField="REGION_NAME" >
                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Tools">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnImgEdit" runat="server" ImageUrl="~/Images/icon/b_edit.png" OnClick="btnImgEdit_Click" />&nbsp;&nbsp;
                            <asp:ImageButton ID="btnImgDelete" runat="server" Height="15px" ImageUrl="~/Images/icon/Close-2-icon.png" OnClick="btnImgDelete_Click" Width="15px" />
                        </ItemTemplate>
                        <ItemStyle Width="10%" />
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    คุณยังไม่มีรายการที่อยู่
                </EmptyDataTemplate>
            </asp:GridView>
        </td>
    </tr>
</table>
</div>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modalBackground"
            PopupControlID="Panel1" TargetControlID="lblheader">
        </asp:ModalPopupExtender>

        <asp:Panel ID="Panel1" Height="400px" Width="600px" runat="server" ><%--Style="display: none;"--%>
            <table width="600px" style ="border-collapse:separate;" cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td width="52px" height="43px" style ="padding:0px 0px;" class="trLogin_LEFT"></td>
                    <td align="left" class="trLogin_CENTER" style ="padding:0px 0px;">
                        <div style ="margin-left:-40px;">
                            <asp:Label ID="lblheader" runat="server" Text="gfsgdfg"></asp:Label>
                        </div>
                    </td>
                    <td align="right" width="52px" height="43px" style ="padding:0px 0px;" class="trLogin_RIGHT">
                        <div style="text-align:right;margin-right: 10px; margin-top: 5px;">
                            <asp:ImageButton ID="BtnImgClose" runat="server" ImageUrl="~/Images/icon/Close.png" Width="20px" Height="20px" OnClick="BtnImgClose_Click" />
                        </div>
                    </td>
                </tr>
                <tr style="background-color: #CFCDCD;">
                    <td style ="text-align:center; padding:0px 0px;" colspan="3">
                        <center>
                            <asp:Panel Width="96%" Height="350px" ID="Panel2" runat="server" BackColor="#FFFFFF">
                                <table width ="100%">
                                    <tr>
                                        <td Width ="25%">ชื่อลูกค้า : </td>
                                        <td Width ="75%">
                                            <asp:TextBox ID="txt_Cusname" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>รายละเอียด :</td>
                                        <td>
                                            <asp:TextBox ID="txt_CusDetail" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>ภาค : </td>
                                        <td>
                                            <asp:DropDownList ID="dll_region" runat="server" Width ="140px" AutoPostBack="True" OnSelectedIndexChanged="dll_region_SelectedIndexChanged"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>จังหวัด : </td>
                                        <td>
                                            <asp:DropDownList ID="dll_province" runat="server" Width ="140px" AutoPostBack="True" OnSelectedIndexChanged="dll_province_SelectedIndexChanged"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>เขต/อำเภอ</td>
                                        <td>
                                            <asp:DropDownList ID="dll_District" runat="server" Width ="140px" AutoPostBack="True" OnSelectedIndexChanged="dll_District_SelectedIndexChanged"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>แขวง/ตำบล</td>
                                        <td>
                                            <asp:DropDownList ID="dll_Sub_District" runat="server" Width ="140px"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>รหัสไปรษณีย์</td>
                                        <td>
                                            <asp:TextBox ID="txt_ZipCode" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan ="2">
                                            <asp:Button ID="btnSave" runat="server" Text="บันทึกข้อมูล" OnClick="btnSave_Click"></asp:Button>&nbsp;&nbsp;
                                            <asp:Button ID="btnReset" runat="server" Text="ล้างข้อมูล" OnClick="btnReset_Click"></asp:Button>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </center>
                    </td>
                </tr>
                <tr style="background-color: #CFCDCD;">
                    <td height="15px" style ="padding:0px 0px;" align="center" colspan="3"></td>
                </tr>
            </table>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>

</asp:Content>
