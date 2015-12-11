<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="frmMasterBank.aspx.cs" Inherits="VloveImport.web.admin.pages.frmMasterBank" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style ="margin-top:10px;">
                <h2 style ="color:#318DBF;">Master Bank</h2>
                <hr style="width:100%; text-align:left; margin-top:-15px; background-color :#D1DBE0; height:5px; color: #D1DBE0; border :0;"/>  
            </div>
            <fieldset>
                <legend>
                    Master Bamk
                </legend>
                <table>
                    <tr>
                        <td class="ItemStyle-right">
                            <asp:Button ID="btnAdd" runat="server" Text="Add Bank" CssClass="btnSave" OnClick="btnAdd_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gv_Detail" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="BANK_SHOP_ID" OnRowCreated="gv_Deatil_RowCreated" AllowPaging="True" OnPageIndexChanging="gv_Deatil_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField HeaderText="No." DataField="ROW_INDEX">
                                        <HeaderStyle CssClass="width5" />
                                        <ItemStyle HorizontalAlign="Right" Width="5%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BANK_NAME" HeaderText="Bank name">
                                        <HeaderStyle CssClass="width15" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Account no" DataField="BANK_SHOP_ACCOUNT_NO">
                                        <HeaderStyle CssClass="width15" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Account name" DataField="BANK_SHOP_ACCOUNT_NAME">
                                        <HeaderStyle CssClass="width15" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Remark" DataField="BANK_SHOP_REMARK">
                                        <HeaderStyle CssClass="width25" />
                                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Status" DataField="BANK_SHOP_STATUS_TEXT">
                                        <HeaderStyle CssClass="width15" />
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Tools">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnImgEdit" runat="server" ImageUrl="~/img/icon/b_edit.png" OnClick="btnImgEdit_Click" />&nbsp;&nbsp;
                                    <asp:ImageButton ID="btnImgDelete" runat="server" Height="15px" ImageUrl="~/img/icon/Close-2-icon.png" OnClick="btnImgDelete_Click" Width="15px" />
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="width10" />
                                        <ItemStyle Width="10%" CssClass="ItemStyle-center" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </fieldset>

            <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modalBackground"
                PopupControlID="Panel5" TargetControlID="lbl_modal_view">
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel5" Height="400px" Width="500px" runat="server" Style="display: none;">
                <%--Style="display: none;"--%>
                <table width="800px" style="border-collapse: separate; border-spacing: 0px" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td width="52px" height="43px" style="padding: 0px 0px;" class="trLogin_LEFT"></td>
                        <td align="left" class="trLogin_CENTER" style="padding: 0px 0px;">
                            <div style="margin-left: -40px; margin-top: 10px;">
                                <asp:Label ID="lbl_modal_view" runat="server" Text="Bank Detail"></asp:Label>
                            </div>
                        </td>
                        <td align="right" width="52px" height="43px" style="padding: 0px 0px;" class="trLogin_RIGHT">
                            <div style="text-align: right; margin-right: 10px; margin-top: 10px;">
                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/img/icon/Close.png" Width="20px" Height="20px" />
                            </div>
                        </td>
                    </tr>
                    <tr style="background-color: #CFCDCD;">
                        <td style="text-align: center; padding: 0px 0px;" colspan="3">
                            <center>
                    <asp:Panel Width="96%" Height="300px" ID="Panel6" runat="server" BackColor="#FFFFFF">
                        <br />
                        <table width ="100%">
                            <tr>
                                <td align ="left" Width ="25%">Bank name : </td>
                                <td align ="left" Width ="75%">
                                    <asp:DropDownList ID="ddl_bank_name" runat="server"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align ="left" Width ="25%">Account no : </td>
                                <td align ="left" Width ="75%">
                                    <asp:TextBox ID="txt_acc_no" runat="server" Width ="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align ="left">Account name :</td>
                                <td align ="left">
                                    <asp:TextBox ID="txt_acc_name" runat="server" Width ="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style ="vertical-align:top;" align ="left">Remark : </td>
                                <td align ="left">
                                    <asp:TextBox ID="txt_remark" runat="server" Width="300px" Height ="100px" TextMode ="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align ="left">Status : </td>
                                <td align ="left">
                                    <asp:DropDownList ID="ddl_Status" runat="server" Width ="300px">
                                        <asp:ListItem Value="1">Active</asp:ListItem>
                                        <asp:ListItem Value="0">Inactive</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan ="2"></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass ="btnSave" OnClick="btnSave_Click"></asp:Button>&nbsp;&nbsp;
                                    <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass ="btnCancel" OnClick="btnReset_Click"></asp:Button>
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

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
