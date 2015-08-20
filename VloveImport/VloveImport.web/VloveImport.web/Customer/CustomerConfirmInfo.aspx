<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CustomerConfirmInfo.aspx.cs" Inherits="VloveImport.web.Customer.CustomerConfirmInfo" %>
<%@ Import Namespace="VloveImport.data" %>
<%@ Register Src="~/UserControls/ucMenubar.ascx" TagName="ucMenubar" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col s12 m12 l12 TestBox1">
            <span class="bold FontHeader orange-text">ยืนยันข้อมูลการสั่งซื้อ</span>            
            <br /><br />
            <span class="bold FontHeader2 orange-text">ข้อมูลสินค้า</span>            
            
        <div class="row s6 m6 l6 TestBox1">
            <asp:GridView ID="gvBasket" runat="server" AutoGenerateColumns="false" Visible="false" OnRowDataBound="gvBasket_RowDataBound">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="70px" ItemStyle-Height="70px">
                        <ItemTemplate>
                            <asp:Image ID="imgItem" runat="server" Width="50px" Height="70px"
                                ImageUrl='<%# DataBinder.Eval(Container.DataItem, "CUS_BK_PICURL") %>'/>
                            <asp:Label ID="lbShopName" runat="server" Width ="90%" ></asp:Label>                            
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="สินค้า">
                        <ItemTemplate>
                            <asp:HiddenField ID="hdBK_ID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "CUS_BK_ID") %>' />
                            <asp:Label ID="lbItemName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CUS_BK_ITEMNAME") %>'></asp:Label>    <br />                           
                            <%--<asp:HyperLink ID="hlItemName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CUS_BK_ITEMNAME") %>'
                                NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "CUS_BK_URL") %>'></asp:HyperLink>  --%>
                            <asp:Label ID="lbSize" runat="server" Text='<%# "ขนาด " + DataBinder.Eval(Container.DataItem, "CUS_BK_SIZE") %>'></asp:Label><br />
                            <asp:Label ID="lbColor" runat="server" Text='<%# "สี " + DataBinder.Eval(Container.DataItem, "CUS_BK_COLOR") %>'
                                Visible='<%# DataBinder.Eval(Container.DataItem, "CUS_BK_COLOR").ToString().StartsWith("http") ? false : true %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ราคา (¥)">
                        <ItemTemplate>
                            <asp:Label ID="lbPrice" runat="server" CssClass="right-align" Width="50%"
                                Text='<%# NumberStringtoString(DataBinder.Eval(Container.DataItem, "CUS_BK_PRICE").ToString(), "Money") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="จำนวน">
                        <ItemTemplate>
                            <asp:Label ID="lbAmount" runat="server" CssClass="right-align" Width="50%"
                                Text='<%# NumberStringtoString(DataBinder.Eval(Container.DataItem, "CUS_BK_AMOUNT").ToString(), "Amount") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="รวมทั้งหมด (¥)">
                        <ItemTemplate>
                            <asp:Label ID="lbTotal" runat="server" CssClass="right-align" Width="50%"
                                Text='<%# NumbertoString(Convert.ToDouble(DataBinder.Eval(Container.DataItem, "CUS_BK_PRICE")) * 
                            Convert.ToDouble(DataBinder.Eval(Container.DataItem, "CUS_BK_AMOUNT")), "Money") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle BackColor="Orange" />
            </asp:GridView>
            <asp:MultiView ID="mView" runat="server" ActiveViewIndex="0" Visible="false">               
                <asp:View ID="vPI" runat="server">
                    หมายเลข PI : <asp:Label ID="lbPINo" runat="server"></asp:Label><br />
                    จำนวน : <asp:Label ID="lbAmount" runat="server"></asp:Label><br />
                    รูป Upload <br />
                    <asp:Image ID="imgURL" runat="server" Width="200px" Height="200px"/>
                </asp:View>
                <asp:View ID="vTRANS" runat="server">
                    <asp:GridView ID="gvTrans" runat="server" AutoGenerateColumns="false" Width="400px" BorderColor="Orange" BorderWidth="2px">
                        <HeaderStyle BackColor="Gray" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>ลำดับ</HeaderTemplate>
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>เลข Tracking</HeaderTemplate>
                                <ItemTemplate>
                                    <%# ((OrderData)Container.DataItem).TRACKING_NO %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>เลข Shop</HeaderTemplate>
                                <ItemTemplate>
                                    <%# ((OrderData)Container.DataItem).SHOP_ORDER_ID %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>หมายเหตุ</HeaderTemplate>
                                <ItemTemplate>
                                    <%# ((OrderData)Container.DataItem).OD_REMARK %>
                                </ItemTemplate>
                            </asp:TemplateField>                            
                        </Columns>
                    </asp:GridView>
                </asp:View>
            </asp:MultiView>            
        </div>
            <br />
            <span class="bold FontHeader2 orange-text">ข้อมูลการขนส่ง</span>            
        <br />
            <div class="row s6 m6 l6 TestBox1">
                1. เลือกวิธีขนส่งจากจีนถึงไทย โดย
            <asp:Label ID="lbgroup1" runat="server"></asp:Label>
                <br />
                2. เลือกวิธีขนส่งภายในประเทศ โดย
            <asp:Label ID="lbgroup2" runat="server"></asp:Label>
                <br />
                3. ที่อยู่ในการจัดส่ง
            <asp:Label ID="lbgroup3" runat="server"></asp:Label>
                <br />
                <%--กรุณาทำการชำระเงินภายใน 3 วัน หลังจาก 3 วัน ใบสั่งซื้อจะถูกยกเลิกโดยอัตโนมัติ--%>
                <br />                                
            </div>
            <div id="Order" runat="server" visible="false">
                <br />
                <span class="bold FontHeader orange-text">สรุปยอดค่าใช้จ่าย</span>            
                <br />
                <div class="row s6 m6 l6 TestBox1">
                    <asp:Label ID="lbPayOrder" runat="server"></asp:Label> <br /><br />
                    <span class="bold FontHeader2 orange-text">วิธีคิดค่าใช้จ่าย</span> <br />           
                    ชำระเงินรอบแรก = ค่าสินค้า(บาท) + ค่าขนส่ง (10% ของค่าสินค้า) <br />                
                    ชำระเงินรอบที่ 2 = ค่าขนส่ง (เฉพาะค่าขนส่งที่เกินจาก 10%)                                       
                </div>
                <br />                
            </div>  
            <div id="PI" runat="server" visible="false">
                <br />
                <span class="bold FontHeader orange-text">สรุปยอดค่าใช้จ่าย</span>            
                <br />
                <div class="row s6 m6 l6 TestBox1">
                    <asp:Label ID="lbPayPI" runat="server"></asp:Label> <br /><br />
                    <span class="bold FontHeader2 orange-text">วิธีคิดค่าใช้จ่าย</span> <br />           
                    ชำระเงินรอบแรก = สินค้าฝากจ่าย(บาท) + ค่าขนส่ง (10% ของค่าสินค้า) + ค่าดำเนินการ(<asp:Label ID="lbPI" runat="server"></asp:Label>) <br />                
                    ชำระเงินรอบที่ 2 = ค่าขนส่ง (เฉพาะค่าขนส่งที่เกินจาก 10%)                                       
                </div>
                <br />                
            </div>   
            <div id="Trans" runat="server" visible="false">
                <br />
                <div class="row s6 m6 l6 TestBox1">
                    <asp:Label ID="lbPayTrans" runat="server"></asp:Label> <br /><br />
                    <span class="bold FontHeader2 orange-text">วิธีคิดค่าใช้จ่าย</span> <br />           
                    ชำระเงินรอบแรก = ค่าขนส่ง (10% ของค่าสินค้า) <br />                
                    ชำระเงินรอบที่ 2 = ค่าขนส่ง (เฉพาะค่าขนส่งที่เกินจาก 10%)                                       
                </div>
                <br />                
            </div>   
            <div class="row s6 m6 l6 TestBox1">
                <button id="btnBack" runat="server" type="submit" onserverclick="btnBack_ServerClick"
                    name="action" class="btn waves-effect orange waves-light">
                    ย้อนกลับ                                
                </button>
                <button id="btnConfirm" runat="server" type="submit" onserverclick="btnConfirm_ServerClick"
                    name="action" class="btn waves-effect orange waves-light">
                    ยืนยัน                                
                </button>
            </div>        
        </div>
    </div>

    <script type="text/javascript">
        $(function () {
            SetFadeout();
            $('select').material_select();


        });
    </script>
</asp:Content>
