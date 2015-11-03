<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="frmUpdateTracking.aspx.cs" Inherits="VloveImport.web.admin.pages.frmUpdateTracking" %>

<%@ Register Src="../UserControls/ucCalendar.ascx" TagName="ucCalendar" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style ="margin-top:10px;">
                <h2 style ="color:#318DBF;">Tracking Status</h2>
                <hr style="width:100%; text-align:left; margin-top:-15px; background-color :#D1DBE0; height:5px; color: #D1DBE0; border :0;"/>  
            </div>
            <fieldset style="width: 98.5%;">
                <legend>
                    <asp:Label ID="lbl_header" runat="server" Text="Search data"></asp:Label>
                </legend>
                <table>
                    <tr>
                        <td class="width15">
                            <asp:Label ID="Label1" runat="server" Text="Tracking No. :"></asp:Label>
                        </td>
                        <td class="width35">
                            <asp:TextBox ID="txtTracking" runat="server" Width="300px"></asp:TextBox>                            
                        </td>
                        <td class="width15">
                            <asp:Label ID="Label2" runat="server" Text="Date :"></asp:Label>
                        </td>
                        <td class="width35">
                            <uc1:ucCalendar ID="ucCalendar1" runat="server" />
                            &nbsp;-&nbsp;
                            <uc1:ucCalendar ID="ucCalendar2" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="4" style="text-align:center;">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btnSearch" OnClick="btnSearch_Click" />&nbsp;&nbsp;
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
                        <asp:Button ID="btnAdd" runat="server" Text="Add Groupuser" CssClass ="btnSave" OnClick="btnAdd_Click" />
                    </td>                  
                </tr>
            </table>
            <asp:GridView ID="gv_detail" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" Width="100%">                
                <Columns>
                    <asp:BoundField DataField="ROW_INDEX" HeaderText="No.">
                        <HeaderStyle CssClass="width5" />
                    </asp:BoundField> 
                    <%--<asp:BoundField DataField="TRANS_NAME" HeaderText="Transport Name">
                        <HeaderStyle CssClass="width15" />
                    </asp:BoundField>    --%>               
                    <asp:BoundField HeaderText="Tracking Number" DataField="TRACKING_NO">
                        <HeaderStyle CssClass="width15" />
                    </asp:BoundField>
                    <%--<asp:BoundField DataField="ORDER_CODE" HeaderText="Order Code">
                        <HeaderStyle CssClass="width15" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Weight" DataField="WEIGHT">
                        <HeaderStyle CssClass="width15" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SIZE" HeaderText="Size">
                        <HeaderStyle CssClass="width15" />
                    </asp:BoundField>--%>
                    <asp:TemplateField HeaderText="Tools">
                        <ItemTemplate>
                            <asp:HiddenField ID="hdOS_ID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ORDER_SHOP_ID") %>'/>
                            <asp:ImageButton ID="imgBtn_edit" runat="server" ImageUrl="~/img/icon/b_edit.png" OnClick="imgBtn_edit_Click" />&nbsp;&nbsp;                            
                        </ItemTemplate>
                        <HeaderStyle CssClass="width5" />
                        <ItemStyle CssClass="ItemStyle-center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <br />
            <fieldset>
                <legend>
                    <asp:Label ID="Label6" runat="server" Text="Information"></asp:Label>
                </legend>
                <table>
                    <tr>
                        <td class="width15">Order Code :</td>
                        <td class="width35">
                            <asp:TextBox ID="txtFName" runat="server" Width="300px"></asp:TextBox>
                            <span style ="color:red;">*</span>
                        </td>
                        <td class="width15">Last Name :</td>
                        <td class="width35">
                            <asp:TextBox ID="txtLName" runat="server" Width="300px"></asp:TextBox>
                            <span style ="color:red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td>Detail :</td>
                        <td colspan ="3">
                            <asp:TextBox ID="txtDetail" runat="server" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <br />
            <table class = "width100">
                <tr>
                    <td class ="ItemStyle-center">
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btnSave" OnClick="btnUpdate_Click" />&nbsp;&nbsp;
                        <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btnCancel" OnClick="btnReset_Click" />&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
