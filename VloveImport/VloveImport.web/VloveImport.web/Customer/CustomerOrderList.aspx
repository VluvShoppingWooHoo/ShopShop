<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CustomerOrderList.aspx.cs" Inherits="VloveImport.web.Customer.CustomerOrderList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">        
        <div class="col s12 m12 l12 TestBox1">
            ใบสั่งซื้อของฉัน
        <br />
            <asp:GridView ID="gvOrder" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>                            
                            <asp:HiddenField ID="hdOrder_ID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ORDER_ID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="วันที่สั่งซื้อ">
                        <ItemTemplate>
                            <asp:Label ID="lbItemName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ORDER_DATE") %>'>></asp:Label><br />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lbItemName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OD_ITEMNAME") %>'>></asp:Label><br />
                            <asp:Label ID="lbColor" runat="server" Text='<%# "สี " + DataBinder.Eval(Container.DataItem, "OD_COLOR") %>'>></asp:Label><br />
                            <asp:Label ID="lbSize" runat="server" Text='<%# "ขนาด " + DataBinder.Eval(Container.DataItem, "OD_SIZE") %>'>></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ราคา">
                        <ItemTemplate>
                            <asp:Label ID="lbPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OD_PRICE") %>'>></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="จำนวน">
                        <ItemTemplate>
                            <asp:Label ID="lbAmount" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OD_AMOUNT") %>'>></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="รวมทั้งหมด">
                        <ItemTemplate>
                            <asp:ImageButton ID="imbPay" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ORDER_ID") %>' 
                                 OnClick="imbPay_Click"/>
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
            $("#masterForm").fadeIn(1000);
        });
    </script>
</asp:Content>

