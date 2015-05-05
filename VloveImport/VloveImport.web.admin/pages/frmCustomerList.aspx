<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="frmCustomerList.aspx.cs" Inherits="VloveImport.web.admin.pages.frmCustomerList" %>

<%@ Register Src="../UserControls/ucCalendar.ascx" TagName="ucCalendar" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register src="../UserControls/ucEmail.ascx" tagname="ucEmail" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style ="margin-top:10px;">
        <h2 style ="color:#318DBF;">Customer Managemaent</h2>
        <hr style="width:100%; text-align:left; margin-top:-15px; background-color :#D1DBE0; height:5px; color: #D1DBE0; border :0;"/>  
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <fieldset style="width: 98.5%;">
                <legend>Search Criteria</legend>
                <table style="border: 1 solid;">
                    <tr>
                        <td class="width15">
                            <asp:Label ID="Label1" runat="server" Text="Customer code :"></asp:Label>
                        </td>
                        <td class="width35">
                            <asp:TextBox ID="txtCus_Code" runat="server" Width="300px"></asp:TextBox>
                        </td>
                        <td class="width15">
                            <asp:Label ID="Label2" runat="server" Text="Customer name :"></asp:Label>
                        </td>
                        <td class="width35">
                            <asp:TextBox ID="txtCus_Name" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label3" runat="server" Text="Customer Birthday :"></asp:Label></td>
                        <td>
                            <uc1:ucCalendar ID="ucCalendar_BirthdayFrom" runat="server" />
                            &nbsp;-&nbsp;
                            <uc1:ucCalendar ID="ucCalendar_BirthdayTo" runat="server" />
                        </td>
                        <td><asp:Label ID="Label4" runat="server" Text="Customer Email :"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtCus_Email" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label5" runat="server" Text="Customer Telephone :"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtCus_telphone" runat="server" Width="300px"></asp:TextBox>
                        </td>
                        <td><asp:Label ID="Label6" runat="server" Text="Customer Amount :"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="ddlSymbow" runat="server" Width="100px">
                                <asp:ListItem Value="1">=</asp:ListItem>
                                <asp:ListItem Value="2">&gt;=</asp:ListItem>
                                <asp:ListItem Value="3">&lt;=</asp:ListItem>
                            </asp:DropDownList> &nbsp;
                            <asp:TextBox ID="txtCus_Amount" runat="server" Width="200px"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="txtCus_Amount_FilteredTextBoxExtender" runat="server" Enabled="True" TargetControlID="txtCus_Amount" ValidChars="0123456789">
                            </asp:FilteredTextBoxExtender>
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
                        &nbsp;</td>
                </tr>
            </table>
            <asp:GridView ID="gv_detail" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" Width="100%"
                DataKeyNames="CUS_ID,CUS_CODE,CUS_EMAIL" OnPageIndexChanging="gv_detail_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="ROW_INDEX" HeaderText="No.">
                        <HeaderStyle CssClass="width5" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CUS_CODE" HeaderText="<nobr>Customer</nobr><br>code" HtmlEncode ="false">
                    <HeaderStyle CssClass="width10" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Customer name" DataField="CUS_FULLNAME">
                    <HeaderStyle CssClass="width15" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Birthday" DataField="CUS_BIRTHDAY_TEXT">
                    <HeaderStyle CssClass="width10" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Telephone" DataField="CUS_TELEPHONE" >
                    <HeaderStyle CssClass="width10" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Email" DataField="CUS_EMAIL">
                    <HeaderStyle CssClass="width15" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Amount" DataField="CUS_TOTAL_AMOUNT" DataFormatString="{0:#,##0.00}">
                    <HeaderStyle CssClass="width10" />
                    <ItemStyle CssClass="ItemStyle-right" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Point" DataField="CUS_POINT">
                    <HeaderStyle CssClass="width5" />
                    <ItemStyle CssClass="ItemStyle-right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CUS_STATUS_TEXT" HeaderText="Status">
                    <HeaderStyle CssClass="width5" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Tools">
                        <ItemTemplate>
                           <%-- <asp:ImageButton ID="imgBtn_view" runat="server" ImageUrl="~/img/icon/View.png" Width ="20px" Height ="20px" />&nbsp;&nbsp;--%>
                            <asp:ImageButton ID="imgBtn_Email" runat="server" ImageUrl="~/img/icon/sendemail.png" Width ="30px" Height ="30px" OnClick="imgBtn_Email_Click" />
                        </ItemTemplate>
                        <HeaderStyle CssClass="width5" />
                        <ItemStyle CssClass="ItemStyle-center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <asp:ModalPopupExtender ID="MadoalPop_Email" runat="server" BackgroundCssClass="modalBackground"
                PopupControlID="Panel1" TargetControlID="lbl_modal_email">
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel1" Height="520" Width="800px" runat="server" Style="display: none;">
                <%--Style="display: none;"--%>
                <table width="800px" style="border-collapse: separate; border-spacing: 0px" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td width="52px" height="43px" style="padding: 0px 0px;" class="trLogin_LEFT"></td>
                        <td align="left" class="trLogin_CENTER" style="padding: 0px 0px;">
                            <div style="margin-left: -40px; margin-top: 10px;">
                                <asp:Label ID="lbl_modal_email" runat="server" Text="Send Email"></asp:Label>
                            </div>
                        </td>
                        <td align="right" width="52px" height="43px" style="padding: 0px 0px;" class="trLogin_RIGHT">
                            <div style="text-align: right; margin-right: 10px; margin-top: 10px;">
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/img/icon/Close.png" Width="20px" Height="20px" />
                            </div>
                        </td>
                    </tr>
                    <tr style="background-color: #CFCDCD;">
                        <td style="text-align: center; padding: 0px 0px;" colspan="3">
                            <center>
                            <asp:Panel Width="96%" Height="420px" ID="Panel2" runat="server" BackColor="#FFFFFF">
                                 <br />
                                 <uc2:ucEmail ID="ucEmail1" runat="server" />                 
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
