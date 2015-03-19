﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CustomerBasket.aspx.cs" Inherits="VloveImport.web.Customer.CustomerBasket" %>

<%@ Register Src="~/UserControls/ucMenubar.ascx" TagName="ucMenubar" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col s12 m12 l12 TestBox1" style="min-height:500px;">
            ตะกร้าสินค้าของฉัน
        <br />
            <asp:GridView ID="gvBasket" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="cbItem" runat="server" Width="5px"/>
                            <asp:HiddenField ID="hdBK_ID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "CUS_BK_ID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <%--<asp:Image ID="imgItem" runat="server"/>--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
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
        <div class="col s12 m12 l12 TestBox1">
            <button id="btnOrder" runat="server" type="submit" onserverclick="btnOrder_ServerClick"
                name="action" class="btn waves-effect orange waves-light">
                Order                                
            </button>
        </div>
    </div>

    <script type="text/javascript">
        $(function () {
            $("#masterForm").fadeIn(1000);
        });
    </script>
</asp:Content>

