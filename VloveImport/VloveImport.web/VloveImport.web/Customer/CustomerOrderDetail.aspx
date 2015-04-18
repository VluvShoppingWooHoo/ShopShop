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
        <div class="col s10 m10 l10">           
            <asp:Label ID="lbAddress" runat="server" CssClass="lbCaption"></asp:Label>
        </div>       
    </div>
    <div class="row">        
        <div class="col s2 m2 l2">              
            <span class="black-text FontHeader">วิธีการขนส่ง</span><br />            
        </div>
        <div class="col s10 m10 l10">             
            <asp:Label ID="lbOrderTransport" runat="server" CssClass="lbCaption"></asp:Label>
        </div>     
    </div>
    <div class="row">        
        <div class="col s2 m2 l2">              
            <span class="black-text FontHeader">สถานะใบสั่งซื้อ</span><br />            
        </div>
        <div class="col s10 m10 l10">             
            <asp:Label ID="lbOrderStatus" runat="server" CssClass="lbCaption"></asp:Label>
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
            <asp:GridView ID="gvOrder" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvOrder_RowDataBound">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="70px" ItemStyle-Height="70px">
                        <ItemTemplate>
                            <asp:Label ID="lbShopName" runat="server"></asp:Label>
                            <asp:Image ID="imgItem" runat="server" Width="50px" Height="70px"
                                ImageUrl='<%# DataBinder.Eval(Container.DataItem, "OD_PICURL") %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="สินค้า">
                        <ItemTemplate>
                            <asp:HiddenField ID="hdBK_ID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "OD_ID") %>' />
                            <asp:HyperLink ID="hlItemName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OD_ITEMNAME") %>'
                                NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "OD_URL") %>'></asp:HyperLink> <br />  <%--OD_SIZE--%>
                            <asp:Label ID="lbSize" runat="server" Text='<%# "ขนาด " + DataBinder.Eval(Container.DataItem, "SHOPNAME") %>'></asp:Label><br />
                            <asp:Label ID="lbColor" runat="server" Text='<%# "สี " + DataBinder.Eval(Container.DataItem, "OD_COLOR") %>'
                                Visible='<%# DataBinder.Eval(Container.DataItem, "OD_COLOR").ToString().StartsWith("http") ? false : true %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ราคา">
                        <ItemTemplate>
                            <asp:Label ID="lbPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OD_PRICE") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="จำนวนที่สั่ง">
                        <ItemTemplate>
                            <asp:Label ID="lbAmount" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OD_AMOUNT") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="จำนวนที่ได้รับ">
                        <ItemTemplate>
                            <asp:Label ID="lbAmountActive" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OD_AMOUNT_ACTIVE") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="รวมทั้งหมด">
                        <ItemTemplate>
                            <asp:Label ID="lbTotal" runat="server" Text='<%# Convert.ToDouble(DataBinder.Eval(Container.DataItem, "OD_PRICE")) * Convert.ToDouble(DataBinder.Eval(Container.DataItem, "OD_AMOUNT_ACTIVE")) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle BackColor="Orange" />
            </asp:GridView>
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
            </button>
        </div>
    </div>
    <div class="row"> 
        <span class="FontHeader black-text">ข้อมูลการชำระเงิน</span>       
        <asp:GridView ID="gvTran" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="TRAN_DATE" HeaderText="วันที่ชำระเงิน" />
                <asp:BoundField DataField="TRAN_AMOUNT" HeaderText="จำนวนเงิน" />
                <asp:BoundField DataField="TRAN_STATUS_DESC" HeaderText="สถานะ" />
                <asp:BoundField DataField="TRAN_REMARK" HeaderText="หมายเหตุ" />
            </Columns>
        </asp:GridView> 
    </div>
    <script type="text/javascript">
        $(function () {
            SetFadeout();
        });
    </script>
</asp:Content>

