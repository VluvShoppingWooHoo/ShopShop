<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="frmTrackingList.aspx.cs" Inherits="VloveImport.web.admin.pages.frmTrackingList" %>

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
                        <asp:Button ID="btnAdd" runat="server" Text="Add Tracking" CssClass ="btnSave" OnClick="btnAdd_Click" />
                    </td>                  
                </tr>
            </table>
            <asp:GridView ID="gv_detail" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" Width="100%">                
                <Columns>
                    <asp:BoundField DataField="ROW_INDEX" HeaderText="No.">
                        <HeaderStyle CssClass="width5" />
                    </asp:BoundField> 
                    <asp:BoundField DataField="T_TRANSPORT_NAME" HeaderText="Transport Name">
                        <HeaderStyle CssClass="width15" />
                    </asp:BoundField>              
                    <asp:BoundField DataField="T_TRACKING_NO" HeaderText="Tracking Number" >
                        <HeaderStyle CssClass="width15" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Transport Date">
                        <ItemTemplate>
                            <asp:Label ID="lbDate" runat="server" Text='<%# DateStringtoString(DataBinder.Eval(Container.DataItem, "T_DATE").ToString()) %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="width15" />
                        <ItemStyle CssClass="ItemStyle-center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="T_WEIGHT" HeaderText="Weight">
                        <HeaderStyle CssClass="width10" />
                    </asp:BoundField>
                    <asp:BoundField DataField="T_CUBIC" HeaderText="Cubic">
                        <HeaderStyle CssClass="width10" />
                    </asp:BoundField>
                    <asp:BoundField DataField="T_HEIGHT" HeaderText="Height">
                        <HeaderStyle CssClass="width10" />
                    </asp:BoundField>
                    <asp:BoundField DataField="T_WIDTH" HeaderText="Width">
                        <HeaderStyle CssClass="width10" />
                    </asp:BoundField>
                    <asp:BoundField DataField="T_HIGH" HeaderText="High">
                        <HeaderStyle CssClass="width10" />
                    </asp:BoundField>
                    <asp:BoundField DataField="T_PACK_NO" HeaderText="Pack No">
                        <HeaderStyle CssClass="width10" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Update">
                        <ItemTemplate>
                            <asp:HiddenField ID="hdT_ID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "T_ID") %>'/>
                            <asp:ImageButton ID="imgBtn_edit" runat="server" ImageUrl="~/img/icon/b_edit.png" OnClick="imgBtn_edit_Click" />&nbsp;&nbsp;                            
                        </ItemTemplate>
                        <HeaderStyle CssClass="width10" />
                        <ItemStyle CssClass="ItemStyle-center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
