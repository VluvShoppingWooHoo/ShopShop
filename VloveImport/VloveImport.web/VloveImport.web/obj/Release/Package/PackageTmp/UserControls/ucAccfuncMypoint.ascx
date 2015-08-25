<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAccfuncMypoint.ascx.cs" Inherits="VloveImport.web.UserControls.ucAccfuncMypoint" %>
<br /><br />
<%--<span style="color: orange; font-size:x-large; font-weight:bold;">เปิดให้บริการเร็วๆนี้</span> --%>
<b>คะแนนสะสมปัจจุบัน</b> : <b>
    <asp:Label ID="lbMyPoint" runat="server"></asp:Label> คะแนน</b>
<br />
<br />
<b>
    <span style="color: red;">การสะสมคะแนน : ยอดการสั่งซื้อ ฝากจ่าย ฝากส่ง ทุกๆ 1000 บาท รับ 1 คะแนน
    </span>
</b>
<br />
<br />
<div class="row s10 m10 l10"> 
    <br />
    <div class="row s8 m8 l8">
        <asp:GridView ID="gvVoucher" runat="server" AutoGenerateColumns="false" RowStyle-VerticalAlign="Top" Width="750px"
            BorderColor="Red" BorderStyle="Solid" BorderWidth="2px">
            <Columns>
                <asp:TemplateField ItemStyle-CssClass="top">                    
                    <ItemTemplate>
                        <button type="button" class="btn waves-effect orange waves-light" name="action">
                            <asp:Button ID="btnVoucher" runat="server" Text="แลก Voucher" OnClick="btnVoucher_Click"
                                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "MV_ID") %>'
                                CommandName='<%# DataBinder.Eval(Container.DataItem, "MV_POINT") %>'/>
                            </button>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="MV_NAME" ItemStyle-VerticalAlign="Top" HeaderText="รายละเอียด"/>
                <asp:BoundField DataField="MV_POINT" ItemStyle-VerticalAlign="Top" HeaderText="คะแนน"/>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Image ID="img" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "MV_URL") %>' BorderWidth="1px"
                            Width="200px" Height="200px"/>
                    </ItemTemplate>
                </asp:TemplateField>                
                
            </Columns>
            <HeaderStyle BorderColor="Red" BorderStyle="Solid" BorderWidth="2px" />
        </asp:GridView> 
    </div>  
    <br />
    <br />
    
</div>