<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CustomerOrderDetail.aspx.cs" Inherits="VloveImport.web.Customer.CustomerOrderDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <div class="row">
        <div class="col s12 m12 l12">
            <span class="black-text FontHeader bold">รายละเอียดในสั่งซื้อ</span>
        </div>
    </div>
    <div class="row">        
        <div class="col s2 m2 l2">           
            <span class="black-text FontHeader">รหัสใบสั่งซื้อ</span>
        </div>        
        <div class="col s4 m4 l4">  
            <asp:Label ID="lbOrder_Code" runat="server" CssClass="lbCaption"></asp:Label>
        </div>
        <div class="col s2 m2 l2">
            <span class="black-text FontHeader">วันที่สั่งซื้อ</span>
        </div>
        <div class="col s4 m4 l4">        
            <asp:Label ID="lbOrder_Date" runat="server" CssClass="lbCaption"></asp:Label>
        </div> 
    </div>
    <div class="row">        
        <div class="col s2 m2 l2">             
            <span class="black-text FontHeader">ผู้สั่ง</span>
        </div>
        <div class="col s4 m4 l4">
            <asp:Label ID="lbCusName" runat="server" CssClass="lbCaption"></asp:Label>
        </div>
        <div class="col s2 m2 l2">
            <span class="black-text FontHeader">โทรศัพท์</span>
        </div>
        <div class="col s4 m4 l4">        
            <asp:Label ID="lbMobile" runat="server" CssClass="lbCaption"></asp:Label>
        </div> 
    </div>
    <div class="row">        
        <div class="col s2 m2 l2">          
            <span class="black-text FontHeader">ที่อยู่สำหรับจัดส่ง</span>
        </div>
        <div class="col s4 m4 l4">            
            <asp:Label ID="lbAddress" runat="server" CssClass="lbCaption"></asp:Label>
        </div>  
        <div class="col s2 m2 l2">
            <span class="black-text FontHeader">รวมค่าสินค้า (THB)</span>
        </div>
        <div class="col s4 m4 l4">        
            <asp:Label ID="lbTotalItemPrice" runat="server" CssClass="lbCaption right-align" Width="150px"></asp:Label>
        </div>      
    </div>
    <div class="row">        
        <div class="col s2 m2 l2">              
            <span class="black-text FontHeader">วิธีการขนส่ง</span><br />            
        </div>
        <div class="col s4 m4 l4">              
            <asp:Label ID="lbOrderTransport" runat="server" CssClass="lbCaption"></asp:Label>
        </div>     
        <div class="col s2 m2 l2">
            <span class="black-text FontHeader">รวมค่าขนส่งและค่าบริการ (THB)</span>
        </div>
        <div class="col s4 m4 l4">        
            <asp:Label ID="lbTotalTran" runat="server" CssClass="lbCaption right-align" Width="150px"></asp:Label>
        </div> 
    </div>
    <div class="row">        
        <div class="col s2 m2 l2">              
            <span class="black-text FontHeader">สถานะใบสั่งซื้อ</span><br />            
        </div>
        <div class="col s4 m4 l4">             
            <asp:Label ID="lbOrderStatus" runat="server" CssClass="lbCaption"></asp:Label>
        </div>   
        <div class="col s2 m2 l2">
            <asp:Label ID="lbPay" runat="server" CssClass="black-text FontHeader">รอชำระ</asp:Label>
        </div>
        <div class="col s4 m4 l4">        
            <asp:Label ID="lbPayAdd" runat="server" CssClass="lbCaption right-align" Width="150px"></asp:Label>
        </div>   
    </div>
    <div class="row">        
        <div class="col s12 m12 l12">           
            <span class="black-text FontHeader">ทั้งหมด </span> <asp:Label ID="lbOrderAmount" runat="server" CssClass="lbCaption"></asp:Label> 
            <span class="black-text FontHeader"> รายการ</span>
        </div>     
    </div>
     <div class="row">        
        <div class="col s12 m12 l12">
            <%--<asp:Panel ID="panelGrid" runat="server" ScrollBars="Horizontal" Width="950px">--%>
                <asp:GridView ID="gvOrder" runat="server" AutoGenerateColumns="false" CssClass="HeaderFreez"
                    OnRowDataBound="gvOrder_RowDataBound">
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="70px" ItemStyle-Height="70px">
                            <ItemTemplate>                           
                                <asp:Image ID="imgItem" runat="server" Width="50px" Height="70px"
                                    ImageUrl='<%# DataBinder.Eval(Container.DataItem, "OD_PICURL") %>'/>
                                <asp:Label ID="lbShopName" runat="server" Width ="90%"></asp:Label>                            
                                <asp:Label ID="lbRemark" runat="server" Width ="900px" Visible="false"
                                    CssClass="red-text bold word-wrap"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="สินค้า" ItemStyle-Width="400px">
                            <ItemTemplate>
                                <asp:HiddenField ID="hdBK_ID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "OD_ID") %>' />
                                <asp:HyperLink ID="hlItemName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OD_ITEMNAME") %>'
                                    NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "OD_URL").ToString().Trim().Replace("amp;","") %>'></asp:HyperLink> <br />  <%--OD_SIZE--%>
                                <asp:Label ID="lbSize" runat="server" Text='<%# "ขนาด " + DataBinder.Eval(Container.DataItem, "OD_SIZE") %>'></asp:Label><br />
                                <asp:Label ID="lbColor" runat="server" Text='<%# "สี " + DataBinder.Eval(Container.DataItem, "OD_COLOR") %>'
                                    Visible='<%# DataBinder.Eval(Container.DataItem, "OD_COLOR").ToString().StartsWith("http") ? false : true %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ราคาต่อชิ้น" ItemStyle-Width="90px">
                            <ItemTemplate>
                                <asp:Label ID="lbPrice" runat="server" CssClass="right-align" Width="80%"
                                    Text='<%# NumberStringtoString(DataBinder.Eval(Container.DataItem, "PRICE_TH").ToString(), "Money") + "(THB)" %>'></asp:Label>
                                <br />
                                <asp:Label ID="ibPrice_Y" runat="server" CssClass="right-align" Width="80%"
                                    Text='<%# NumberStringtoString(DataBinder.Eval(Container.DataItem, "OD_PRICE_ACTIVE").ToString(), "Money") + "(¥)" %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="จำนวน<br/>ที่สั่ง" ItemStyle-Width="90px">
                            <ItemTemplate>
                                <asp:Label ID="lbAmount" runat="server" CssClass="right-align" Width="80%"
                                    Text='<%# NumberStringtoString(DataBinder.Eval(Container.DataItem, "OD_AMOUNT").ToString(), "Amount") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="จำนวน<br/>ที่ได้รับ" ItemStyle-Width="90px">
                            <ItemTemplate>
                                <asp:Label ID="lbAmountActive" runat="server" CssClass="right-align" Width="80%"
                                    Text='<%# NumberStringtoString(DataBinder.Eval(Container.DataItem, "OD_AMOUNT_ACTIVE").ToString(), "Amount") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="รวมราคาสินค้า" ItemStyle-Width="90px">
                            <ItemTemplate>
                                <asp:Label ID="lbTotalItemPrice" runat="server" CssClass="right-align" Width="80%"
                                    Text='<%# NumberStringtoString(DataBinder.Eval(Container.DataItem, "TOTALITEMAMOUNT_TH").ToString(), "Money") + "(THB)" %>'></asp:Label>
                                <br />
                                <asp:Label ID="lbTotalItemPrice_Y" runat="server" CssClass="right-align" Width="80%"
                                    Text='<%# NumberStringtoString(DataBinder.Eval(Container.DataItem, "TOTALITEMAMOUNT").ToString(), "Money") + "(¥)" %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ค่าขนส่ง<br/>ในจีน" ItemStyle-Width="90px">
                            <ItemTemplate>
                                <asp:Label ID="lbTransportChinaAmount" runat="server" CssClass="right-align" Width="80%"
                                    Text='<%# NumberStringtoString(DataBinder.Eval(Container.DataItem, "TRANSPORT_CHINA_PRICE").ToString(), "Money") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ค่าขนส่ง<br/>ระหว่างประเทศ" ItemStyle-Width="90px">
                            <ItemTemplate>
                                <asp:Label ID="lbTransportImportAmount" runat="server" CssClass="right-align" Width="80%"
                                    Text='<%# NumberStringtoString(DataBinder.Eval(Container.DataItem, "TRANSPORT_THAI_PRICE").ToString(), "Money") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ค่าขนส่ง<br/>ในไทย(THB)" ItemStyle-Width="90px">
                            <ItemTemplate>
                                <asp:Label ID="lbTransportThaiAmount" runat="server" CssClass="right-align" Width="80%"
                                    Text='<%# NumberStringtoString(DataBinder.Eval(Container.DataItem, "TRANSPORT_CUSTOMER_PRICE").ToString(), "Money") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="วันที่<br/>จัดส่งสินค้า" ItemStyle-Width="90px">
                            <ItemTemplate>
                                <asp:Label ID="lbTransportDate" runat="server" CssClass="right-align" Width="80%"
                                    Text='<%# DateStringtoString(DataBinder.Eval(Container.DataItem, "OD_TRANS_STAMP").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="รวมทั้งหมด (THB)">
                            <ItemTemplate>
                                <asp:Label ID="lbTotal" runat="server" CssClass="right-align" Width="80%"
                                    Text='<%# NumberStringtoString(DataBinder.Eval(Container.DataItem, "TOTAL").ToString(), "Money") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                    </Columns>
                    <HeaderStyle BackColor="Orange" />
                </asp:GridView>
            <%--</asp:Panel>  --%>                     
        </div>     
    </div>
    <div class="row">
        <div class="col s12 m12 l12">
            <button id="btnBack" runat="server" type="submit" onserverclick="btnBack_ServerClick"
                name="action" class="btn waves-effect orange waves-light">
                ย้อนกลับ                                
            </button>&nbsp;&nbsp;
            <button id="btnPay" runat="server" type="submit" onserverclick="btnPay_ServerClick"
                name="action" class="btn waves-effect orange waves-light">
                ชำระเงิน                                
            </button>&nbsp;&nbsp;
            <button id="btnPrint" runat="server" type="submit" onserverclick="btnPrint_ServerClick"
                name="action" class="btn waves-effect orange waves-light">
                พิมพ์                              
            </button>&nbsp;&nbsp;
            <%--<button id="btnPrint" runat="server" type="submit" onserverclick="btnPrint_ServerClick"
                name="action" class="btn waves-effect orange waves-light">
                พิมพ์                                
            </button>--%>
        </div>
    </div>
    <div class="row"> 
        <span class="FontHeader black-text">ข้อมูลการชำระเงิน</span>       
        <asp:GridView ID="gvTran" runat="server" AutoGenerateColumns="false" BorderColor="Orange" BorderWidth="2px" Width="800px">
            <Columns>
                <asp:BoundField DataField="TRAN_DATE" HeaderText="วันที่ชำระเงิน" HeaderStyle-Width="200px"/>
                <asp:TemplateField HeaderText="จำนวนเงิน (บาท)" ItemStyle-Width="150px">
                    <ItemTemplate>
                        <asp:Label ID="lbTransportThaiAmount" runat="server" CssClass="right-align" Width="70%"
                            Text='<%# NumberStringtoString(DataBinder.Eval(Container.DataItem, "TRAN_AMOUNT").ToString(), "Money") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:BoundField DataField="TRAN_AMOUNT" HeaderText="" />--%>
                <%--<asp:BoundField DataField="TRAN_STATUS_DESC" HeaderText="สถานะ" />--%>
                <asp:BoundField DataField="TRAN_REMARK" HeaderText="หมายเหตุ" HeaderStyle-Width="400px"/>
            </Columns>
        </asp:GridView> 
    </div>
    <script type="text/javascript">
        $(function () {
            SetFadeout();
        });
    </script>
</asp:Content>

