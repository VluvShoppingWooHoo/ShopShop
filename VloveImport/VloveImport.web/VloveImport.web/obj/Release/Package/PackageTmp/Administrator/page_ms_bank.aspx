<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/master_page_batt.Master" AutoEventWireup="true" CodeBehind="page_ms_bank.aspx.cs" Inherits="VloveImport.web.Administrator.page_ms_bank" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        ข้อมูลธนาคาร
    <br />
        <br />
        <asp:Button ID="btnAdd" runat="server" Text="Add Bank" OnClick="btnAdd_Click" />

        <hr style="width: 100%; text-align: left; background-color: #FFD700; height: 5px; color: #6ACAE1; border: 0;" />

        <table width="100%">
            <tr>
                <td align="center">
                    <asp:GridView ID="gv_Deatil" runat="server" AutoGenerateColumns="False" Width="90%" DataKeyNames="BANK_SHOP_ID" OnRowCreated="gv_Deatil_RowCreated">
                        <Columns>
                            <asp:BoundField HeaderText="ลำดับ" DataField="ROW_INDEX">
                                <ItemStyle HorizontalAlign="Right" Width="5%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BANK_NAME" HeaderText="ชื่อธนาคาร"></asp:BoundField>
                            <asp:BoundField HeaderText="เลขที่บัญชี" DataField="BANK_SHOP_ACCOUNT_NO"></asp:BoundField>
                            <asp:BoundField HeaderText="ชื่อบัญชี" DataField="BANK_SHOP_ACCOUNT_NAME">
                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="หมายเหตุ" DataField="BANK_SHOP_REMARK">
                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="สถานะ" DataField="BANK_SHOP_STATUS_TEXT">
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Tools">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnImgEdit" runat="server" ImageUrl="~/Images/icon/b_edit.png" OnClick="btnImgEdit_Click" />&nbsp;&nbsp;
                            <asp:ImageButton ID="btnImgDelete" runat="server" Height="15px" ImageUrl="~/Images/icon/Close-2-icon.png" OnClick="btnImgDelete_Click" Width="15px" />
                                </ItemTemplate>
                                <ItemStyle Width="10%" HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table cellpadding="0" cellspacing="0" border="0" align="left" width="100%" height="275" bgcolor="#fbfbfb">
                                <tr>
                                    <td width="100%" align="center">
                                        <b>Data not found.</b>
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>

    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modalBackground"
        PopupControlID="Panel1" TargetControlID="lblheader">
    </asp:ModalPopupExtender>

    <asp:Panel ID="Panel1" Height="400px" Width="600px" runat="server">
        <%--Style="display: none;"--%>
        <table width="600px" style="border-collapse: separate;" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td width="52px" height="43px" style="padding: 0px 0px;" class="trLogin_LEFT"></td>
                <td align="left" class="trLogin_CENTER" style="padding: 0px 0px;">
                    <div style="margin-left: -40px;">
                        <asp:Label ID="lblheader" runat="server"></asp:Label>
                    </div>
                </td>
                <td align="right" width="52px" height="43px" style="padding: 0px 0px;" class="trLogin_RIGHT">
                    <div style="text-align: right; margin-right: 10px; margin-top: 5px;">
                        <asp:ImageButton ID="BtnImgClose" runat="server" ImageUrl="~/Images/icon/Close.png" Width="20px" Height="20px" OnClick="BtnImgClose_Click" />
                    </div>
                </td>
            </tr>
            <tr style="background-color: #CFCDCD;">
                <td style="text-align: center; padding: 0px 0px;" colspan="3">
                    <center>
                            <asp:Panel Width="96%" Height="350px" ID="Panel2" runat="server" BackColor="#FFFFFF">
                                <table width ="100%">
                                    <tr>
                                        <td align ="left" Width ="25%">ชื่อธนาคาร : </td>
                                        <td align ="left" Width ="75%">
                                            <asp:DropDownList ID="ddl_bank_name" runat="server"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align ="left" Width ="25%">เลขที่บัญชี : </td>
                                        <td align ="left" Width ="75%">
                                            <asp:TextBox ID="txt_acc_no" runat="server" Width ="300px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align ="left">ชื่อบัญชี :</td>
                                        <td align ="left">
                                            <asp:TextBox ID="txt_acc_name" runat="server" Width ="300px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style ="vertical-align:top;" align ="left">หมายเหตุ : </td>
                                        <td align ="left">
                                            <asp:TextBox ID="txt_remark" runat="server" Width="300px" Height ="100px" TextMode ="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align ="left">สถานะ : </td>
                                        <td align ="left">
                                            <asp:DropDownList ID="ddl_Status" runat="server" Width ="300px">
                                                <asp:ListItem Value="1">ใช้งาน</asp:ListItem>
                                                <asp:ListItem Value="0">ไม่ใช้งาน</asp:ListItem>
                                            </asp:DropDownList>
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
                <td height="15px" style="padding: 0px 0px;" align="center" colspan="3"></td>
            </tr>
        </table>
    </asp:Panel>

</asp:Content>
