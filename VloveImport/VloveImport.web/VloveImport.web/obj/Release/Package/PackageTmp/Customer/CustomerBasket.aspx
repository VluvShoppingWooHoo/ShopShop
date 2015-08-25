<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CustomerBasket.aspx.cs" Inherits="VloveImport.web.Customer.CustomerBasket" %>

<%@ Register Src="~/UserControls/ucMenubar.ascx" TagName="ucMenubar" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="updatePanel" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col s12 m12 l12 TestBox1" style="min-height:500px;">
                    <span class="bold FontHeader orange-text">ตะกร้าสินค้าของฉัน</span><br />                        
                    <div class="col s10 m10 l10">
                        <%--<span class="bold FontHeader2 red-text">มูลค่าของใบสั่งซื้อไม่ต้ำกว่า 100 หยวน</span>--%>
                    </div>
                    <div class="col s2 m2 l2">
                        <span class="bold FontHeader2 orange-text"><asp:Label ID="lbTotal" runat="server"></asp:Label></span>
                    </div>
                    <div class="col s12 m12 l12">
                        <br />
                        <%--OnPageIndexChanging="gvBasket_PageIndexChanging" AllowPaging="true"--%>
                        <asp:GridView ID="gvBasket" runat="server" AutoGenerateColumns="false"
                             OnRowDataBound="gvBasket_RowDataBound">
                            <Columns>
                                <asp:TemplateField ItemStyle-Width="30px">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="cbItemAll" runat="server" Text=" " OnCheckedChanged="cbItemAll_CheckedChanged" 
                                            AutoPostBack="true"/>
                                    </HeaderTemplate>
                                    <ItemTemplate>                                    
                                        <asp:CheckBox ID="cbItem" runat="server" Text=" " OnCheckedChanged="cbItem_CheckedChanged" 
                                            AutoPostBack="true"/>
                                        <asp:Label ID="lbShopName" runat="server" Width ="90%" Text='<%# DataBinder.Eval(Container.DataItem, "SHOPHEADER") %>'></asp:Label>                            
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
                                        <asp:Label ID="lbItemName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CUS_BK_ITEMNAME") %>'></asp:Label>                             
                                        <asp:HiddenField ID="hddShopName" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "CUS_BK_SHOPNAME") %>'></asp:HiddenField>                             
                                        <asp:HiddenField ID="hddItemUrl" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "CUS_BK_URL") %>'></asp:HiddenField>                             
                                        <%--<asp:HyperLink ID="hlItemName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CUS_BK_ITEMNAME") %>'
                                            NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "CUS_BK_URL") %>'></asp:HyperLink>--%> <br />                                                        
                                        <asp:Label ID="lbSize" runat="server" Text='<%# "ขนาด " + DataBinder.Eval(Container.DataItem, "CUS_BK_SIZE") %>'></asp:Label> <br />
                                        <asp:Label ID="lbColor" runat="server" Text='<%# "สี " + DataBinder.Eval(Container.DataItem, "CUS_BK_COLOR") %>' 
                                            Visible='<%# DataBinder.Eval(Container.DataItem, "CUS_BK_COLOR").ToString().StartsWith("http") ? false : 
                                        DataBinder.Eval(Container.DataItem, "CUS_BK_COLOR").ToString() == "" ? false : true %>'></asp:Label>
                                        <%--<br /><asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CUS_BK_SHOPNAME") %>'></asp:Label>                             --%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ราคา (¥)">
                                    <ItemTemplate>
                                        <asp:Label ID="lbPrice" runat="server" CssClass="right-align" Width="50%"
                                            Text='<%# NumberStringtoString(DataBinder.Eval(Container.DataItem, "CUS_BK_PRICE").ToString(), "Money") %>'>></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="จำนวน">
                                    <ItemTemplate>
                                        <asp:MultiView ID="mvA" runat="server" ActiveViewIndex="0">
                                            <asp:View ID="vA1" runat="server">
                                                <asp:Label ID="lbAmount" runat="server" CssClass="center-align" Width="50%"
                                                    Text='<%# DataBinder.Eval(Container.DataItem, "CUS_BK_AMOUNT") %>'></asp:Label>
                                            </asp:View>
                                            <asp:View ID="vA2" runat="server">
                                                <asp:TextBox ID="txtAmount" runat="server" Width="50px"
                                                    Text='<%# DataBinder.Eval(Container.DataItem, "CUS_BK_AMOUNT") %>'></asp:TextBox>
                                            </asp:View>
                                        </asp:MultiView>                                    
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="รวมทั้งหมด (¥)">
                                    <ItemTemplate>
                                        <asp:Label ID="lbTotal" runat="server" CssClass="right-align" Width="50%"
                                            Text='<%# SumTotal(DataBinder.Eval(Container.DataItem, "CUS_BK_PRICE").ToString(),
                                        (DataBinder.Eval(Container.DataItem, "CUS_BK_AMOUNT")).ToString()) %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:MultiView ID="mvB" runat="server" ActiveViewIndex="0">
                                            <asp:View ID="vB1" runat="server">
                                                <asp:ImageButton ID="imbEdit" runat="server" ImageUrl="~/Images/icon/b_edit.png" 
                                                    Width="15px" Height="15px" OnClick="imbEdit_Click" />
                                                <asp:ImageButton ID="imbDelete" runat="server" ImageUrl="~/Images/icon/delete.png" 
                                                    Width="15px" Height="15px" OnClick="imbDelete_Click" OnClientClick="return confirm('คุณต้องการลบรายการ?');"/>
                                            </asp:View>
                                            <asp:View ID="vB2" runat="server">
                                                <asp:ImageButton ID="imgbtn_Updateprod_amount" runat="server" ImageUrl="~/Images/icon/check-icon.png" 
                                                    Width="15px" Height="15px" OnClick="imgbtn_Updateprod_amount_Click"/>
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
                </div>
                <div class="col s12 m12 l12 TestBox1">
                    <%--<button id="btnOrder" runat="server" type="submit" onserverclick="btnOrder_ServerClick"
                        name="action" class="btn waves-effect orange waves-light">
                        Order                                
                    </button>--%>
                    <asp:ImageButton ID="imbOrder" runat="server" ImageUrl="~/Images/btn/Order.gif"
                        OnClick="imbOrder_Click" />
                    <%--<button type="button" class="btn waves-effect orange waves-light" name="action">
                        <asp:Button ID="btnOrder" runat="server" OnClick="btnOrder_Click" Text="Order" />
                    </button>--%>
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

