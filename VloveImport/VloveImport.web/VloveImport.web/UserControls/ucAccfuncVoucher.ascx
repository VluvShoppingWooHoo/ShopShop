<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAccfuncVoucher.ascx.cs" Inherits="VloveImport.web.UserControls.ucAccfuncVoucher" %>
<br /><br />
<%--<span style="color: orange; font-size:x-large; font-weight:bold;">เปิดให้บริการเร็วๆนี้</span> --%>
<b>บัตรกำนัลของฉัน</b> : <b>    
<br />
<br />
<div id="divMyVoucher" runat="server" class="row s8 m8 l8" style="border: 2px solid red;">        
    <asp:GridView ID="gvVoucher" runat="server" AutoGenerateColumns="false" Width="700px">
        <Columns>
            <asp:TemplateField ItemStyle-Width="20px">
                <ItemTemplate>
                    &nbsp;
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="220px">
                <ItemTemplate>
                    <asp:Image ID="img" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "MV_URL") %>' BorderWidth="1px"
                        Width="200px" Height="200px"/>
                </ItemTemplate>
            </asp:TemplateField>                           
            <asp:BoundField DataField="VOUCHER_CODE" HeaderText="หมายเลข Voucher" ItemStyle-Width="100px"/>
            <asp:BoundField DataField="STATUS_DESCRIPTION" HeaderText="สถานะ" ItemStyle-Width="100px"/>
            <asp:TemplateField ItemStyle-Width="100px" HeaderText="วันที่ใช้ Voucher" >
                <ItemTemplate>
                    <%# ConvertDate(DataBinder.Eval(Container.DataItem, "USE_DATE").ToString()) %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>       
          
    <br />
</div>