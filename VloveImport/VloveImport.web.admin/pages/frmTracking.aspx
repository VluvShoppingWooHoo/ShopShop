<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="frmTracking.aspx.cs" Inherits="VloveImport.web.admin.pages.frmTracking" %>

<%@ Register Src="../UserControls/ucCalendar.ascx" TagName="ucCalendar" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style ="margin-top:10px;">
                <h2 style ="color:#318DBF;">Tracking</h2>
                <hr style="width:100%; text-align:left; margin-top:-15px; background-color :#D1DBE0; height:5px; color: #D1DBE0; border :0;"/>  
            </div>
            <fieldset style="width: 98.5%;">
                <legend>
                    <asp:Label ID="lbl_header" runat="server" Text="Add Tracking"></asp:Label>
                </legend>
                <table>
                    <tr>
                        <td class="width15">
                            <asp:Label ID="Label1" runat="server" Text="Transport Name :"></asp:Label>
                        </td>
                        <td class="width35">
                            <asp:DropDownList ID="ddl_TransportName" runat="server" Width="300px"></asp:DropDownList>
                            <span style ="color:red;">*</span>
                        </td>
                        <td class="width15">
                            <asp:Label ID="Label2" runat="server" Text="Tracking Number :"></asp:Label>
                        </td>
                        <td class="width35">
                            <asp:TextBox ID="txtTrackingNumber" runat="server" Width="300px"></asp:TextBox>
                            <span style ="color:red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label3" runat="server" Text="Transport Date :"></asp:Label></td>
                        <td>
                            <uc1:ucCalendar ID="ucCalendar1" runat="server" />                            
                            <span style ="color:red;">*</span>
                        </td>
                        <td><asp:Label ID="Label5" runat="server" Text="Pack No :"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtPackNo" Width ="300px" runat="server"></asp:TextBox>
                            <span style ="color:red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label4" runat="server" Text="Weight :"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtWeight" Width ="300px" runat="server" TextMode="Number"></asp:TextBox>
                        </td>
                        <td><asp:Label ID="Label6" runat="server" Text="Size(Cubic) :"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtSize" Width ="300px" runat="server" TextMode="Number"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>                        
                        <td colspan="2">
                            <asp:Label ID="Label7" runat="server" Text="Width :"></asp:Label> &nbsp;&nbsp;
                            <asp:TextBox ID="txtWidth" Width ="80px" runat="server" TextMode="Number"></asp:TextBox>  &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label8" runat="server" Text="Height :"></asp:Label>   &nbsp;&nbsp;
                            <asp:TextBox ID="txtHeight" Width ="80px" runat="server" TextMode="Number"></asp:TextBox>  &nbsp;&nbsp;&nbsp;&nbsp;                  
                            <asp:Label ID="Label9" runat="server" Text="High :"></asp:Label>   &nbsp;&nbsp;
                            <asp:TextBox ID="txtHigh" Width ="80px" runat="server" TextMode="Number"></asp:TextBox>                       
                        </td>
                        <td><asp:Label ID="Label10" runat="server" Text="Type :"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtType" Width ="300px" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>                        
                        <td><asp:Label ID="Label11" runat="server" Text="Remark :"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtRemark" Width ="300px" runat="server" TextMode="MultiLine" Rows="3"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </fieldset>
            <br />            
            <table class = "width100">
                <tr>
                    <td class ="ItemStyle-center">
                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btnSave" OnClick="btnSave_Click" />&nbsp;&nbsp;
                        <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btnCancel" OnClick="btnReset_Click" />&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
