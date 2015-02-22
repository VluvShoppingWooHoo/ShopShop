<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/master_page_batt.Master" AutoEventWireup="true" CodeBehind="page_ms_bank.aspx.cs" Inherits="VloveImport.web.Administrator.page_ms_bank" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div >
    ข้อมูลธนาคาร
    <br /><br />
    <asp:Button ID="btnAdd" runat="server" Text="Add Bank" OnClick="btnAdd_Click" />
         
    <hr style="width:100%; text-align:left; background-color :#FFD700; height:5px; color: #6ACAE1; border :0;"/>

<table width ="100%">
    <tr>
        <td align ="center">
            <asp:GridView ID="gv_cus_bank" runat="server" AutoGenerateColumns="False" Width ="90%" DataKeyNames="CUS_ADD_ID" OnRowCreated="gv_cus_address_RowCreated">
                <Columns>
                    <asp:BoundField HeaderText="ลำดับ" DataField="ROW_INDEX" >
                    <ItemStyle HorizontalAlign="Right" Width="5%" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="ชื่อลูกค้า" DataField="CUS_ADD_CUS_NAME" >
                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="ที่อยู่" DataField="ADDRESS_FULL">
                    <ItemStyle HorizontalAlign="Left" Width="50%" />
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

</asp:Content>
