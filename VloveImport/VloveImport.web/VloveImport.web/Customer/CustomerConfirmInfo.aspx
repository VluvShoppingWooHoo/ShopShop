<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CustomerConfirmInfo.aspx.cs" Inherits="VloveImport.web.Customer.CustomerConfirmInfo" %>

<%@ Register Src="~/UserControls/ucMenubar.ascx" TagName="ucMenubar" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col s2 m2 l2">
            <uc1:ucmenubar id="ucMenubar1" runat="server" />
        </div>
        <div class="col s10 m10 l10 TestBox1">
            ยืนยันข้อมูลการสั่งซื้อ
        <br />
            ข้อมูลสินค้า
        <div class="row s6 m6 l6 TestBox1">
            <asp:GridView ID="gvBasket" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <%--<asp:Image ID="imgItem" runat="server"/>--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HiddenField ID="hdBK_ID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "CUS_BK_ID") %>' />
                            <asp:Label ID="lbItemName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CUS_BK_ITEMNAME") %>'>></asp:Label><br />
                            <asp:Label ID="lbColor" runat="server" Text='<%# "สี " + DataBinder.Eval(Container.DataItem, "CUS_BK_COLOR") %>'>></asp:Label><br />
                            <asp:Label ID="lbSize" runat="server" Text='<%# "ขนาด " + DataBinder.Eval(Container.DataItem, "CUS_BK_SIZE") %>'>></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ราคา">
                        <ItemTemplate>
                            <asp:Label ID="lbPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CUS_BK_PRICE") %>'>></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="จำนวน">
                        <ItemTemplate>
                            <asp:Label ID="lbAmount" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CUS_BK_AMOUNT") %>'>></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="รวมทั้งหมด">
                        <ItemTemplate>
                            <asp:Label ID="lbTotal" runat="server" Text='<%# Convert.ToDouble(DataBinder.Eval(Container.DataItem, "CUS_BK_PRICE")) * Convert.ToDouble(DataBinder.Eval(Container.DataItem, "CUS_BK_AMOUNT")) %>'>></asp:Label>
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
            <br />
            ข้อมูลการขนส่ง
        <br />
            <div class="row s6 m6 l6 TestBox1">
                1. เลือกวิธีขนส่งจากจีนถึงไทย โดย
            <asp:Label ID="lbgroup1" runat="server"></asp:Label>
                <br />
                2. เลือกวิธีขนส่งภายในประเทศ โดย
            <asp:Label ID="lbgroup2" runat="server"></asp:Label>
                <br />
                <%--กรุณาทำการชำระเงินภายใน 3 วัน หลังจาก 3 วัน ใบสั่งซื้อจะถูกยกเลิกโดยอัตโนมัติ--%>
                <br />                
                <button id="btnBack" runat="server" type="submit" onserverclick="btnBack_ServerClick"
                    name="action" class="btn waves-effect orange waves-light">
                    Back                                
                </button>
                <button id="btnConfirm" runat="server" type="submit" onserverclick="btnConfirm_ServerClick"
                    name="action" class="btn waves-effect orange waves-light">
                    Confirm                                
                </button>
            </div>

        </div>
    </div>

    <script type="text/javascript">
        $(function () {
            $("#masterForm").fadeIn(1000);
            $('select').material_select();


        });
    </script>
</asp:Content>
