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
                        <asp:Button ID="btnEdit" runat="server" Text="Edit Tracking" CssClass ="btnSearch" OnClick="btnEdit_Click"/>
                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass ="btnSave" OnClick="btnSave_Click" Visible="false"/>
                        <asp:Button ID="btnAdd" runat="server" Text="Add Tracking" CssClass ="btnSave" PostBackUrl="~/pages/frmTracking.aspx" />
                    </td>                  
                </tr>
            </table>
            <asp:GridView ID="gv_detail" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" Width="100%">                
                <Columns>
                    <asp:BoundField DataField="ROW_INDEX" HeaderText="No.">
                        <HeaderStyle CssClass="width5" />
                    </asp:BoundField> 
                    <asp:BoundField DataField="TRACKING_TRANS_NAME" HeaderText="Transport Name">
                        <HeaderStyle CssClass="width15" />
                    </asp:BoundField>                          
                    <asp:TemplateField HeaderText="Tracking Number">
                        <ItemTemplate>
                            <asp:HiddenField ID="hdT_ID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "T_ID") %>'/>
                            <asp:TextBox ID="txt_T_NO" runat="server" style="width:95%; background-color:white;" Text='<%# DataBinder.Eval(Container.DataItem, "T_TRACKING_NO") %>' Visible="false"/>   
                            <asp:Label ID="lb_T_NO" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "T_TRACKING_NO") %>'/>                           
                        </ItemTemplate>
                        <HeaderStyle CssClass="width15" />
                        <ItemStyle CssClass="ItemStyle-center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Transport Date">
                        <ItemTemplate>
                            <asp:Label ID="lbDate" runat="server" Text='<%# DateStringtoString(DataBinder.Eval(Container.DataItem, "T_DATE").ToString()) %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="width13" />
                        <ItemStyle CssClass="ItemStyle-center" />
                    </asp:TemplateField>                                 
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddl_T_STATUS" runat="server" style="width:95%; background-color:white;" Visible="false"></asp:DropDownList>
                            <asp:Label ID="lb_T_STATUS" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STATUS_DESCRIPTION").ToString().Replace("||", "<br/>")  %>'/>                           
                        </ItemTemplate>
                        <HeaderStyle CssClass="width15" />
                        <ItemStyle CssClass="ItemStyle-center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="T_WEIGHT" HeaderText="Weight">
                        <HeaderStyle CssClass="width7" />
                        <ItemStyle CssClass="ItemStyle-right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="T_CUBIC" HeaderText="Cubic">
                        <HeaderStyle CssClass="width7" />
                        <ItemStyle CssClass="ItemStyle-right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="T_HEIGHT" HeaderText="Height">
                        <HeaderStyle CssClass="width7" />
                        <ItemStyle CssClass="ItemStyle-right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="T_WIDTH" HeaderText="Width">
                        <HeaderStyle CssClass="width7" />
                        <ItemStyle CssClass="ItemStyle-right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="T_HIGH" HeaderText="High">
                        <HeaderStyle CssClass="width7" />
                        <ItemStyle CssClass="ItemStyle-right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="T_PACK_NO" HeaderText="Pack No">
                        <HeaderStyle CssClass="width8" />
                        <ItemStyle CssClass="ItemStyle-center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="T_TYPE" HeaderText="Type">
                            <HeaderStyle CssClass="width10" />
                        </asp:BoundField>
                        <asp:BoundField DataField="T_REMARK" HeaderText="Remark">
                            <HeaderStyle CssClass="width15" />
                        </asp:BoundField>
<%--                    <asp:TemplateField HeaderText="Update">
                        <ItemTemplate>
                            <asp:HiddenField ID="hdT_ID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "T_ID") %>'/>
                            <asp:ImageButton ID="imgBtn_edit" runat="server" ImageUrl="~/img/icon/b_edit.png" OnClick="imgBtn_edit_Click" />&nbsp;&nbsp;                            
                        </ItemTemplate>
                        <HeaderStyle CssClass="width10" />
                        <ItemStyle CssClass="ItemStyle-center" />
                    </asp:TemplateField>--%>
                </Columns>
                <EmptyDataTemplate>
                    <table style="border: 1px solid black;">
                        <tr>
                            <td class="width5">No. </td>
                            <td class="width15">Transport Name</td>
                            <td class="width15">Transport Number</td>
                            <td class="width15">Transport Date</td>
                            <td class="width10">Weight</td>
                            <td class="width10">Size(Cubic)</td>
                            <td class="width10">Width</td>
                            <td class="width10">Height</td>                                
                            <td class="width10">High</td>
                            <td class="width10">Pack No.</td>
                            <td class="width10">Type</td>
                            <td class="width15">Remark</td>
                        </tr>
                        <tr style="border: 1px solid black;">
                            <td colspan="12"><br />Data empty.</td>
                        </tr>
                    </table>
                        
                </EmptyDataTemplate>
            </asp:GridView>
            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
