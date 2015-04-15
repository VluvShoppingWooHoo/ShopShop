<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CustomerOrderList.aspx.cs" Inherits="VloveImport.web.Customer.CustomerOrderList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col s12 m12 l12 TestBox1">
            <span class="black-text FontHeader bold">ใบสั่งซื้อของฉัน</span>
        <br /><br />
            <asp:GridView ID="gvOrder" CssClass="GridStyle" runat="server" AutoGenerateColumns="false" OnDataBound="gvOrder_DataBound"
                AllowPaging="true" PageSize="10" OnPageIndexChanging="gvOrder_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="รหัสใบสั่งซื้อ" ItemStyle-Width="130px">
                        <ItemTemplate>
                            <asp:HiddenField ID="hdOrder_ID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ORDER_ID") %>' />
                            <asp:HiddenField ID="hdOrder_Pay" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ORDER_PAY") %>' />
                            <asp:HyperLink ID="hlOrderCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ORDER_CODE") %>'
                                NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "ORDER_ID") %>'></asp:HyperLink>
                            <%--<asp:Label ID="lbOrderCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ORDER_CODE") %>'></asp:Label>--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="วันที่สั่งซื้อ" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbOrderDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ORDER_DATE") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="สถานะ" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ORDER_DESC") %>'></asp:Label>
                            <asp:HiddenField ID="hddStatus" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ORDER_STATUS") %>'></asp:HiddenField>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="รวมรายการ"  ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbAmount" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OD_AMOUNT") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="รวมราคาสินค้า" ItemStyle-Height="80px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbPRICE" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OD_PRICE") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ชำระเพิ่ม" ItemStyle-Height="80px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbPRICE2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OD_PRICE") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ค่าขนส่งในประเทศ" ItemStyle-Height="80px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbPRICE3" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ORDER_PAY") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="80px">
                        <ItemTemplate>
                            <button type="button" class="btn waves-effect orange waves-light" name="action" style="height:60%">
                                <asp:Button ID="btnPay" runat="server" Text="ชำระเงิน" OnClick="btnPay_Click" CssClass=""
                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ORDER_ID") %>' />
                            </button>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="80px">
                        <ItemTemplate>
                            <button type="button" class="btn waves-effect orange waves-light" name="action" style="height:60%">
                                <asp:Button ID="btnDelete" runat="server" Text="ลบใบสั่งซื้อ" OnClick="btnDelete_Click" CssClass=""
                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ORDER_ID") %>' OnClientClick="return confirm('ต้องการลบใบสั่งซื้อ?');" />
                            </button>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Image ID="imgItem" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle BackColor="Orange" />
            </asp:GridView>
        </div>
    </div>

    <script type="text/javascript">
        $(function () {
            SetFadeout();
        });
    </script>
</asp:Content>

