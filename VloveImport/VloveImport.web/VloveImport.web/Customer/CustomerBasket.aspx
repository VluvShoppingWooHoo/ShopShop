<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CustomerBasket.aspx.cs" Inherits="VloveImport.web.Customer.CustomerBasket" %>

<%@ Register Src="~/UserControls/ucMenubar.ascx" TagName="ucMenubar" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="updatePanel" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col s12 m12 l12 TestBox1" style="min-height:500px;">
                    <span class="bold FontHeader orange-text">ตะกร้าสินค้าของฉัน</span><br />                        
                    <div class="col s11 m11 l11">
                        <span class="bold FontHeader2 red-text">1 ใบสั่งซื้อสามารถสั่งได้ไม่เกิน 10 รายการ และมูลค่าของใบสั่งซื้อไม่ต้ำกว่า 100 หยวน</span>
                    </div>
                    <div class="col s1 m1 l1">
                        <span class="bold FontHeader2 orange-text"><asp:Label ID="lbTotal" runat="server"></asp:Label></span>
                    </div>
                    <br />
                    <br />
                    <asp:GridView ID="gvBasket" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" 
                        OnPageIndexChanging="gvBasket_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="30px">
                                <ItemTemplate>                                    
                                    <asp:CheckBox ID="cbItem" runat="server" Text=" " OnCheckedChanged="cbItem_CheckedChanged" />
                                    <asp:HiddenField ID="hdBK_ID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "CUS_BK_ID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="70px" ItemStyle-Height="70px">
                                <ItemTemplate>                            
                                    <asp:Image ID="imgItem" runat="server" Width="50px" Height="70px"
                                        ImageUrl='<%# DataBinder.Eval(Container.DataItem, "CUS_BK_PICURL") %>'/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="สินค้า">
                                <ItemTemplate>
                                    <asp:HyperLink ID="hlItemName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CUS_BK_ITEMNAME") %>'
                                        NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "CUS_BK_URL") %>'></asp:HyperLink> <br />                                                        
                                    <asp:Label ID="lbSize" runat="server" Text='<%# "ขนาด " + DataBinder.Eval(Container.DataItem, "CUS_BK_SIZE") %>'></asp:Label> <br />
                                    <asp:Label ID="lbColor" runat="server" Text='<%# "สี " + DataBinder.Eval(Container.DataItem, "CUS_BK_COLOR") %>' 
                                        Visible='<%# DataBinder.Eval(Container.DataItem, "CUS_BK_COLOR").ToString().StartsWith("http") ? false : 
                                    DataBinder.Eval(Container.DataItem, "CUS_BK_COLOR").ToString() == "" ? false : true %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ราคา">
                                <ItemTemplate>
                                    <asp:Label ID="lbPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CUS_BK_PRICE") %>'>></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="จำนวน">
                                <ItemTemplate>
                                    <asp:MultiView ID="mvA" runat="server" ActiveViewIndex="0">
                                        <asp:View ID="vA1" runat="server">
                                            <asp:Label ID="lbAmount" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CUS_BK_AMOUNT") %>'>></asp:Label>
                                        </asp:View>
                                        <asp:View ID="vA2" runat="server">
                                            <asp:TextBox ID="txtAmount" runat="server" Width="50px"
                                                Text='<%# DataBinder.Eval(Container.DataItem, "CUS_BK_AMOUNT") %>'></asp:TextBox>
                                        </asp:View>
                                    </asp:MultiView>                                    
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="รวมทั้งหมด">
                                <ItemTemplate>
                                    <asp:Label ID="lbTotal" runat="server" Text='<%# Convert.ToDouble(DataBinder.Eval(Container.DataItem, "CUS_BK_PRICE")) * Convert.ToDouble(DataBinder.Eval(Container.DataItem, "CUS_BK_AMOUNT")) %>'>></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:MultiView ID="mvB" runat="server" ActiveViewIndex="0">
                                        <asp:View ID="vB1" runat="server">
                                            <asp:ImageButton ID="imbEdit" runat="server" ImageUrl="~/Images/icon/b_edit.png" 
                                                Width="15px" Height="15px" OnClick="imbEdit_Click" />
                                        </asp:View>
                                        <asp:View ID="vB2" runat="server">
                                            <asp:ImageButton ID="imgbtn_Updateprod_amount" runat="server" ImageUrl="~/Images/icon/check-icon.png" 
                                                Width="15px" Height="15px" OnClick="imgbtn_Updateprod_amount_Click" />
                                        &nbsp;&nbsp;
                                        <asp:ImageButton ID="imgbtn_Cancelprod_amount" runat="server" ImageUrl="~/Images/icon/Close-2-icon.png" 
                                            Width="15px" Height="15px" OnClick="imgbtn_Cancelprod_amount_Click" />
                                        </asp:View>
                                    </asp:MultiView> 
                                    
                                </ItemTemplate>
                            </asp:TemplateField>                            
                        </Columns>
                        <HeaderStyle BackColor="Orange" />
                    </asp:GridView>            
                </div>
                <div class="col s12 m12 l12 TestBox1">
                    <%--<button id="btnOrder" runat="server" type="submit" onserverclick="btnOrder_ServerClick"
                        name="action" class="btn waves-effect orange waves-light">
                        Order                                
                    </button>--%>
                    <asp:Button ID="btnOrder" runat="server" OnClick="btnOrder_Click" Text="Order" />
                </div>
            </div>
            </ContentTemplate>
        <%--<Triggers>
            <asp:PostBackTrigger ControlID="gvBasket" />
        </Triggers>--%>
    </asp:UpdatePanel>
    <script type="text/javascript">
        $(function () {
            SetFadeout();
        });
    </script>
</asp:Content>

