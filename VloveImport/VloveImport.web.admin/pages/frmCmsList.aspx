<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="frmCmsList.aspx.cs" Inherits="VloveImport.web.admin.pages.frmCmsList" %>

<%@ Register Src="../UserControls/ucCalendar.ascx" TagName="ucCalendar" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>

            <asp:PostBackTrigger ControlID="btnSave" />

        </Triggers>
        <ContentTemplate>
            <fieldset style="width: 95%;" hidden>
                <%--<legend>Content Type
                </legend>--%>
                <table>
                    <tr id="trContent_Type" runat="server">
                        <td style="text-align: right;">Content Type :</td>
                        <td>
                            <asp:DropDownList ID="ddl_Header_Content_Type" Enabled="false" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_Header_Content_Type_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="1">Promotion</asp:ListItem>
                                <asp:ListItem Value="2">News</asp:ListItem>
                                <asp:ListItem Value="3">Recommend</asp:ListItem>
                            </asp:DropDownList>
                            <asp:HiddenField ID="hd_Header_Content_Type" runat="server" />
                        </td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <%--<td></td>--%>
                    </tr>
                </table>
            </fieldset>
            <fieldset style="width: 95%;">
                <legend>
                    <asp:Label ID="lblLegend" runat="server" Text="Label"></asp:Label>
                </legend>
                <table>
                    <tr hidden>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr id="trTitle" runat="server">
                        <td style="text-align: right;">Header Title :</td>
                        <td colspan="4">
                            <asp:TextBox ID="txtHeaderTitle" runat="server" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="trIMG" runat="server">
                        <td style="text-align: right;">Header Image :</td>
                        <td colspan="4">
                            <asp:FileUpload ID="FileUploadControl" runat="server" Width="100%" />
                            <asp:HiddenField ID="hdHeaderContentIMG" runat="server" />
                        </td>
                    </tr>
                    <asp:Label ID="lblERR" runat="server"></asp:Label><br />
                    <asp:Label ID="lblERR2" runat="server"></asp:Label><br />
                    <asp:Label ID="lblERR3" runat="server"></asp:Label>

                    <tr id="trHtmlEditor" runat="server" hidden>
                        <td style="text-align: right;">Header Order :</td>
                        <td colspan="4">
                            <asp:TextBox ID="txtOrder" runat="server" Width="100%"></asp:TextBox>
                            <asp:NumericUpDownExtender
                                ID="NumericUpDownExtender1"
                                runat="server"
                                TargetControlID="txtOrder"
                                Width="120"
                                RefValues=""
                                ServiceDownMethod=""
                                ServiceUpMethod=""
                                TargetButtonDownID=""
                                TargetButtonUpID=""
                                Minimum="1"
                                Maximum="7" />
                        </td>
                    </tr>
                    <%--<tr>
                        <td style="text-align: right;">Active :</td>
                        <td colspan="4">
                            <asp:CheckBox ID="CheckBox1" runat="server" Checked="true" />
                        </td>
                    </tr>--%>
                    <tr style="margin-top: 20px;">
                        <td colspan="5" style="text-align: right;">
                            <asp:Button ID="btnSave" runat="server" Text="Save " CssClass=" btnSave" OnClick="btnSave_Click"></asp:Button>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <asp:HiddenField ID="hdfContentType" runat="server" />
            <fieldset style="width: 98.5%;">
                <legend>Search Criteria</legend>
                <table style="border: 1 solid;">
                    <tr>
                        <td class="width15">
                            <asp:Label ID="Label1" runat="server" Text="Content Title :"></asp:Label>
                        </td>
                        <td class="width35">
                            <asp:TextBox ID="txtTitle" runat="server" Width="300px"></asp:TextBox>
                        </td>
                        <td class="width15">
                            <%--<asp:Label ID="Label2" runat="server" Text="Content Type :"></asp:Label>--%>
                        </td>
                        <td class="width35">
                            <%--<asp:DropDownList ID="ddl_Content_Type" runat="server" hidden>
                                <asp:ListItem Selected="True" Value="0">All</asp:ListItem>
                                <asp:ListItem Value="1">Promotion</asp:ListItem>
                                <asp:ListItem Value="2">News</asp:ListItem>
                                <asp:ListItem Value="3">Recommend</asp:ListItem>
                            </asp:DropDownList>--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="width15">
                            <asp:Label ID="Label3" runat="server" Text="Active :"></asp:Label>
                        </td>
                        <td class="width35">
                            <asp:CheckBox ID="chkIsActive" runat="server" Checked="true" />
                        </td>
                        <td class="width15"></td>
                        <td class="width35"></td>
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
                        <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btnSave" OnClick="btnAdd_Click" />
                        &nbsp;</td>
                </tr>
            </table>
            <asp:GridView ID="gv_detail" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" Width="100%"
                DataKeyNames="CONTENT_ID,CONTENT_TITLE,CONTENT_TYPE_TEXT,CREATE_DATE,UPDATE_DATE,IS_ACTIVE_TEXT">
                <Columns>
                    <asp:BoundField DataField="ROW_INDEX" HeaderText="No.">
                        <HeaderStyle CssClass="width5" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CONTENT_TITLE" HeaderText="Content Title">
                        <HeaderStyle CssClass="width40" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CONTENT_TYPE_TEXT" HeaderText="Content Type">
                        <HeaderStyle CssClass="width15" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CREATE_DATE" HeaderText="Create Date">
                        <HeaderStyle CssClass="width15" />
                    </asp:BoundField>
                    <asp:BoundField DataField="UPDATE_DATE" HeaderText="Update Date">
                        <HeaderStyle CssClass="width15" />
                    </asp:BoundField>
                    <asp:BoundField DataField="IS_ACTIVE" HeaderText="Active">
                        <HeaderStyle CssClass="width5" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Tools">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgBtn_edit" runat="server" ImageUrl="~/img/icon/b_edit.png" OnClick="imgBtn_edit_Click" />&nbsp;&nbsp;
                        </ItemTemplate>
                        <HeaderStyle CssClass="width5" />
                        <ItemStyle CssClass="ItemStyle-center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
